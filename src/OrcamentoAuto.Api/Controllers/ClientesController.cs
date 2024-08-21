using Microsoft.AspNetCore.Mvc;
using OrcamentoAuto.Application.UseCase.Clientes.GetById;
using OrcamentoAuto.Application.UseCase.Clientes.Register;
using OrcamentoAuto.Communication.Request.Cliente;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;

namespace OrcamentoAuto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterClienteRequest request,
        [FromServices] RegisterClienteUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(
        [FromRoute] string id,
        [FromServices] GetByIdClienteUseCase useCase)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }

}
