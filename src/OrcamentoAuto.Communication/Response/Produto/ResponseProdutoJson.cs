namespace OrcamentoAuto.Communication.Response.Produto;
public class ResponseProdutoJson
{
    public string Id { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public int EstoqueAtual { get; set; }
    public bool Ativo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
