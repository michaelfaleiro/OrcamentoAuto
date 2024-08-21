namespace OrcamentoAuto.Core.Entities;
public class Cotacao : Entity
{
    public Cotacao(string orcamentoId)
    {
        OrcamentoId = orcamentoId;
    }

    public string OrcamentoId { get; private set; }
    public IEnumerable<ItemCotacao> Itens { get; private set; } = [];
}
