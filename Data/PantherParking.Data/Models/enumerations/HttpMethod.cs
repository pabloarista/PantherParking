using System.ComponentModel;

namespace PantherParking.Data.Models.enumerations
{
    public enum HttpMethod
    {
        [Description("POST")]
        Post = 1,
        [Description("GET")]
        Get = 2,
        [Description("DELETE")]
        Delete = 4,
        [Description("PATCH")]
        Patch = 8,
        [Description("PUT")]
        Put = 16,
    }
}