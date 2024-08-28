using Microsoft.AspNetCore.Mvc;
using OrcamentoAuto.Application.UseCase.Funcionarios.Delete;
using OrcamentoAuto.Application.UseCase.Funcionarios.GetAll;
using OrcamentoAuto.Application.UseCase.Funcionarios.GetById;
using OrcamentoAuto.Application.UseCase.Funcionarios.Register;
using OrcamentoAuto.Application.UseCase.Funcionarios.Update;
using OrcamentoAuto.Communication.Request.Funcionario;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Funcionario;

namespace OrcamentoAuto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Response<ResponseFuncionarioJson>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromBody] RegisterFuncionarioRequest request,
        [FromServices] RegisterFuncionarioUseCase _registerFuncionarioUseCase
        )
    {
        var response = await _registerFuncionarioUseCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<ResponseFuncionarioJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllFuncionariosUseCase _getAllFuncionariosUseCase,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var response = await _getAllFuncionariosUseCase.Execute(pageNumber, pageSize);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Response<ResponseFuncionarioJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] string id,
        [FromServices] GetByIdFuncionarioUseCase _getByIdFuncionarioUseCase
        )
    {
        var response = await _getByIdFuncionarioUseCase.Execute(id);
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Response<ResponseFuncionarioJson>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(
        [FromRoute] string id,
        [FromBody] UpdateFuncionarioRequest request,
        [FromServices] UpdateFuncionarioUseCase _updateFuncionarioUseCase
        )
    {
        await _updateFuncionarioUseCase.Execute(id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] string id,
        [FromServices] DeleteFuncionarioUseCase _deleteFuncionarioUseCase
        )
    {
        await _deleteFuncionarioUseCase.Execute(id);
        return NoContent();
    }
}
