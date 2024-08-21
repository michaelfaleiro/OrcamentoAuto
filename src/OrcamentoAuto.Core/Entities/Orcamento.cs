namespace OrcamentoAuto.Core.Entities;
public class Orcamento : Entity
{

    public Orcamento(Cliente cliente, string status)
    {
        Cliente = cliente;
        Status = status;
        CreatedAt = DateTime.UtcNow;
    }

    public Cliente Cliente { get; private set; }
    public IEnumerable<ItemOrcamento> Itens { get; private set; } = [];
    public string Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void AdicionarItem(ItemOrcamento item)
    {
        Itens = Itens.Append(item);
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarCliente(Cliente cliente)
    {
        Cliente = cliente;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarItens(IEnumerable<ItemOrcamento> itens)
    {
        Itens = itens;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoverItem(ItemOrcamento item)
    {
        Itens = Itens.Where(i => i.Id != item.Id);
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarStatus(string status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }

    public decimal CalcularTotal()
    {
        return Itens.Sum(i => i.ValorVenda);
    }


}
