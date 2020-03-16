 namespace apicore.Domain.Resources
{
    public class ApiResponse<T>{ 
            public int code {get;set;}
            public string message {get;set;}
            public T data {get;set;}
    }
}