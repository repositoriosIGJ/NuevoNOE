namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    //Este servicio se encargará de emitir eventos cuando se realice una actualización en los usuarios.
    public class UsuarioNotificationService
    {
        public event Action OnUsuarioUpdated;

        public void NotifyUsuarioUpdated()
        {
            OnUsuarioUpdated?.Invoke();
        }
    }
}
