using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using OrcamentoAuto.Exceptions.ExceptionsBase;
using OrcamentoAuto.Communication.Response;

namespace OrcamentoAuto.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is OrcamentoAutoException)
        {
            var orcamentoAutoException = (OrcamentoAutoException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)orcamentoAutoException.GetStatusCode();
            
            var responseJson = new ResponseErrorJson(orcamentoAutoException.GetErrorMessages());

            context.Result = new ObjectResult(responseJson);
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var list = new List<string> { "Erro interno no servidor"};

            var responseJson = new ResponseErrorJson(list);

            context.Result = new ObjectResult(responseJson);
        }
    }
}