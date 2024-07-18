using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;
using System.Data;

namespace NUEVO.NOE.Repository.Seguridad.Implementacion
{
    public class FuncionRolRepositoy : IFuncionRolRepository
    {

        private readonly SeguridadDbContext _db;
        private readonly IMapper _mapper;

        public FuncionRolRepositoy(SeguridadDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<bool>> AddRolFuncion(RolFuncionDTO rolFuncionDto)
        {
            ResponseDTO<bool> rst = new ResponseDTO<bool>()
            {
                IsSuccess = false,
                Data = false,
            };

            try
            {
                var existefuncion = _db.Funciones.Any(_ => _.Id == rolFuncionDto.Funid);
                var existerol = _db.Roles.Any(_ => _.Id == rolFuncionDto.Rolid);

                if (existefuncion && existerol)
                {

                    var sql = "EXEC sp_AddRolFuncion @rolid,@funid";


                    var parameters = new[]{

                           new SqlParameter( "@rolid",rolFuncionDto.Rolid),
                           new SqlParameter("@funid", rolFuncionDto.Funid)
                        };

                    await _db.Database.ExecuteSqlRawAsync(sql, parameters);

                    rst.IsSuccess = true;
                    rst.Data = true;
                    rst.Message = "Ok";
                }
                else
                {
                    rst.Message = "Rol o funcion inexistente";
                }
            }

            catch (Exception ex)
            {

                rst.Message = ex.Message;
            }

            return rst;
        }

        public async Task<ResponseDTO<RolFuncionDTO>> DeleteRolFuncion(RolFuncionDTO rolFuncionDTO)
        {
            ResponseDTO<RolFuncionDTO> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                bool existerol = _db.Roles.Any(_ => _.Id == rolFuncionDTO.Rolid);
                bool existefuncion = _db.Funciones.Any(_ => _.Id == rolFuncionDTO.Funid);

                if (existefuncion && existerol)
                {

                    var sql = "EXEC sp_DeleteRolFuncion @rolid,@funid";

                    var parameters = new[] {
                  new SqlParameter("@rolid", rolFuncionDTO.Rolid),
                  new SqlParameter("@funid", rolFuncionDTO.Funid)
                };

                    await _db.Database.ExecuteSqlRawAsync(sql, parameters);

                    rsp.IsSuccess = true;
                    rsp.Message = "Ok";
                    rsp.Data = rolFuncionDTO;
                }
                else
                {

                    rsp.Message = "rol o funcion inexistente";
                }

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int idRol)
        {
            ResponseDTO<List<FuncionDTO>> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var existeRol = _db.Roles.Any(r => r.Id == idRol);

                if (existeRol)
                {
                    var sql = "EXEC sp_GetFuncionesAssignedToRol @rolid";

                    var parameter = new SqlParameter("@rolid", idRol);

                    var funciones = await _db.Funciones.FromSqlRaw(sql, parameter).ToListAsync();

                    var funcionesDto = _mapper.Map<List<FuncionDTO>>(funciones);
                    rsp.IsSuccess = true;
                    rsp.Data = funcionesDto;
                    rsp.Message = "Ok";

                }
                else { rsp.Message = "rol inexistente"; }
            }
            catch (Exception ex)
            {

                throw;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesNotAssignedToRol(int idRol)
        {
            ResponseDTO<List<FuncionDTO>> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var existeRol = _db.Roles.Any(_ => _.Id == idRol);
                if (existeRol)
                {
                    var sql = "EXEC sp_GetFuncionesNotAssignedToRol @rolid";
                    var parameter = new SqlParameter("@rolid", idRol);
                    var funciones = _db.Funciones.FromSqlRaw(sql, parameter).ToList();

                    var funcionesDto = _mapper.Map<List<FuncionDTO>>(funciones);
                    rsp.IsSuccess = true;
                    rsp.Message = "Ok";
                    rsp.Data = funcionesDto;

                }
                else { rsp.Message = "rol inexistente"; }
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFuncionById(int idRol)
        {
            ResponseDTO<List<RolFuncionDTO>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var existerol = await _db.Roles.AnyAsync(_ => _.Id == idRol);

                if (!existerol)
                {
                    rsp.Message = "rol inexistente";
                }
                else
                {
                    var rolfunciones = await _db.RolFunciones.
                                                Include(_ => _.Rol).
                                                Include(_ => _.Funcion).
                                                Where(_ => _.Rolid == idRol).
                                                ToListAsync();

                    var rolesfuncionesdto = _mapper.Map<List<RolFuncionDTO>>(rolfunciones);
                    rsp.IsSuccess = true;
                    rsp.Message = "Ok";
                    rsp.Data = rolesfuncionesdto;
                }


            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;

        }

        public async Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFunciones()
        {
            ResponseDTO<List<RolFuncionDTO>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var rolesfunciones = await _db.RolFunciones.
                                           Include(_ => _.Rol).
                                           Include(_ => _.Funcion).
                                           ToListAsync();
                var rolesfuncionesdto = _mapper.Map<List<RolFuncionDTO>>(rolesfunciones);
                rsp.IsSuccess = true;
                rsp.Message = "Ok";
                rsp.Data = rolesfuncionesdto;
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<RolFuncionDTO>> UpdateRolFuncion(RolFuncionDTO oldRolFuncionDTO, RolFuncionDTO newRolFuncionDTO)
        {
            ResponseDTO<RolFuncionDTO> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var existeoldrol = _db.Roles.Any(_ => _.Id == oldRolFuncionDTO.Rolid);
                var existenewrol = _db.Roles.Any(_ => _.Id == newRolFuncionDTO.Rolid);
                var existeoldfuncion = _db.Funciones.Any(_ => _.Id == oldRolFuncionDTO.Funid);
                var existenewfuncion = _db.Funciones.Any(_ => _.Id == oldRolFuncionDTO.Funid);

                if (existenewrol && existenewfuncion && existeoldfuncion && existeoldrol)
                {

                    var sql = "EXEC sp_UpdateRolFuncion @newrolid,@newfunid,@oldrolid,@oldfunid";

                    var parameters = new[] {
                        new SqlParameter("@newrolid", newRolFuncionDTO.Rolid),
                        new SqlParameter("@newfunid",newRolFuncionDTO.Funid),
                        new SqlParameter("@oldrolid", oldRolFuncionDTO.Rolid),
                        new SqlParameter("@oldfunid", oldRolFuncionDTO.Funid)
                    };

                    await _db.Database.ExecuteSqlRawAsync(sql, parameters);

                    rsp.IsSuccess = true;
                    rsp.Message = "Ok";
                    rsp.Data = newRolFuncionDTO;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rsp;
        }
    }
}
