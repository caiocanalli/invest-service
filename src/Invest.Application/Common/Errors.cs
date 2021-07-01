using Invest.Domain.Common;

namespace Invest.Application.Common
{
    public static class Errors
    {
        public static class Domain
        {
            public static Error UnprocessableEntity(string message = null)
            {
                var entityMessage = string.IsNullOrEmpty(message) ? "" : $" : {message}";
                return new Error("unprocessable.entity", $"Unprocessable entity{entityMessage}");
            }
        }
    }
}