using NUEVO.NOE.DTO;
using NUEVO.NOE.Model;
using NUEVO.NOE.Model.UtilidadesOracles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUEVO.NOE.Business.DatosCiviles.Contrato
{
    public interface IDatosCivilesBusiness
    {
        Task<ResponseDTO<List<PersoneriaCiviles>>> GetDatosCiviles(FiltrosDatosCiviles filtro);

    }
}
