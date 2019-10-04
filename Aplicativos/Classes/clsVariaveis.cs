
namespace Aplicativos.Classes
{
    class clsVariaveis
    {
        // srv_db03
        //private static readonly string conexao = @"Data Source=10.0.32.63;Initial Catalog=PROCON; User ID=sa; Password=SRV@admin2012;";

        // srv_db02
        private static readonly string conexao = @"Data Source=10.0.32.54;Initial Catalog=CAD_TRADE; User ID=sa; Password=SRV@admin2012;";
        public static string Conexao
        {
            get { return conexao; }
        }

        private static string gstrSQL = string.Empty;
        public static string GstrSQL
        {
            get { return gstrSQL; }
            set { gstrSQL = value; }
        }

        private static bool gBoolOK = false;
        public static bool GBoolOK
        {
            get { return gBoolOK; }
            set { gBoolOK = value; }
        }
        
        private static string gstrIni = string.Empty;
        public static string GstrIni
        {
            get { return gstrIni; }
            set { gstrIni = value; }
        }

        private static string gstrExe = string.Empty;
        public static string GstrExe
        {
            get { return gstrExe; }
            set { gstrExe = value; }
        }


    }
}
