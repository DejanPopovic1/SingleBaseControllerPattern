using BestPractice.Exceptions;
using System.Net;
using System.Net.NetworkInformation;

namespace BestPractice.Utilities;

public static class ApiResponseHelper
{
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
