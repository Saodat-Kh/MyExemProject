using System.Net;

namespace Application.Responses;

public class PaginationResponses<T> : Response<T>
{
    public int PageNumber {get; set;}
    public int PageSize {get; set;}
    public int TotalPages {get; set;}
    public int TotalRecords {get; set;}

    public PaginationResponses(T data,int totalRecords,int pageNumber, int pageSize) : base(data)
    {
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public PaginationResponses(HttpStatusCode statusCode,string message) : base(statusCode, message)
    {
        
    }
}