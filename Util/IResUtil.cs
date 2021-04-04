using BertoniTestNoriarmanMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniTestNoriarmanMVC.Util
{
    public interface IRestUtil
    {
        Task<RestUtilResponse> GetAsync(string url, string schema, string token);
        Task<RestUtilResponse> GetAsync(string url);
        Task<RestUtilResponse> PostAsync(string url, string datos, string schema, string token);
        Task<RestUtilResponse> PostMailAsync(string url, string datos, string schema, string token);
        Task<RestUtilResponse> PostAsync(string url, string datos);
        Task<bool> DownloadImage(string url, string path);
        Task<RestUtilResponse> UploadImage(string url, string path);
    }
}
