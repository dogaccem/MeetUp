using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.Abstractions.Utilities
{
    public interface IResult
    {
        Exception Exception { get; }
        HttpStatusCode Code { get; }
        string Message { get; }
    }

    public interface IResult<out T> : IResult
    {
        bool Status { get; }
        T Data { get; }
    }
}
