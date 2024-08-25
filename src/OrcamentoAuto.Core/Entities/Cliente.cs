
using MongoDB.Bson.Serialization.Attributes;

namespace OrcamentoAuto.Core.Entities;

[BsonIgnoreExtraElements]
public class Cliente : Entity
{
    public Cliente(string nome, string telefone, string? cpfCnpj, string? rgIe, string? email)
    {
        Nome = nome;
        Telefone = telefone;
        CpfCnpj = cpfCnpj ?? string.Empty;
        RgIe = rgIe ?? string.Empty;
        Email = email ?? string.Empty;
        Veiculos = [];
        CreatedAt = DateTime.UtcNow;
    }

    public string Nome { get;private set; }
    public string Email { get;private set; }
    public string Telefone { get;private set; }
    public string CpfCnpj { get;private set; }
    public string RgIe { get;private set; }
    public IList<Veiculo> Veiculos { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }


    public void Atualizar(string nome, string telefone, string? cpfCnpj, string? rgIe, string? email)
    {
        Nome = nome;
        Telefone = telefone;
        CpfCnpj = cpfCnpj ?? string.Empty;
        RgIe = rgIe ?? string.Empty;
        Email = email ?? string.Empty;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AtualizarEmail(string email)
    {
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        if (Veiculos == null)
            Veiculos = [];

        Veiculos.Add(veiculo);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoverVeiculo(Veiculo veiculo)
    {
        Veiculos.Remove(veiculo);
        UpdatedAt = DateTime.UtcNow;
    }


}
