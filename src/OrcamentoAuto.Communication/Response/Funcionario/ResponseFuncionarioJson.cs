﻿namespace OrcamentoAuto.Communication.Response.Funcionario;
public class ResponseFuncionarioJson
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get;  set; } = string.Empty;
    public string Email { get;  set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string TipoFuncionario { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
