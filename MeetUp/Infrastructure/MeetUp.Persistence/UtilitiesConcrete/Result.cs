using System.Net;
using MeetUp.Application.Abstractions.Utilities;

namespace MeetUp.Persistence.UtilitiesConcrete
{
    public class Result : IResult
    {
        public bool Status { get; }
        public Exception Exception { get; }
        public HttpStatusCode Code { get; }
        public string Message { get; }

        public Result(HttpStatusCode statusCode, string message = null, Exception exception = null)
        {
            switch ((int)statusCode)
            {
                case >= 100 and <= 103:
                case >= 200 and <= 299:
                case >= 300 and <= 308:
                    Status = true;
                    break;
                case >= 400 and <= 451:
                case >= 500 and <= 599:
                    Status = false;
                    break;
            }

            Code = statusCode;
            Message = message;
            Exception = exception;
        }

        public static Result Ok() => new(HttpStatusCode.OK);
        public static Result Ok(string message) => new(HttpStatusCode.OK, message);
        public static Result<T> Ok<T>(T value) => new(value, HttpStatusCode.OK);
        public static Result<T> Ok<T>(T value, string message) => new(value, HttpStatusCode.OK, message);

        public static Result BadRequest() => new(HttpStatusCode.BadRequest);
        public static Result BadRequest(Exception exception) => new(HttpStatusCode.BadRequest);
        public static Result BadRequest(string message) => new(HttpStatusCode.BadRequest, message);
        public static Result<T> BadRequest<T>(T value) => new(value, HttpStatusCode.BadRequest);
        public static Result<T> BadRequest<T>(T value, string message) => new(value, HttpStatusCode.BadRequest, message);

        public static Result Conflict() => new(HttpStatusCode.Conflict);
        public static Result Conflict(string message) => new(HttpStatusCode.Conflict, message);
        public static Result<T> Conflict<T>(T value) => new(value, HttpStatusCode.Conflict);
        public static Result<T> Conflict<T>(T value, string message) => new(value, HttpStatusCode.Conflict, message);

        public static Result Created() => new(HttpStatusCode.Created);
        public static Result Created(string message) => new(HttpStatusCode.Created, message);
        public static Result<T> Created<T>(T value) => new(value, HttpStatusCode.Created);
        public static Result<T> Created<T>(T value, string message) => new(value, HttpStatusCode.Created, message);


    }

    public sealed class Result<T> : Result, IResult<T>
    {
        public T Data { get; }

        public Result(T data, HttpStatusCode statusCode) : base(statusCode)
        {
            Data = data;
        }

        public Result(T data, HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
