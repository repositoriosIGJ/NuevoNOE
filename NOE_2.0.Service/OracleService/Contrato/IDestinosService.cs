using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NUEVO.NOE.Service.OracleService.Contrato
{
    public interface IDestinosService
    {
        Task<ResponseDTO<List<Destino>>> GetDestinos();
    }
}
