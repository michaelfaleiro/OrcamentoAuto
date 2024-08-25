namespace OrcamentoAuto.Communication.Response;
public class PagedResponse<TData>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int TotalCount { get; set; }
    public IEnumerable<TData> Data { get; set; } = default!;
}
