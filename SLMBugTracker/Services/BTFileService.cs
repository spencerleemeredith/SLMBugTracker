﻿using Microsoft.AspNetCore.Http;
using SLMBugTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Services
{
    public class BTFileService : IBTFileService
    {
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };


        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            try
            {
                string imageBase64Data = Convert.ToBase64String(fileData);
                return string.Format($"data:image/{extension};base64,{imageBase64Data}");
            }

            catch (Exception)
            {
                throw;
            }
        }


        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public string FormatFileSize(long bytes)
        {
            throw new NotImplementedException();
        }

        public string GetFileIcon(string file)
        {
            throw new NotImplementedException();
        }
    }
}
