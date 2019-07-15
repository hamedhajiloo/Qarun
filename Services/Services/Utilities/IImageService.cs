using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IImageService
    {
        Task<string> UploadFile(IEnumerable<IFormFile> files, string root);

    }
}
