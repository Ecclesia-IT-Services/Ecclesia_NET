using System.Net;

namespace Ecclesia.Domain
{
    public static class Messages
    {
        public static string RegistroNaoEncontrado { get { return "Registro Não Encontrado"; }}
        public static string NaoAutorizado { get { return "Não Autorizado"; } }
        public static string LoginJaExiste { get { return " Esse login já existe"; } }

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
            else if (statusCode == HttpStatusCode.BadRequest)
            {
                message = Messages.LoginJaExiste;
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
