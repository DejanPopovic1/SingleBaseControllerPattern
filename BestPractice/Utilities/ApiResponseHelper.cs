using BestPractice.Exceptions;
using System.Net;
using System.Net.NetworkInformation;

namespace BestPractice.Utilities;

public static class ApiResponseHelper
{

    //Ask Claude: In C# if you have a generic method do you have to always supply the type?
    //T Echo<T>(T value) => value;
    //// Explicit
    //string result = Echo<string>("hello");
    //// Inferred — compiler sees you passed a string
    //string result = Echo("hello");

    public static ApiResponse<T> CreateSuccessResponse<T>(T data, string message = "OK")
    {
        return new ApiResponse<T>(HttpStatusCode.OK, message, data);
    }

    public static ApiResponse<dynamic> CreateErrorResponse(HttpStatusCode statusCode, string message, ApiException? error = null)
    {
        return new ApiResponse<dynamic>(statusCode, message)
        {
            Success = false,
            Error = error?.ResponseDetail,
        };
    }
}
