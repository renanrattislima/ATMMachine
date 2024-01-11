namespace Application.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Application.DTOs;
    using Application.DTOs.Enums;

    [ExcludeFromCodeCoverage]
    public static class PaperMoneyMapper
    {
        public static Domain.Models.PaperMoney ToDomain(this PaperMoney request)
        {
            if (request is null)
            {
                return null;
            }

            var aggregateDomain = new Domain.Models.PaperMoney
            {
                Value = request.Value,
                SerialNumber = request.SerialNumber,
                RegisterDate = DateTime.UtcNow,
                isWithdrawn = false,
            };

            return aggregateDomain;
        }
        public static IEnumerable<Domain.Models.PaperMoney> ToDto(this IEnumerable<PaperMoney> variantInfos)
        {
            return variantInfos.Select(v => v?.ToDomain());
        }


        public static Application.DTOs.PaperMoney ToApplication(this Domain.Models.PaperMoney request)
        {
            if (request is null)
            {
                return null;
            }

            var aggregateDomain = new Application.DTOs.PaperMoney
            {
                Value = request.Value,
                SerialNumber = request.SerialNumber,
                RegisterDate = DateTime.UtcNow,
                isWithdrawn = false,
            };

            return aggregateDomain;
        }
        public static IEnumerable<Application.DTOs.PaperMoney> ToApplication(this IEnumerable<Domain.Models.PaperMoney> variantInfos)
        {
            return variantInfos.Select(v => v?.ToApplication());
        }


    }
}