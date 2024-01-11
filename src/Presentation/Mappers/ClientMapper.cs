namespace Presentation.Mappers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Models;
    using Presentation.Models.Request;
    using Presentation.Models.Response;

    [ExcludeFromCodeCoverage]
    public static class ClientMapper
    {
        public static Application.DTOs.Client ToApplication(this ClientRequest request)
        {
            if (request is null)
            {
                return null;
            }

            var aggregateDomain = new Application.DTOs.Client
            {
                Id = Guid.NewGuid(),
                CPF = request.CPF,
                Name = request.Name,
                Cellphone = request.Cellphone,
                UF = request.UF,
            };

            return aggregateDomain;
        }

        public static Application.DTOs.Client ToApplication(this Client clientResponse)
        {
            if (clientResponse is null)
            {
                return null;
            }

            var response = new Application.DTOs.Client
            {
                Id = Guid.NewGuid(),
                CPF = clientResponse.CPF,
                Name = clientResponse.Name,
                Cellphone = clientResponse.Cellphone,
                UF = clientResponse.UF,
            };

            return response;
        }

        public static Client ToDomain(this Application.DTOs.Client clientResponse)
        {
            if (clientResponse is null)
            {
                return null;
            }

            var response = new Client
            {
                Id = Guid.NewGuid(),
                CPF = clientResponse.CPF,
                Name = clientResponse.Name,
                Cellphone = clientResponse.Cellphone,
                UF = clientResponse.UF,
            };

            return response;
        }

        public static Client ToDomain(this ClientRequest clientResponse)
        {
            if (clientResponse is null)
            {
                return null;
            }

            var response = new Client
            {
                Id = Guid.NewGuid(),
                CPF = clientResponse.CPF,
                Name = clientResponse.Name,
                Cellphone = clientResponse.Cellphone,
                UF = clientResponse.UF,
            };

            return response;
        }

        public static Client ToDomain(this ClientUpdateRequest clientResponse)
        {
            if (clientResponse is null)
            {
                return null;
            }

            var response = new Client
            {
                Id = clientResponse.Id,
                CPF = clientResponse.CPF,
                Name = clientResponse.Name,
                Cellphone = clientResponse.Cellphone,
                UF = clientResponse.UF,
            };

            return response;
        }
    }
}