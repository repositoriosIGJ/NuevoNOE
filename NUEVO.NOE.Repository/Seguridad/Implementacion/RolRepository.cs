using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Repository.Seguridad.Implementacion
{
    public class RolRepository : IRolRepository
    {
        private readonly SeguridadDbContext _db;
        private readonly IMapper _mapper;

        public RolRepository(SeguridadDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<bool>> AddRol(RolDTO rolDTO)
        {
            ResponseDTO<bool> rsp = new();
            {
                rsp.Data = false;
                rsp.IsSuccess = false;
            }

            try
            {
                var rol = _mapper.Map<Rol>(rolDTO);
                await _db.Roles.AddAsync(rol);
                await _db.SaveChangesAsync();
                rsp.IsSuccess = true;
                rsp.Data = true;
                rsp.Message = "OK";
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }



        public async Task<ResponseDTO<bool>> DeleteRol(int id)
        {
            ResponseDTO<bool> rsp = new()
            {
                Data = false,
                IsSuccess = false
            };

            try
            {
                var rolDB = await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
                if (rolDB != null)
                {

                    _db.Roles.Remove(rolDB);
                    await _db.SaveChangesAsync();
                    rsp.IsSuccess = true;
                    rsp.Data = true;
                    rsp.Message = "Ok";
                }
                else
                {
                    rsp.Message = "No encontrado";
                }
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }


        public async Task<ResponseDTO<RolDTO>> GetRolById(int id)
        {
            ResponseDTO<RolDTO> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var rol = await _db.Roles
                                .Include(_ => _.Departamento)
                                .FirstOrDefaultAsync(r => r.Id == id);

                if (rol == null) rsp.Message = "No encontrado";
                else
                {
                    var rolDTO = _mapper.Map<RolDTO>(rol);

                    rsp.Data = rolDTO;
                    rsp.IsSuccess = true;
                    rsp.Message = "Ok";
                }

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }
            return rsp;

        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRoles()
        {
            ResponseDTO<List<RolDTO>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var roles = await _db.Roles
                                    .Include(_ => _.Departamento)
                                    .ToListAsync();
                var rolesDTO = _mapper.Map<List<RolDTO>>(roles);
                rsp.IsSuccess = true;
                rsp.Data = rolesDTO;
                rsp.Message = "Ok";

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUser(int userId)
        {
            ResponseDTO<List<RolDTO>> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var sql = "EXEC sp_GetRolesNotAssignedToUser @usrid";
                var parameter = new SqlParameter("@usrid", userId);
                var roles = await _db.Roles.FromSqlRaw(sql, parameter).ToListAsync();

                var rolesDto = _mapper.Map<List<RolDTO>>(roles);

                rsp.IsSuccess = true;
                rsp.Data = rolesDto;

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRolesAssignedToUser(int userId)
        {
            ResponseDTO<List<RolDTO>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var sql = "EXEC sp_GetRolesAssignedToUser @usrId";
                var parameter = new SqlParameter("@usrId", userId);
                var roles = await _db.Roles.FromSqlRaw(sql, parameter).ToListAsync();

                var rolesDto = _mapper.Map<List<RolDTO>>(roles);
                rsp.IsSuccess = true;
                rsp.Data = rolesDto;
                rsp.Message = "Ok";

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<RolDTO>> UpdateRol(RolDTO rolDTO)
        {
            ResponseDTO<RolDTO> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                // Verifica si el rol existe en la base de datos
                var existeRol = await _db.Roles.AsNoTracking().AnyAsync(r => r.Id == rolDTO.Id);

                if (existeRol)
                {

                    var rol = _mapper.Map<Rol>(rolDTO);

                    //_db.Roles.Update(rol);
                    //se cambio porque tiraba error de trackeo
                    //se asigna el estado EntityState.Modified a la entidad mapeada para asegurar que EF la trate como una entidad que necesita ser actualizada.
                    _db.Entry(rol).State = EntityState.Modified; //funciono el cambio

                    await _db.SaveChangesAsync();
                    rsp.IsSuccess = true;
                    rsp.Data = rolDTO;
                    rsp.Message = "Ok";
                }
                else
                {
                    rsp.Message = "rol inexistente";
                }

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUserByDepartamento(int UsrId, int IdDepartamento)
        {
            ResponseDTO<List<RolDTO>> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var sql = @"
                            SELECT * 
                            FROM Rol
                            WHERE Rol.IdDepartamento = @IdDepartamento
                            AND Rol.Id NOT IN (
                                SELECT [rolid]
                                FROM [SEGURIDAD].[dbo].[UsuarioRol]
                                WHERE usrid = @UsrId
		                        )
                            ";


                var roles = await _db.Roles.FromSqlRaw(
                    sql,
                    new SqlParameter("@UsrId", UsrId),
                    new SqlParameter("@IdDepartamento", IdDepartamento)
                ).ToListAsync();

                if (roles != null && roles.Count > 0)
                {
                    rsp.Data = roles.Select(r => new RolDTO
                    {
                        Id = r.Id,
                        Descripcion = r.Descripcion,
                        IdDepartamento = r.IdDepartamento
                    }).ToList();
                    rsp.IsSuccess = true;
                    rsp.Message = "Ok";
                }
                else
                {
                    rsp.Message = "No roles found";
                }
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }
    }
}
