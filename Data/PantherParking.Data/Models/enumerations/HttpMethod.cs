using System.ComponentModel;

namespace PantherParking.Data.Models.enumerations
{
    public enum HttpMethod
    {
        [Description("HTTP POST")]
        POST = 1,
        [Description("HTTP GET")]
        GET = 2,
        [Description("HTTP DELETE")]
        DELETE = 4,
        [Description("HTTP PATCH")]
        PATCH = 8,
    }
}