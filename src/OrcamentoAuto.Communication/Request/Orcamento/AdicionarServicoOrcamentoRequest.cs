namespace OrcamentoAuto.Communication.Request.Orcamento;
public class AdicionarServicoOrcamentoRequest
{
    public string OrcamentoId { get; set; } = string.Empty;
    public string MecanicoId { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    
}
