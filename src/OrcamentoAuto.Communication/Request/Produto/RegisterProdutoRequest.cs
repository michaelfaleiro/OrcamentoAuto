namespace OrcamentoAuto.Communication.Request.Produto;
public class RegisterProdutoRequest
{
    public string Sku { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public decimal ValorCusto { get; set; } 
    public decimal ValorVenda { get; set; }
}
