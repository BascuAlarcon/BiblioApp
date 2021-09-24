 
/// <summary>
/// Clase para manejar las Sessiones
/// </summary>

public static class clsSession
{
    private const string CTipoUsuario = "";
         
    public static string clsTipoUsuario
    {
        get
        {
            object state = System.Web.HttpContext.Current.Session[CTipoUsuario];
            return (string)state;
        }
        set
        {
            System.Web.HttpContext.Current.Session[CTipoUsuario] = value;
        }

    }
} 