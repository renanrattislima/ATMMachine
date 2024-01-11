namespace Presentation.Mappers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Application.DTOs;
    using Application.Mappers;
    using Presentation.Models.Request;

    [ExcludeFromCodeCoverage]
    public static class LoanMapper
    {

        public static PaperMoney ToApplication(this PaperMoneyRequest request)
        {
            if (request is null)
            {
                return null;
            }

            var response = new PaperMoney
            {
                Value = request.Value,
                SerialNumber = request.SerialNumber,
            };

            return response;
        }

    }
}