using System.Net;

namespace OrcamentoAuto.Exceptions.ExceptionsBase;
public class BusinnesException(string message) : OrcamentoAutoException(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> { Message };
    }
}
