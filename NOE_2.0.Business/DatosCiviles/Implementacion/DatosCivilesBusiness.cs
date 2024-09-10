using NUEVO.NOE.Business.DatosCiviles.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Repository.DatosCiviles.Contrato;
using NUEVO.NOE.Repository.DatosCiviles.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUEVO.NOE.Business.DatosCiviles.Implementacion
{
    public class DatosCivilesBusiness : IDatosCivilesBusiness
    {
        private readonly IDatosCivilesRepository _datosCivilesRepository;

        public DatosCivilesBusiness(IDatosCivilesRepository datosCivilesRepository)
        {
            _datosCivilesRepository = datosCivilesRepository;   
        }

        public async Task<ResponseDTO<List<PersoneriaCiviles>>> GetDatosCiviles(FiltrosDatosCiviles filtro)
        {
            var rsp = await _datosCivilesRepository.GetDatosCiviles(filtro);

            return rsp;
        }
    }
    
}
