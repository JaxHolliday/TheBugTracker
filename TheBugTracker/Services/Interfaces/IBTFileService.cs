using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBugTracker.Services.Interfaces
{
    public interface IBTFileService
    {
        //accept file and convert to a byte array
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);

        //retreive from DB to convert to file
        public string ConvertByteArrayToFile(byte[] fileData, string extension);

        public string GetFileIcon(string file);

        public string FormatFileSize(long bytes);
    }
}
