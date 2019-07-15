using Common.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _environment;

        public ImageService(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> UploadFile(IEnumerable<IFormFile> files, string root)
        {

            try
            {
                string upload = Path.Combine(_environment.WebRootPath, root + "normalimage\\");
                string filename = "";
                foreach (IFormFile file in files)
                {
                    filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    using (FileStream fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                }

                ///////////تغییر سایز عکس و ذخیره
                //InsertShowImage.ImageResizer img = new InsertShowImage.ImageResizer();
                //img.Resize(upload + filename, _environment.WebRootPath + root+ "thumbnailimage" + filename);
                return filename;

            }
            catch (Exception ex)
            {

                throw new BadRequestException(ex.Message);
            }


        }
    }
}