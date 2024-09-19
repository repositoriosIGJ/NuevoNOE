using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;
using NUEVO.NOE.Service.Contrato;

namespace NUEVO.NOE.Business.Implementacion
{
    public class SeguridadBusiness : ISeguridadBusiness
    {
        private readonly IActiveDirectoryService _activeDirectoryService;
        private readonly IUsuarioRepository _usuarioRepository;

        public SeguridadBusiness(IActiveDirectoryService activeDirectoryService, IUsuarioRepository usuarioRepository)
        {
            _activeDirectoryService = activeDirectoryService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResponseDTO<List<UsuarioActiveDirectory>>> GetUsersActiveDirectory()
        {
            var rst = await _activeDirectoryService.GetUsers();

            return rst;
        }

        public async Task<ResponseDTO<List<Usuario>>> GetUsersDB()
        {
            var rst = new ResponseDTO<List<Usuario>>();
            rst.IsSuccess = false;
            try
            {

                rst = await _usuarioRepository.GetUsuarios();

            }
            catch (Exception ex)
            {

                rst.Message = ex.Message;
            }

            return rst;

        }

        public async Task<ResponseDTO<UsuarioDTO>> GetDataUser(string name)
        {
            var rst = new ResponseDTO<UsuarioDTO>();
            rst.IsSuccess = false;
            try
            {

                rst = await _usuarioRepository.GetDataUser(name);

            }
            catch (Exception ex)
            {

                rst.Message = ex.Message;
            }

            return rst;

        }

        public async Task<ResponseDTO<bool>> ValidateUserActiveDirectory(string nombre, string password)
        {
            var rst = await _activeDirectoryService.ValidateUser(nombre, password);

            return rst;
        }

    }
}
