using MongoDB.Bson.Serialization.Attributes;
using OrcamentoAuto.Core.Enums;

namespace OrcamentoAuto.Core.Entities;

[BsonIgnoreExtraElements]
public class MovimentacaoEstoque : Entity
{
    public MovimentacaoEstoque(string produtoId,  int quantidade, ETipoMovimentacaoEstoque tipoMovimentacaoEstoque, string fornecedorId, string orcamentoId)
    {
        ProdutoId = produtoId;
        TipoMovimentacaoEstoque = tipoMovimentacaoEstoque;
        Quantidade = quantidade;
        FornecedorId = string.Empty;
        OrcamentoId = string.Empty;

        if (tipoMovimentacaoEstoque == ETipoMovimentacaoEstoque.Entrada)
            SetFornecedorId(fornecedorId);
        else if (tipoMovimentacaoEstoque == ETipoMovimentacaoEstoque.Saida)
            SetOrcamentoId(orcamentoId);
    }

    public string ProdutoId { get; private set; }
    public string FornecedorId { get; private set; }
    public string OrcamentoId { get; private set; }
    public ETipoMovimentacaoEstoque TipoMovimentacaoEstoque { get; private set; }
    public int Quantidade { get; private set; }


    public void SetFornecedorId(string fornecedorId)
    {
        FornecedorId = fornecedorId;
    }

    public void SetOrcamentoId(string orcamentoId)
    {
        OrcamentoId = orcamentoId;
    }
}
