using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Repository.Seguridad.Implementacion
{
    public class FuncionRepository : IFuncionRepository
    {
        private readonly SeguridadDbContext _db;
        private readonly IMapper _mapper;

        public FuncionRepository(SeguridadDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<bool>> AddFuncion(FuncionDTO funcionDTO)
        {
            ResponseDTO<bool> rsp = new ResponseDTO<bool>();
            rsp.IsSuccess = false;
            try
            {
                var funcion = _mapper.Map<Funcion>(funcionDTO);
                _db.Funciones.Add(funcion);
                await _db.SaveChangesAsync();
                rsp.IsSuccess = true;
                rsp.Message = "Ok";
                rsp.Data = true;

            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<bool>> DeleteFuncion(int id)
        {
            ResponseDTO<bool> rsp = new ResponseDTO<bool>()
            {
                IsSuccess = false,
                Data = false
            };

            try
            {
                var funciondb = await _db.Funciones.FirstOrDefaultAsync(x => x.Id == id);

                if (funciondb is not null)
                {
                    _db.Funciones.Remove(funciondb);
                    await _db.SaveChangesAsync();
                    rsp.IsSuccess = true;
                    rsp.Message = "Funcion borrada";
                    rsp.Data = true;
                }
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public Task<ResponseDTO<FuncionDTO>> GetFuncionById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<List<FuncionDTO>>> GetFunciones()
        {
            ResponseDTO<List<FuncionDTO>> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var funciones = await _db.Funciones.ToListAsync();
                var funcionesDto = _mapper.Map<List<FuncionDTO>>(funciones);
                rsp.IsSuccess = true;
                rsp.Message = "OK";
                rsp.Data = funcionesDto;
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int rolId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<FuncionDTO>>> GetFuncionNotAssignedToRol(int rolId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<FuncionDTO>> UpdateFuncion(FuncionDTO funcionDTO)
        {
            ResponseDTO<FuncionDTO> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var funcion = _mapper.Map<Funcion>(funcionDTO);
                bool existeFuncion = _db.Funciones.Any(x => x.Id == funcion.Id);

                if (existeFuncion)
                {
                    _db.Funciones.Update(funcion);
                    await _db.SaveChangesAsync();
                    rsp.IsSuccess = true;
                    rsp.Message = "OK";
                    rsp.Data = funcionDTO;
                }
                else
                {
                    rsp.Message = "Funcion inexistente";
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
