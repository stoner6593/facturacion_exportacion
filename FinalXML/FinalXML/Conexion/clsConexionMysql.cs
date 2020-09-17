using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FinalXML.Conexion
{
    class clsConexionMysql 
    {
        public MySqlConnection conector = null;
        public static String sConex = ConfigurationManager.ConnectionStrings["ConnNegocio"].ConnectionString;      

        public MySqlConnection conectarBD()
        {
            try
            {
                conector = new MySqlConnection(sConex);
                conector.Open();
                return conector;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MySqlConnection desconectarBD()
        {
            conector.Close(); return conector;
        }

        public String LocalIPAddress()
        {
            IPHostEntry host;
            String localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

    }
}
