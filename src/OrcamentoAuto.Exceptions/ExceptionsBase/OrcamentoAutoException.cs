using System.Net;

namespace OrcamentoAuto.Exceptions.ExceptionsBase;
public abstract class OrcamentoAutoException(string message) : SystemException(message)
{
        public abstract HttpStatusCode GetStatusCode();
        public abstract IList<string> GetErrorMessages();
}