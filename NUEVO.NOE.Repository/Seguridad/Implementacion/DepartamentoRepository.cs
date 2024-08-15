using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUEVO.NOE.API.Models;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Repository.Seguridad.Implementacion
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly SeguridadDbContext _db;
        private readonly IMapper _mapper;

        public DepartamentoRepository(SeguridadDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<List<Departamento>>> GetDepartamentos()
        {
            ResponseDTO<List<Departamento>> rsp = new();
            rsp.IsSuccess = false;
            try
            {
                var departamentos = await _db.Departamentos.ToListAsync();
                //var departamentosDTO = _mapper.Map<List<DepartamentoDTO>>(departamentos);
                rsp.IsSuccess = true;
                rsp.Data = departamentos;
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }
            return rsp;
        }
    }
}
