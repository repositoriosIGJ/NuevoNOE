using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Repository.Seguridad.Implementacion
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SeguridadDbContext _db;

        public UsuarioRepository(SeguridadDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseDTO<Usuario>> GetDataUser(string name)
        {
            ResponseDTO<Usuario> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var user = await _db.Usuarios.Include(_ => _.Departamento)
                                             .FirstOrDefaultAsync(u => u.NameActiveDirectory == name);


                rsp.Data = user;
                rsp.Message = "Ok";
                rsp.IsSuccess = true;
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
    }
}
