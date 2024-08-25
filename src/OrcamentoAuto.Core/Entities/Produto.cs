namespace OrcamentoAuto.Core.Entities;
public class Produto : Entity
{
    public Produto(string sku, string descricao, string marca, decimal valorCusto, decimal valorVenda)
    {
        Sku = sku;
        Descricao = descricao;
        Marca = marca;
        ValorCusto = valorCusto;
        ValorVenda = valorVenda;
        CreatedAt = DateTime.UtcNow;
        Ativo = true;
    }

    public string Sku { get; private set; }
    public string Descricao { get; private set; }
    public string Marca { get; private set; }
    public decimal ValorCusto { get; private set; }
    public decimal ValorVenda { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(string sku, string descricao, string marca, decimal valorCusto, decimal valorVenda)
    {
        Sku = sku;
        Descricao = descricao;
        Marca = marca;
        ValorCusto = valorCusto;
        ValorVenda = valorVenda;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtivarProduto()
    {
        Ativo = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void DesativarProduto()
    {
        Ativo = false;
        UpdatedAt = DateTime.UtcNow;
    }

}
