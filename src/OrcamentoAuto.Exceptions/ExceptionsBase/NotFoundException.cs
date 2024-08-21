using System.Net;

namespace OrcamentoAuto.Exceptions.ExceptionsBase;
public class NotFoundException(string message) : OrcamentoAutoException(message)
{

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.NotFound;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> { Message };
    }
}
