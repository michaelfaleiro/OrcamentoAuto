namespace OrcamentoAuto.Core.Entities;
public class ItemCotacao : Entity
{
    public ItemCotacao(string sku, int quantidade, string nome)
    {
        Sku = sku;
        Quantidade = quantidade;
        Nome = nome;
    }

    public string Sku { get; private set; }
    public int Quantidade { get; private set; }
    public string Nome { get; private set; }

    public int MyProperty { get; private set; }
}
