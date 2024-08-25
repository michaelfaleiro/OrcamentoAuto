using Microsoft.AspNetCore.Mvc;
using OrcamentoAuto.Application.UseCase.Clientes.Delete;
using OrcamentoAuto.Application.UseCase.Clientes.GetAll;
using OrcamentoAuto.Application.UseCase.Clientes.GetById;
using OrcamentoAuto.Application.UseCase.Clientes.Register;
using OrcamentoAuto.Application.UseCase.Clientes.Update;
using OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Adicionar;
using OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Remover;
using OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Update;
using OrcamentoAuto.Communication.Request.Cliente;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;

namespace OrcamentoAuto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterClienteRequest request,
        [FromServices] RegisterClienteUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<IEnumerable<ResponseClienteJson>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] GetAllClientesUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, int pageSize = Configuration.DefaultPageSize
        )
    {
        var response = await useCase.Execute(pageNumber, pageSize);
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

    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(typeof(Response<ResponseClienteJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] string id,
        [FromBody] UpdateClienteRequest request,
        [FromServices] UpdateClienteUseCase useCase)
    {
        var response = await useCase.Execute(id, request);
        return Ok(response);
    }

    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] string id,
        [FromServices] DeleteClienteUseCase useCase)
    {
        await useCase.Execute(id);
        return NoContent();
    }

    [HttpPost("veiculos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarVeiculoAsync(
        [FromBody] AdicionarVeiculoClienteRequest request,
        [FromServices] AdicionarVeiculoClienteUseCase useCase)
    {
        await useCase.Execute(request);
        return NoContent();
    }

    [HttpPut("veiculos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVeiculoAsync(
        [FromBody] UpdateVeiculoClienteRequest request,
        [FromServices] UpdateVeiculoUseCase useCase)
    {
        await useCase.Execute(request);
        return NoContent();
    }

    [HttpDelete("veiculos")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverVeiculoAsync(
        [FromBody] RemoverVeiculoRequest request,
        [FromServices] RemoverVeiculoUseCase useCase)
    {
        await useCase.Execute(request);
        return NoContent();
    }

}
