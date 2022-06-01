
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Utilities
{
    public static class FileUtility
    {
        public static async Task<string> FileCreate(this IFormFile file,string root,string folder)
        {
            string Filename = Guid.NewGuid() + file.FileName;
            string path = Path.Combine(root, folder);
            string fullPath = Path.Combine(path, Filename);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Filename;
        }

        public static async void FileDelete(string image,string path,string imageName)
        {
            string fullPath = Path.Combine(path, imageName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);  
            }
        }
    }
}
