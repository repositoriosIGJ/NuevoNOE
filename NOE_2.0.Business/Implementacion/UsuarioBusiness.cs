using AutoMapper;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;
using NUEVO.NOE.Service.Contrato;

namespace NUEVO.NOE.Business.Implementacion
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IActiveDirectoryService _activeDirectoryService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolUsuarioRepository _rolusuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioBusiness(IActiveDirectoryService activeDirectoryService, IUsuarioRepository usuarioRepository, IRolUsuarioRepository rolusuarioRepository, IMapper mapper)
        {
            _activeDirectoryService = activeDirectoryService;
            _usuarioRepository = usuarioRepository;
            _rolusuarioRepository = rolusuarioRepository;
            _mapper = mapper;
        }

        public ResponseDTO<List<UsuarioActiveDirectory>> GetUsersActiveDirectory()
        {
            var rst = _activeDirectoryService.GetUsers();

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

        public ResponseDTO<bool> ValidateUserActiveDirectory(string nombre, string password)
        {
            var rst = _activeDirectoryService.ValidateUser(nombre, password);

            return rst;
        }

        public async Task<ResponseDTO<UsuarioDTO>> AddUser(UsuarioDTO usuarioDTO)
        {
            var rsp = await _usuarioRepository.AddUser(usuarioDTO);

            return rsp;
        }

        public async Task<ResponseDTO<UsuarioDTO>> EditUser(UsuarioDTO usuarioDTO)
        {
            var rsp = await _usuarioRepository.EditUser(usuarioDTO);

            return rsp;
        }

        public async Task<ResponseDTO<bool>> RemoveUser(int Id)
        {
            var rsp = await _usuarioRepository.RemoveUser(Id);

            return rsp;
        }
    }
}
