using System.Net;

namespace Ecclesia.Domain
{
    public static class Messages
    {
        public static string RegistroNaoEncontrado { get { return "Registro Não Encontrado"; }}
        public static string NaoAutorizado { get { return "Não Autorizado"; } }

        public static HttpResponseMessage Message(HttpStatusCode statusCode)
        {
            var message = "";
            if (statusCode == HttpStatusCode.NotFound)
            {
                message = Messages.RegistroNaoEncontrado;
            }else if (statusCode == HttpStatusCode.Unauthorized)
            {
                message = Messages.NaoAutorizado;
            }
            var resp = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(string.Format(message)),
                ReasonPhrase = message
            };
            return resp;
        }
    }
}
