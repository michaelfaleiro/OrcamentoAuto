
namespace OrcamentoAuto.Core.Entities;
public class Fornecedor : Entity
{
    public Fornecedor(string razaoSocial, string nomeFantasia, string cnpj, string ie, IEnumerable<Email> email)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
        Ie = ie;
        Email = email;
        CreatedAt = DateTime.UtcNow;
    }

    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public string Ie { get; private set; }
    public IEnumerable<Email> Email { get; private set; } = [];
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(string razaoSocial, string nomeFantasia, string cnpj, string ie, IEnumerable<Email> email)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
        Ie = ie;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

}
