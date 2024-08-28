
namespace OrcamentoAuto.Core.Entities;
public class Fornecedor : Entity
{
    public Fornecedor(string razaoSocial, string nomeFantasia, string cnpj, string ie)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
        Ie = ie;
        Email = [];
        CreatedAt = DateTime.UtcNow;
    }

    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public string Ie { get; private set; }
    public IList<Email> Email { get; private set; } = [];
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(string razaoSocial, string nomeFantasia, string cnpj, string ie)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
        Ie = ie;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AdicionarEmail(string endereco)
    {
        Email.Add(new Email(endereco));
    }

    public void RemoverEmail(string endereco)
    {
        var email = Email.FirstOrDefault(x => x.Endereco == endereco);
        if (email == null)
            return;

        Email.Remove(email);
    }

    public void AtualizarEmail(string enderecoAntigo, string enderecoNovo)
    {
        var email = Email.FirstOrDefault(x => x.Endereco == enderecoAntigo);
        if (email == null)
            return;

        email.Atualizar(enderecoNovo);
    }
}
