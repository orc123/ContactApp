namespace ContactApp.Blazor.Dto;

public class PagedResultDto<T> where T : class
{
    public int TotalCount { get; set; }
    public List<T> Items { set; get; }

    public PagedResultDto()
    {
    }

    public PagedResultDto(List<T> items, int count)
    {
        TotalCount = count;
        Items = items;
    }
}

public class MetaData
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public long TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}