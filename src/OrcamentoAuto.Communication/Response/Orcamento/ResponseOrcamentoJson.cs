using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Communication.Response.ItemOrcamento;
using OrcamentoAuto.Communication.Response.Veiculo;

namespace OrcamentoAuto.Communication.Response.Orcamento;
public class ResponseOrcamentoJson
{
    public string Id { get; set; } = string.Empty;
    public ResponseClienteJson Cliente { get; set; } = new ResponseClienteJson();
    public ResponseVeiculoJson Veiculo { get; set; } = new ResponseVeiculoJson();
    public IList<ResponseItemOrcamentoJson> Itens { get; set; } = [];
    public string Status { get;  set; } = string.Empty;
    public string VendedorId { get; set; } = string.Empty;
    public DateTime CreatedAt { get;  set; }
    public DateTime? UpdatedAt { get;  set; }
}
