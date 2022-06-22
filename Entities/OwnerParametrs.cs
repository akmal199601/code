namespace Entities;

public class OwnerParametrs : QueryStringParameters
{
    public string Name { get; set; }
    private const int maxPageSize = 50;//для ограничения 
    public int PageNUmber { get; set; } = 1;
    private int _pageSize = 10;

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}

public class QueryStringParameters
{
    public uint MinYearOfBirth { get; set; }
    public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;

    public bool ValidYearRange => MaxYearOfBirth > MinYearOfBirth;
}