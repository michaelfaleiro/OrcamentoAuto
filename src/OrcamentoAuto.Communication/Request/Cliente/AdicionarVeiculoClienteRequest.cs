namespace OrcamentoAuto.Communication.Request.Cliente;
public class AdicionarVeiculoClienteRequest
{
    public string ClienteId { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string AnoFabricao { get; set; } = string.Empty;
    public string AnoModelo { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Chassi { get; set; } = string.Empty;
    public string Renavam { get; set; } = string.Empty;
    public string Motor { get; set; } = string.Empty;
    public string Combustivel { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public string Cambio { get; set; } = string.Empty;
    
}
