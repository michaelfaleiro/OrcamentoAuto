using MongoDB.Bson.Serialization.Attributes;

namespace OrcamentoAuto.Core.Entities;

[BsonIgnoreExtraElements]
public class Veiculo : Entity
{
    public Veiculo(string modelo, string marca, string? anoModelo, string? anoFabricacao,
        string? placa, string? chassi, string? cor, string? combustível, string? renavam,
        string? motor, string? cambio)
    {
        Modelo = modelo;
        Marca = marca;
        AnoModelo = anoModelo;
        AnoFabricacao = anoFabricacao;
        Placa = placa;
        Chassi = chassi;
        Cor = cor;
        Combustível = combustível;
        Renavam = renavam;
        Motor = motor;
        Cambio = cambio;
        CreatedAt = DateTime.UtcNow;
    }

    public string Modelo { get; private set; }
    public string Marca { get; private set; }
    public string? AnoModelo { get; private set; }
    public string? AnoFabricacao { get; private set; }
    public string? Placa { get; private set; }
    public string? Chassi { get; private set; }
    public string? Cor { get; private set; }
    public string? Combustível { get; private set; }
    public string? Renavam { get; private set; }
    public string? Motor { get; private set; }
    public string? Cambio { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(string modelo, string marca, string? anoModelo, string? anoFabricacao,
        string? placa, string? chassi, string? cor, string? combustível, string? renavam,
        string? motor, string? cambio)
    {
        Modelo = modelo;
        Marca = marca;
        AnoModelo = anoModelo;
        AnoFabricacao = anoFabricacao;
        Placa = placa;
        Chassi = chassi;
        Cor = cor;
        Combustível = combustível;
        Renavam = renavam;
        Motor = motor;
        Cambio = cambio;
        UpdatedAt = DateTime.UtcNow;
    }
}
