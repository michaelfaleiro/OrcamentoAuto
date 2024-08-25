namespace OrcamentoAuto.Communication.Request.Cliente;
public class UpdateVeiculoClienteRequest : AdicionarVeiculoClienteRequest
{
    public string VeiculoId { get; set; } = string.Empty;
}
