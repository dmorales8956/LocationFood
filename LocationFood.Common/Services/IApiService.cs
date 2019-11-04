using LocationFood.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LocationFood.Common.Services
{
    public interface IApiService
    {
        Task<Response<CustomerResponse>> GetCustomerByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

        Task<bool> CheckConnection(string url);

        Task<Response<object>> RegisterUserAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            UserRequest userRequest);

        Task<Response<object>> RecoverPasswordAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            EmailRequest emailRequest);

        Task<Response<object>> PutAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            T model,
            string tokenType,
            string accessToken);

        Task<Response<object>> ChangePasswordAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            ChangePasswordRequest changePasswordRequest,
            string tokenType,
            string accessToken);

        Task<Response<object>> GetListAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken);
    }
}
