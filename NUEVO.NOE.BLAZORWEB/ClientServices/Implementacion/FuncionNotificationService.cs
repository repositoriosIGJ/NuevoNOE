namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class FuncionNotificationService
    {
        public event Action OnFuncionlUpdated;

        public void NotifyFuncionUpdated()
        {
            OnFuncionlUpdated?.Invoke();
        }
    }
}
