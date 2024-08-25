using MongoDB.Bson.Serialization.Attributes;

namespace OrcamentoAuto.Core.Entities;

[BsonIgnoreExtraElements]
public class ItemOrcamento : Entity
{
    public ItemOrcamento(string produtoId, string sku, int quantidade, string nome, decimal valorVenda)
    {
        ProdutoId = produtoId;
        Sku = sku;
        Quantidade = quantidade;
        Nome = nome;
        ValorVenda = valorVenda;
        CreatedAt = DateTime.UtcNow;
    }

    public string ProdutoId { get; private set; }
    public string Sku { get; private set; }
    public int Quantidade { get; private set; }
    public string Nome { get; private set; }
    public decimal ValorVenda { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(int quantidade, decimal valorVenda)
    {
        Quantidade = quantidade;
        ValorVenda = valorVenda;
        UpdatedAt = DateTime.UtcNow;
    }


}
