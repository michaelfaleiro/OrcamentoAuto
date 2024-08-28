using OrcamentoAuto.Core.Enums;

namespace OrcamentoAuto.Core.Entities;
public class Funcionario : Entity
{
    public Funcionario(string nome, string email, string telefone, ETipoFuncionario tipoFuncionario)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        TipoFuncionario = tipoFuncionario;
        CreatedAt = DateTime.UtcNow;
    }

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public ETipoFuncionario TipoFuncionario { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Atualizar(string nome, string email, string telefone, ETipoFuncionario tipoFuncionario)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        TipoFuncionario = tipoFuncionario;
        UpdatedAt = DateTime.UtcNow;
    }
}
