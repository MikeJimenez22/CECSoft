using System.Collections.Generic;

public static class ConfiguracionConexiones
{
    public static Dictionary<string, string> CadenasConexion = new Dictionary<string, string>()
    {
        {"MANAGUA LOCAL", @"Data Source=192.168.1.150\CECNIC,57000;Initial Catalog=CecnicSystem;User Id=Sistema;Password=1234;Integrated Security=false"},
        {"MANAGUA REMOTO", @"Data Source=10.147.19.213\CECNIC,57000;Initial Catalog=CecnicSystem;User Id=Sistema;Password=1234;Integrated Security=false"},
        {"TIPITAPA LOCAL", @"Data Source=192.168.1.160\CECNIC,57500;Initial Catalog=CecnicSystem;User Id=Tipitapa;Password=1234;Integrated Security=false"},
        {"TIPITAPA REMOTO", @"Data Source=10.144.156.62\CECNIC,57500;Initial Catalog=CecnicSystem;User Id=Tipitapa;Password=1234;Integrated Security=false"},
        {"DESARROLLO LOCAL", @"Data Source=DESKTOP-NURDDRI;Initial Catalog=CecnicSystem;Integrated Security=True"}
    };
}
