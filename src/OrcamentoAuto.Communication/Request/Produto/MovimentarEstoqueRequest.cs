using OrcamentoAuto.Communication.Enums;

namespace OrcamentoAuto.Communication.Request.Produto;
public class MovimentarEstoqueRequest
{
    public string ProdutoId { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public ETipoMovimentacaoEstoque TipoMovimentacaoEstoque { get; set; }
    public string FornecedorId { get; set; } = string.Empty;
    public string OrcamentoId { get; set; } = string.Empty;

}
