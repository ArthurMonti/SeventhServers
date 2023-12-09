using System.Net;

namespace SeventhServers.Domain
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public int StatusCode { get; protected set; }
        public bool IsSuccess { get; protected set; } = true;
        public string ErrorCode { get; protected set; }


        public static Result<T> Created(T data)
        {
            return new() { StatusCode = (int)HttpStatusCode.Created, Data = data };
        }

        public static Result<T> Success(T data)
        {
            return new() { StatusCode = (int)HttpStatusCode.OK, Data = data };
        }

        public static Result<T> NoContent()
        {
            return new()
            {
                IsSuccess = false,
                StatusCode = (int)HttpStatusCode.NoContent
            };
        }



        public static Result<T> Failure(string errorCode)
        {
            return new()
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }

        public static Result<T> Unauthorized()
        {
            return new()
            {
                IsSuccess = false,
                StatusCode = (int)HttpStatusCode.Unauthorized
            };
        }
    }
}