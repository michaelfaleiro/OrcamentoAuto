namespace OrcamentoAuto.Communication.Response;
public class Response<TData> where TData : class
{
    public TData Data { get; set; } = default!;

}
