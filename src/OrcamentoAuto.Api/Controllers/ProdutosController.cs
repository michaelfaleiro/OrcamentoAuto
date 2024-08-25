using Microsoft.AspNetCore.Mvc;
using OrcamentoAuto.Application.UseCase.Produtos.Delete;
using OrcamentoAuto.Application.UseCase.Produtos.GetAll;
using OrcamentoAuto.Application.UseCase.Produtos.GetById;
using OrcamentoAuto.Application.UseCase.Produtos.Register;
using OrcamentoAuto.Application.UseCase.Produtos.Update;
using OrcamentoAuto.Communication.Request.Produto;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Produto;

namespace OrcamentoAuto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseProdutoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterProdutoRequest request,
        [FromServices] RegisterProdutoUseCase useCase)
    {
        var produto = await useCase.Execute(request);
        return Created(string.Empty, produto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponseProdutoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        [FromServices] GetAllProdutosUseCase useCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        int pageSize = Configuration.DefaultPageSize
        )
    {
        var response = await useCase.Execute(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(typeof(Response<ResponseProdutoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(
        [FromRoute] string id,
        [FromServices] GetByIdProdutoUseCase useCase)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }

    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(typeof(Response<ResponseProdutoJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] string id,
        [FromBody] UpdateProdutoRequest request,
        [FromServices] UpdateProdutoUseCase useCase)
    {
        var response = await useCase.Execute(id, request);
        return Ok(response);
    }

    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] string id,
        [FromServices] DeleteProdutoUseCase useCase)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
