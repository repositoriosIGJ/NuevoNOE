using AutoMapper;
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
                var rol = await _db.Roles.FirstOrDefaultAsync(r => r.Id == id);

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
                var roles = await _db.Roles.ToListAsync();
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


        public async Task<ResponseDTO<RolDTO>> UpdateRol(RolDTO rolDTO)
        {
            ResponseDTO<RolDTO> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var existeRol = _db.Roles.Any(r => r.Id == rolDTO.Id);

                if (existeRol)
                {

                    var rol = _mapper.Map<Rol>(rolDTO);
                    _db.Roles.Update(rol);
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

    }
}
