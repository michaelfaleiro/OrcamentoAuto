namespace OrcamentoAuto.Core.Entities;
public class ItemOrcamento : Entity
{
    public ItemOrcamento(string sku, int quantidade, string nome, decimal valorVenda)
    {
        Sku = sku;
        Quantidade = quantidade;
        Nome = nome;
        ValorVenda = valorVenda;
        CreatedAt = DateTime.UtcNow;
    }

    public string Sku { get; private set; }
    public int Quantidade { get; private set; }
    public string Nome { get;private set; }
    public decimal ValorVenda { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(string sku, int quantidade, string nome, decimal valorVenda)
    {
        Sku = sku;
        Quantidade = quantidade;
        Nome = nome;
        ValorVenda = valorVenda;
        UpdatedAt = DateTime.UtcNow;
    }
       

}
