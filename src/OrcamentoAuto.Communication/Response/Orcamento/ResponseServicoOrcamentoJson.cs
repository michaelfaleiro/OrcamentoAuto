namespace OrcamentoAuto.Communication.Response.Orcamento;
public class ResponseServicoOrcamentoJson
{
    public string Mecanico { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
