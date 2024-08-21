namespace OrcamentoAuto.Core.Entities;
public class PrecoItemCotacao : Entity
{
    public PrecoItemCotacao(Fornecedor fornecedor, decimal precoCusto, decimal precoVenda, string observacao)
    {
        Fornecedor = fornecedor;
        PrecoCusto = precoCusto;
        PrecoVenda = precoVenda;
        Observacao = observacao;
        CreatedAt = DateTime.UtcNow;
    }

    public Fornecedor Fornecedor { get; private set; }
    public decimal PrecoCusto { get; private set; }
    public decimal PrecoVenda { get; private set; }
    public string Observacao { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(Fornecedor fornecedor, decimal precoCusto, decimal precoVenda, string observacao)
    {
        Fornecedor = fornecedor;
        PrecoCusto = precoCusto;
        PrecoVenda = precoVenda;
        Observacao = observacao;
        UpdatedAt = DateTime.UtcNow;
    }


}
