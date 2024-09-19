namespace NUEVO.NOE.Model.UtilidadesOracles
{
    public class TipoSocietario
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Acronimo { get; set; }
        public string AcronimoNombre
        {
            get { return $"[{Acronimo}]  {Nombre} "; }

        }
    }
}
