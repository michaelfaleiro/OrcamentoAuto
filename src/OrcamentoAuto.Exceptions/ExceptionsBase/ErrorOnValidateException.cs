using System.Net;

namespace OrcamentoAuto.Exceptions.ExceptionsBase;
public class ErrorOnValidateException : OrcamentoAutoException
{
    private readonly IList<string> _errors;

    public ErrorOnValidateException(IList<string> messages) : base(string.Empty)
    {
        _errors = messages;
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.BadRequest;
    }

    public override IList<string> GetErrorMessages()
    {
        return _errors;
    }
}
