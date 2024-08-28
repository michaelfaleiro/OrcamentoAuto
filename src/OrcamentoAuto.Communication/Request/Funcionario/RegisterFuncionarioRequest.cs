using OrcamentoAuto.Communication.Enums;

namespace OrcamentoAuto.Communication.Request.Funcionario;
public class RegisterFuncionarioRequest
{
    public string Nome { get;  set; } = string.Empty;
    public string Email { get;  set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public ETipoFuncionario TipoFuncionario { get; set; }
}
