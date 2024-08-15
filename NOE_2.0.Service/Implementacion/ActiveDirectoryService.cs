using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Service.Contrato;
using System.DirectoryServices;


namespace NUEVO.NOE.Service.Implementacion
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        ResponseDTO<List<UsuarioActiveDirectory>> rst = new ResponseDTO<List<UsuarioActiveDirectory>>();
        string DomainPath = "LDAP://OU=IGJ,OU=Organismos Delegados,OU=Ministerio,DC=JUSTICIA,DC=AR";

        public async Task<ResponseDTO<List<UsuarioActiveDirectory>>> GetUsers()
        {
            rst.IsSuccess = false;

            try
            {
                rst.Data = new List<UsuarioActiveDirectory>();


                DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);


                DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);

                adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
                adSearcher.PropertiesToLoad.Add("samaccountname");
                adSearcher.PropertiesToLoad.Add("ADsPath");


                SearchResult result;
                SearchResultCollection iResult = adSearcher.FindAll();



                UsuarioActiveDirectory item;
                if (iResult != null)
                {
                    for (int counter = 0; counter < iResult.Count; counter++)
                    {
                        result = iResult[counter];
                        if (result.Properties.Contains("samaccountname"))
                        {
                            item = new UsuarioActiveDirectory();

                            item.UserName = (String)result.Properties["samaccountname"][0];

                            if (result.Properties.Contains("ADsPath"))
                            {
                                item.ADsPath = (String)result.Properties["ADsPath"][0];
                            }




                            rst.Data.Add(item);
                            rst.Data.OrderBy(u => u.UserName);
                        }
                    }
                }

                adSearcher.Dispose();
                adSearchRoot.Dispose();

                rst.IsSuccess = true;
                rst.Message = "OK";


            }
            catch (Exception ex)
            {

                rst.Message = ex.Message;
            }

            return rst;
        }


        public async Task<ResponseDTO<bool>> ValidateUser(string username, string password)
        {
            ResponseDTO<bool> rst = new ResponseDTO<bool>();

            try
            {
                rst.IsSuccess = false;
                using (var entry = new DirectoryEntry(DomainPath, username, password))
                {
                    // Intenta acceder a las propiedades del usuario para verificar las credenciales
                    var obj = entry.NativeObject;
                    using (var searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = $"(SAMAccountName={username})";
                        searcher.PropertiesToLoad.Add("cn");
                        var result = searcher.FindOne();
                        if (result == null)
                        {
                            rst.Message = "No encontrado";
                        }
                    }
                }
                rst.Data = true;
                rst.IsSuccess = true;
                rst.Message = "OK credenciales validas";
            }
            catch (Exception ex)
            {
                rst.Data = false;
                rst.Message = ex.Message;


            }

            return rst;
        }
    }
}
