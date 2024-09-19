using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUEVO.NOE.Business.Oracle.Implementacion
{
    public class DestinosBusiness : IDestinosBusiness
    {
        private IDestinosService _destinosService;

        public DestinosBusiness(IDestinosService destinosService)
        {
            _destinosService = destinosService;
        }

        public async Task<ResponseDTO<List<Destino>>> GetDestinos()
        {
            var rsp = await _destinosService.GetDestinos();
            return rsp;
        }
    }
}
