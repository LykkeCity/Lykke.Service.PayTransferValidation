using System.Linq;
using Lykke.Common.Api.Contract.Responses;
using Lykke.Service.PayTransferValidation.Domain.Exceptions;

namespace Lykke.Service.PayTransferValidation.Domain
{
    public static class ExceptionExtensions
    {
        public static ErrorResponse ToErrorResponse(this InvalidInputException src)
        {
            var validationErrors = src.Errors.SelectMany(error =>
                error.MemberNames.Select(member => (Member: member, Message: error.ErrorMessage)));

            var errorResponse = ErrorResponse.Create(src.Message);

            foreach (var error in validationErrors)
            {
                errorResponse.AddModelError(error.Member, error.Message);
            }

            return errorResponse;
        }
    }
}
