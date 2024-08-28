using MongoDB.Bson.Serialization.Attributes;

namespace OrcamentoAuto.Core.Entities;

[BsonIgnoreExtraElements]
public class Orcamento : Entity
{

    public Orcamento(Cliente cliente, Veiculo veiculo, string status, string vendedorId)
    {
        Cliente = cliente;
        Veiculo = veiculo;
        Status = status;
        VendedorId = vendedorId;
        Itens = [];
        Servicos = [];
        CreatedAt = DateTime.UtcNow;
    }

    public Cliente Cliente { get; private set; }
    public Veiculo Veiculo { get; private set; }
    public IList<ItemOrcamento> Itens { get; private set; }
    public IList<Servico> Servicos { get; private set; }
    public string Status { get; private set; }
    public string VendedorId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void AdicionarItem(ItemOrcamento item)
    {
        Itens.Add(item);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoverItem(ItemOrcamento item)
    {
        Itens.Remove(item);
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarCliente(Cliente cliente)
    {
        Cliente = cliente;
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

    public void AtualizarVeiculo(Veiculo veiculo)
    {
        Veiculo = veiculo;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarVendedor(string vendedorId)
    {
        VendedorId = vendedorId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AdicionarServico(Servico servico)
    {
        Servicos.Add(servico);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoverServico(Servico servico)
    {
        Servicos.Remove(servico);
        UpdatedAt = DateTime.UtcNow;
    }

}
