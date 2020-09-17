using System.Threading.Tasks;
using WinApp.Comun.Dto.Intercambio;
using WinApp.Firmado;
using WinApp.Servicio;

namespace WinApp.API
{
    public class EnviarDocumento
    {
        private readonly ISerializador _serializador;
        private readonly IServicioSunatDocumentos _servicioSunatDocumentos;

        public EnviarDocumento(ISerializador serializador, IServicioSunatDocumentos servicioSunatDocumentos)
        {
            _serializador = serializador;
            _servicioSunatDocumentos = servicioSunatDocumentos;
        }

        public async Task<EnviarDocumentoResponse> Post(EnviarDocumentoRequest request)
        {
            var response = new EnviarDocumentoResponse();
            var nombreArchivo = $"{request.Ruc}-{request.TipoDocumento}-{request.IdDocumento}";
            var tramaZip = await _serializador.GenerarZip(request.TramaXmlFirmado, nombreArchivo);

            _servicioSunatDocumentos.Inicializar(new ParametrosConexion
            {
                Ruc = request.Ruc,
                UserName = request.UsuarioSol,
                Password = request.ClaveSol,
                EndPointUrl = request.EndPointUrl
            });

            var resultado = _servicioSunatDocumentos.EnviarDocumento(new DocumentoSunat
            {
                TramaXml = tramaZip,
                NombreArchivo = $"{nombreArchivo}.zip"
            });

            if (!resultado.Exito)
            {
                response.Exito = false;
                response.MensajeError = resultado.MensajeError;
                //response.TramaZipCdr = "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";
            }
            else
            {
                response = await _serializador.GenerarDocumentoRespuesta(resultado.ConstanciaDeRecepcion);
                // Quitamos la R y la extensión devueltas por el Servicio.
                response.NombreArchivo = nombreArchivo;
            }

            return response;
        }
    }
}
