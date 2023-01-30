using System.Net;
using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Models.Shared;
using Hermes.Frameworks.Functional.Results;

namespace Hermes.Client.Web.Mappings;

public static class ErrorMappings
{
    public static ErrorViewModel ToErrorViewModel(this ErrorMessage errorMessage) =>
        new()
        {
            StatusCode = errorMessage.Data[nameof(ErrorViewModel.StatusCode)] is HttpStatusCode code
                ? ((int)code)
                : throw new InvalidDataException(ErrorCodes.InvalidStatusCode),
            Message = errorMessage
        };
}