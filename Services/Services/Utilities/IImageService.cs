using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services.Utilities
{
    public interface IImageService
    {
        Task<string> UploadFile(IEnumerable<IFormFile> files, string root);

    }
}
