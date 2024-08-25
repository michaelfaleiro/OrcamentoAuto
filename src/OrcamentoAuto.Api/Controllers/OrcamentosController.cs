using Microsoft.AspNetCore.Mvc;
using OrcamentoAuto.Application.UseCase.Orcamentos.GetAll;
using OrcamentoAuto.Application.UseCase.Orcamentos.GetById;
using OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.AdicionarItem;
using OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.RemoverItem;
using OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.UpdateItem;
using OrcamentoAuto.Application.UseCase.Orcamentos.Register;
using OrcamentoAuto.Communication.Request.Orcamento;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Orcamento;

namespace OrcamentoAuto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrcamentosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseOrcamentoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterOrcamentoRequest request,
        [FromServices] RegisterOrcamentoUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponseOrcamentoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] GetAllOrcamentosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber, int pageSize = Configuration.DefaultPageSize
        )
    {
        var response = await useCase.Execute(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(Response<ResponseOrcamentoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(
        [FromRoute] string id,
        [FromServices] GetByIdOrcamentoUseCase useCase)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }

    [HttpPost("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AdicionarItemOrcamentoAsync(
        [FromBody] AdicionarItemOrcamentoRequest request,
        [FromServices] AdicionarItemOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        return NoContent();
    }

    [HttpPut("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverItemOrcamentoAsync(
        [FromBody] UpdateItemOrcamentoRequest request,
        [FromServices] UpdateItemOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        return NoContent();
    }

    [HttpDelete("itens")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverItemOrcamentoAsync(
        [FromBody] RemoverItemOrcamentoRequest request,
        [FromServices] RemoverItemOrcamentoUseCase useCase)
    {
        await useCase.Execute(request);
        return NoContent();
    }


}
