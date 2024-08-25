namespace OrcamentoAuto.Communication.Response.Veiculo;
public class ResponseVeiculoJson
{
    public string Id { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string? AnoFabricacao { get; set; } 
    public string? AnoModelo { get; set; }
    public string? Placa { get; set; } 
    public string? Chassi { get; set; } 
    public string? Renavam { get; set; } 
    public string? Combustível { get;  set; }
    public string? Motor { get;  set; }
    public string? Cambio { get; set; }
    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }

}
