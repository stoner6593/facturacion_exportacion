using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML
{
    public  class Herramientas
    {
        public string GetResourcesPath()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "Certificado");
        }
        public string GetResourcesPath2()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "QR");
        }
        public string GetResourcesPath3()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "FACTURAS_PDF");
        }
        public string GetResourcesPath4()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "RXML");
        }
        public string GetResourcesPath5()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "Documentos");
        }
        public string GetResourcesPath6()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "BOLETAS_PDF");
        }
        public string GetResourcesPath7()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "NOTA_CREDITO_PDF");
        }
        public string GetResourcesPath8()
        {
            return System.IO.Path.Combine(GetAssemblyDirectory(), "NOTA_DEBITO_PDF");
        }
        public string GetAssemblyDirectory()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return System.IO.Path.GetDirectoryName(path);
        }
    }
}
