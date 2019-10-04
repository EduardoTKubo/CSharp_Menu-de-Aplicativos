using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Aplicativos.Classes
{
    class clsProcessos
    {
        public static string Retorna_ArqIni( string _Camp , string _Crm)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = Classes.clsBanco.Consulta("select Caminho from Aplicativos where Ativo = 1 and Campanha = '" + _Camp + "' and Aplicativo = '" + _Crm  + "'");
                if (dt1.Rows.Count != 0)
                {
                    return dt1.Rows[0]["Caminho"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Retorna_ArqIni", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return string.Empty;
            }
        }


        public static string Retorna_ArqExe(string _ArqIni)
        {
            try
            {
                string line;
                string resp = string.Empty;

                StreamReader arq = new StreamReader( _ArqIni  );
                while ((line = arq.ReadLine()) != null)
                {
                    if( line.Substring(0,9) == "PROGRAMA:")
                    {
                        resp = line.Substring(10);
                    }
                }
                return resp;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Retorna_ArqExe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return string.Empty;
            }
        }


    }
}
