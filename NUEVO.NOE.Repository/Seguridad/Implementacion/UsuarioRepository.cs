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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SeguridadDbContext _db;
        private readonly IMapper _mapper;

        public UsuarioRepository(SeguridadDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<Usuario>> AddUser(Usuario usuario)
        {
            ResponseDTO<Usuario> rsp = new();
            rsp.IsSuccess = false;

            try
            {

                _db.Usuarios.Add(usuario);
                await _db.SaveChangesAsync();
                rsp.IsSuccess = true;
                rsp.Message = "Ok";
                rsp.Data = usuario;
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<Usuario>> EditUser(Usuario usuario)
        {
            ResponseDTO<Usuario> responseEdit = new();
            responseEdit.IsSuccess = false;

            try
            {
                // Verificar si el usuario existe
                var UserDb = await _db.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);
                if (UserDb == null)
                {
                    responseEdit.Message = "El usuario no existe en la base de datos.";
                    return responseEdit;
                }

                // Llamar al procedimiento almacenado
                var parameters = new SqlParameter[]
                {
        new SqlParameter("@Id", usuario.Id),
        new SqlParameter("@Nombre", usuario.Nombre),
        new SqlParameter("@Apellido", usuario.Apellido),
        new SqlParameter("@Documento", usuario.Documento),
        new SqlParameter("@UserName", usuario.UserName),
        new SqlParameter("@IdDpto", usuario.IdDpto),
        new SqlParameter("@Ultimoacceso", usuario.Ultimoacceso),
        new SqlParameter("@Bloqueado", usuario.Bloqueado),
        new SqlParameter("@Nrointentos", usuario.Nrointentos),
        new SqlParameter("@Baja", usuario.Baja),
        new SqlParameter("@Ipbloqueo", usuario.Ipbloqueo),
        new SqlParameter("@NameActiveDirectory", usuario.NameActiveDirectory)
                };
                //EJECUTAR STORE PROCEDURE
                var result = await _db.Database.ExecuteSqlRawAsync("EXEC SP_UpdateUsuario @Id, @Nombre, @Apellido, @Documento, @UserName, @IdDpto, @Ultimoacceso, @Bloqueado, @Nrointentos, @Baja, @Ipbloqueo, @NameActiveDirectory", parameters);
                responseEdit.IsSuccess = true;
                responseEdit.Message = "Ok";
                responseEdit.Data = usuario;

            }
            catch (Exception ex)
            {
                responseEdit.Message = $"Error: {ex.Message}";
            }

            return responseEdit;
        }

        //public async Task<ResponseDTO<Usuario>> EditUser(Usuario usuario)
        //{
        //    ResponseDTO<Usuario> rsp = new();
        //    rsp.IsSuccess = false;

        //    try
        //    {
        //        if (usuario == null || usuario.Id == null)
        //        {
        //            rsp.Message = "El usuario o el ID del usuario no pueden ser nulos";
        //            return rsp;
        //        }

        //        bool existeUser = _db.Usuarios.Any(_x => _x.Id == usuario.Id);
        //        if (existeUser)
        //        {

        //            _db.Usuarios.Update(usuario);
        //            await _db.SaveChangesAsync();
        //            rsp.IsSuccess = true;
        //            rsp.Message = "Ok";
        //            rsp.Data = usuario;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        rsp.Message = ex.Message;

        //    }

        //    return rsp;
        //}

        public async Task<ResponseDTO<UsuarioDTO>> GetDataUser(string name)
        {
            ResponseDTO<UsuarioDTO> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var user = await _db.Usuarios.Include(_ => _.Departamento)
                                             .FirstOrDefaultAsync(u => u.NameActiveDirectory == name);

                var roles = _db.UsuarioRoles.Include(x => x.Rol).Where(x => x.Usrid == user.Id).ToList();

                List<RolFuncion> rolesFunciones = new List<RolFuncion>();
                foreach (var rol in roles)
                {
                    var rolFuncion = _db.RolFunciones.Include(x => x.Funcion).Where(x => x.Rolid == rol.Rolid).ToList();

                    rolesFunciones.AddRange(rolFuncion);
                }
                UsuarioDTO usuarioDTO = new UsuarioDTO()
                {

                    Usuario = user,
                    UsuarioRol = roles,
                    RolFuncion = rolesFunciones

                };


                rsp.Data = usuarioDTO;
                rsp.Message = "Ok";
                rsp.IsSuccess = true;
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<Usuario>> GetUserById(int id)
        {
            ResponseDTO<Usuario> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var user = await _db.Usuarios.Include(_ => _.Departamento)
                                             .ThenInclude(_ => _.Roles)
                                             .FirstOrDefaultAsync(_ => _.Id == id);
                rsp.IsSuccess = true;
                rsp.Data = user;
                rsp.Message = "Ok";
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<List<Usuario>>> GetUsuarios()
        {
            ResponseDTO<List<Usuario>> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var usuarios = await _db.Usuarios.ToListAsync();

                rsp.Data = usuarios;
                rsp.IsSuccess = true;
                rsp.Message = "Ok";
            }
            catch (Exception ex)
            {
                rsp.Message = ex.Message;

            }

            return rsp;
        }

        public async Task<ResponseDTO<bool>> RemoveUser(int Id)
        {
            ResponseDTO<bool> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);

                if (usuario != null)
                {
                    _db.Usuarios.Remove(usuario);
                    await _db.SaveChangesAsync();
                    rsp.IsSuccess = true;
                    rsp.Data = true;
                    rsp.Message = "Ok";
                }
                else
                {
                    rsp.Message = "Usuario Inexistente";
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
