//namespace Presentation.Mappers
//{
//    using System.Diagnostics.CodeAnalysis;
//    using Presentation.Models.Request;
//    using Presentation.Models.Response;

//    [ExcludeFromCodeCoverage]
//    public static class CreditMapper
//    {
//        public static Application.DTOs.CreditRequest ToApplication(this CreditRequest request)
//        {
//            if (request is null)
//            {
//                return null;
//            }

//            var aggregateDomain = new Application.DTOs.CreditRequest
//            {
//                Amount = request.Amount,
//                FirstDueDate = request.FirstDueDate,
//                InstallmentCount = request.InstallmentCount,
//                CreditType = request.CreditType,
//            };

//            return aggregateDomain;
//        }

//        public static CreditRequest ToPresentation(Application.DTOs.CreditRequest request)
//        {
//            if (request is null)
//            {
//                return null;
//            }

//            var aggregateDomain = new CreditRequest
//            {
//                Amount = request.Amount,
//                FirstDueDate = request.FirstDueDate,
//                InstallmentCount = request.InstallmentCount,
//                CreditType = request.CreditType,
//            };

//            return aggregateDomain;
//        }

//        public static Application.DTOs.CreditResponse ToApplication(this CreditResponse creditResponse)
//        {
//            if (creditResponse is null)
//            {
//                return null;
//            }

//            var response = new Application.DTOs.CreditResponse
//            {
//                Status = creditResponse.Status,
//                TotalAmount = creditResponse.TotalAmount,
//                TotalFees = creditResponse.TotalFees,
//            };

//            return response;
//        }

//        public static CreditResponse ToPresentation(this Application.DTOs.CreditResponse creditResponse)
//        {
//            if (creditResponse is null)
//            {
//                return null;
//            }

//            var response = new CreditResponse
//            {
//                Status = creditResponse.Status,
//                TotalAmount = creditResponse.TotalAmount,
//                TotalFees = creditResponse.TotalFees,
//            };

//            return response;
//        }
//    }
//}