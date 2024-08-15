namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class RolNotificationService
    {
        public event Action OnRolUpdated;

        public void NotifyRolUpdated()
        {
            OnRolUpdated?.Invoke();
        }
    }
}
