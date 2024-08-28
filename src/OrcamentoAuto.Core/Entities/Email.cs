namespace OrcamentoAuto.Core.Entities;
public class Email
{
    public Email(string endereco)
    {
        Endereco = endereco;
    }
    public string Endereco { get; private set; }

    public void Atualizar(string endereco)
    {
        Endereco = endereco;
    }
}
