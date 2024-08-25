namespace OrcamentoAuto.Communication.Request.Orcamento;
public class UpdateItemOrcamentoRequest : AdicionarItemOrcamentoRequest
{
    public string ItemId { get; set; } = string.Empty;
}
