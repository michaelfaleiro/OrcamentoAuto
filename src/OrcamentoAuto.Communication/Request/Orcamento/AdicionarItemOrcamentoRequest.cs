namespace OrcamentoAuto.Communication.Request.Orcamento;
public class AdicionarItemOrcamentoRequest
{
    public string OrcamentoId { get;  set; } = string.Empty;
    public string ProdutoId { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorVenda { get; set; }
    
}
