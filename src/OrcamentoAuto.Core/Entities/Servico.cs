namespace OrcamentoAuto.Core.Entities;
public class Servico : Entity
{
    public Servico(string mecanicoId,string descricao, decimal valor, int quantidade, string orcamentoId)
    {
        MecanicoId = mecanicoId;
        Descricao = descricao;
        Valor = valor;
        Quantidade = quantidade;
        OrcamentoId = orcamentoId;
        CreatedAt = DateTime.UtcNow;
    }

    public string MecanicoId { get; private set; }
    public string Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public int Quantidade { get; private set; }
    public string OrcamentoId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }


    public void Atualizar(string mecanicoId, string descricao, decimal valor, int quantidade)
    {
        MecanicoId = mecanicoId;
        Descricao = descricao;
        Valor = valor;
        Quantidade = quantidade;
        UpdatedAt = DateTime.UtcNow;
    }
  
}
