using OrcamentoAuto.Communication.Response.Veiculo;

namespace OrcamentoAuto.Communication.Response.Cliente;
public class ResponseClienteJson
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
    public string RgIe { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public IList<ResponseVeiculoJson> Veiculos { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = null;
}
