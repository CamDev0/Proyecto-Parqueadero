   using Parking.Shared.Responses;

    namespace Parking.API.Services
    {
        public interface IApiService
        {
            Task<Response> GetListAsync<T>(string servicePrefix, string controller);
        }
    }


