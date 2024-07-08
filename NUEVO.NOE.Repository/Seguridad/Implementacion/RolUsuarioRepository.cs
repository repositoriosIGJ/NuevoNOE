using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Repository.Seguridad.Implementacion
{
    public class RolUsuarioRepository : IRolUsuarioRepository
    {
        private readonly SeguridadDbContext _db;
        private readonly IMapper _mapper;

        public RolUsuarioRepository(SeguridadDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ResponseDTO<bool>> AddRolUsuario(UsuarioRolDTO usuarioRolDto)
        {
            var rsp = new ResponseDTO<bool>();
            rsp.IsSuccess = false;

            try
            {
                var usuarioRol = _mapper.Map<UsuarioRol>(usuarioRolDto);
                var user = await _db.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == usuarioRol.Usrid);
                var rol = await _db.Roles.AsNoTracking().FirstOrDefaultAsync(u => u.Id.Equals(usuarioRol.Rolid));
                if (user is not null || rol is not null)
                {
                    //var sql = "INSERT INTO UsuarioRol(Usrid, Rolid) VALUES (@Usrid, @Rolid)";
                    var sql = "EXEC AddUsuarioRol @Usrid, @Rolid";
                    var parameters = new[]
                    {
                        new SqlParameter("@Usrid", usuarioRol.Usrid),
                        new SqlParameter("@Rolid", usuarioRol.Rolid)
                     };

                    await _db.Database.ExecuteSqlRawAsync(sql, parameters);

                    rsp.Message = "OK";
                    rsp.IsSuccess = true;
                    rsp.Data = true;
                }
                else
                {
                    rsp.Message = "Usuario o Rol inexistente";
                }

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<UsuarioRolDTO>> DeleteRolUsuario(UsuarioRolDTO usuarioRolDto)
        {
            var rsp = new ResponseDTO<UsuarioRolDTO>();
            rsp.IsSuccess = false;

            try
            {
                var usuarioRol = _mapper.Map<UsuarioRol>(usuarioRolDto);
                var user = await _db.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioRol.Usrid);
                var rol = await _db.Roles.FirstOrDefaultAsync(u => u.Id.Equals(usuarioRol.Rolid));
                if (user is not null || rol is not null)
                {

                    var sql = "EXEC RemoveUsuarioRol @Usrid, @Rolid";
                    var parameters = new[]
                    {
                        new SqlParameter("@Usrid", usuarioRol.Usrid),
                        new SqlParameter("@Rolid", usuarioRol.Rolid)
                     };

                    await _db.Database.ExecuteSqlRawAsync(sql, parameters);

                    rsp.Message = "OK";
                    rsp.IsSuccess = true;
                    rsp.Data = usuarioRolDto;
                }
                else
                {
                    rsp.Message = "Usuario o Rol inexistente";
                }

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioById(int idUser)
        {
            ResponseDTO<List<UsuarioRolDTO>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var existeUsuario = _db.Usuarios.Any(_ => _.Id == idUser);

                if (existeUsuario)
                {
                    var usuarioRoles = await _db.UsuarioRoles.Where(_ => _.Usrid == idUser)
                                 .Include(x => x.Rol)
                                 .ToListAsync();

                    if (usuarioRoles.Count == 0)
                    {
                        rsp.IsSuccess = true;
                        rsp.Message = "El usuario no tiene roles";
                    }
                    else
                    {
                        var usuarioRolesDTO = _mapper.Map<List<UsuarioRolDTO>>(usuarioRoles);

                        rsp.IsSuccess = true;
                        rsp.Data = usuarioRolesDTO;
                        rsp.Message = "Ok";
                    }

                }
                else
                {
                    rsp.Message = "Usuario inexistente";
                }


            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioByName(string name)
        {
            ResponseDTO<List<UsuarioRolDTO>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var existeUsuario = _db.Usuarios.Any(_ => _.NameActiveDirectory == name);

                if (existeUsuario)
                {
                    var usuarioRoles = await _db.UsuarioRoles.Where(_ => _.Usr.UserName == name)
                                      .Include(x => x.Rol)
                                      .ToListAsync();


                    if (usuarioRoles.Count == 0)
                    {
                        rsp.IsSuccess = true;
                        rsp.Message = "El usuario no tiene roles";
                    }
                    else
                    {
                        var usuarioRolesDTO = _mapper.Map<List<UsuarioRolDTO>>(usuarioRoles);

                        rsp.IsSuccess = true;
                        rsp.Data = usuarioRolesDTO;
                        rsp.Message = "Ok";
                    }
                }
                else
                {

                    rsp.Message = "Usuario inexistente";
                }



            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarios()
        {
            ResponseDTO<List<UsuarioRolDTO>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var usuariosRoles = await _db.UsuarioRoles.
                                           Include(_ => _.Rol).
                                           Include(_ => _.Usr).
                                           ToListAsync();

                var usuariosRolesDTO = _mapper.Map<List<UsuarioRolDTO>>(usuariosRoles);
                rsp.IsSuccess = true;
                rsp.Data = usuariosRolesDTO;
                rsp.Message = "Ok";
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }


            return rsp;
        }

        public async Task<ResponseDTO<UsuarioRolDTO>> UpdateRolUsuario(UsuarioRolDTO OldUsuarioRolDTO, UsuarioRolDTO NewUsuarioRolDTO)
        {
            ResponseDTO<UsuarioRolDTO> rsp = new();
            try
            {
                var OldusuarioRol = _mapper.Map<UsuarioRol>(OldUsuarioRolDTO);
                var user = await _db.Usuarios.FirstOrDefaultAsync(u => u.Id == OldUsuarioRolDTO.Usrid);
                var rol = await _db.Roles.FirstOrDefaultAsync(u => u.Id.Equals(OldUsuarioRolDTO.Rolid));
                var nuser = await _db.Usuarios.FirstOrDefaultAsync(u => u.Id == NewUsuarioRolDTO.Usrid);
                var nrol = await _db.Roles.FirstOrDefaultAsync(u => u.Id.Equals(NewUsuarioRolDTO.Rolid));
                if (user is not null || rol is not null || nuser is not null || nrol is not null)
                {
                    var sql = "EXEC UpdateUsuarioRol @OldUsrid, @OldRolid,@NewUsrid,@NewRolid,@FechaAlta";
                    var parameters = new[]
                    {
                        new SqlParameter("@OldUsrid", OldUsuarioRolDTO.Usrid),
                        new SqlParameter("@OldRolid", OldUsuarioRolDTO.Rolid),
                        new SqlParameter("@NewUsrid", NewUsuarioRolDTO.Usrid),
                        new SqlParameter("@NewRolid", NewUsuarioRolDTO.Rolid),
                        new SqlParameter("@FechaAlta", DateTime.UtcNow),

                     };

                    await _db.Database.ExecuteSqlRawAsync(sql, parameters);

                    rsp.Message = "OK";
                    rsp.IsSuccess = true;
                    rsp.Data = NewUsuarioRolDTO;

                }
                else
                {
                    rsp.Message = "Usuarios o Roles inexistentes";
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
