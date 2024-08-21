using System.Net;

namespace OrcamentoAuto.Exceptions.ExceptionsBase;
public class ErrorOnSaveException(string message) : OrcamentoAutoException(message)   
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.InternalServerError;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> {Message};
    }
}