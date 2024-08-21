namespace OrcamentoAuto.Communication.Request.Cliente;
public class RegisterClienteRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string RgIe { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
