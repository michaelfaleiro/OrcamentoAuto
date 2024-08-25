namespace OrcamentoAuto.Communication.Response.ItemOrcamento;
public class ResponseItemOrcamentoJson
{
    public string Id { get; set; } = string.Empty;
    public string ProdutoId { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal ValorVenda { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
