using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LocationFood.Web.Helpers
{
    public interface IImageHerlper
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
    }
}