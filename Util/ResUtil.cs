namespace BertoniTestNoriarmanMVC.Util
{
    using BertoniTestNoriarmanMVC.Models;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class RestUtil : IRestUtil
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<RestUtilResponse> GetAsync(string url, string schema, string token)
        {
            RestUtilResponse _restResponse = new RestUtilResponse();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, token);
            var result = await _httpClient.GetAsync(url).ConfigureAwait(false);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _restResponse.Content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                _restResponse.Message = "OK";
                _restResponse.Success = true;
            }
            _restResponse.HttpStatusCode = result.StatusCode;

            return _restResponse;
        }

        public async Task<RestUtilResponse> GetAsync(string url)
        {
            RestUtilResponse _restResponse = new RestUtilResponse();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            var result = await _httpClient.GetAsync(url).ConfigureAwait(false);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _restResponse.Content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                _restResponse.Message = "OK";
                _restResponse.Success = true;
            }
            _restResponse.HttpStatusCode = result.StatusCode;

            return _restResponse;
        }

        public async Task<RestUtilResponse> PostAsync(string url, string datos, string schema, string token)
        {
            RestUtilResponse _restResponse = new RestUtilResponse();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, token);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var data = new StringContent(datos, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(url, data).ConfigureAwait(false);
            if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Created)
            {
                _restResponse.Content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                _restResponse.Message = "OK";
                _restResponse.Success = true;
            }
            _restResponse.HttpStatusCode = result.StatusCode;

            return _restResponse;
        }

        public async Task<RestUtilResponse> PostMailAsync(string url, string datos, string schema, string token)
        {
            RestUtilResponse _restResponse = new RestUtilResponse();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add(schema, token);
            var data = new StringContent(datos, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(url, data).ConfigureAwait(false);
            if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Created)
            {
                _restResponse.Content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                _restResponse.Message = "OK";
                _restResponse.Success = true;
            }
            _restResponse.HttpStatusCode = result.StatusCode;

            return _restResponse;
        }

        public async Task<RestUtilResponse> PostAsync(string url, string datos)
        {
            RestUtilResponse _restResponse = new RestUtilResponse();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var data = new StringContent(datos, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(url, data).ConfigureAwait(false);
            if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Created)
            {
                _restResponse.Content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                _restResponse.Message = "OK";
                _restResponse.Success = true;
            }
            _restResponse.HttpStatusCode = result.StatusCode;

            return _restResponse;
        }

        public async Task<bool> DownloadImage(string url, string path)
        {
            byte[] imageBytes = await _httpClient.GetByteArrayAsync(url).ConfigureAwait(false);

            string documentsPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);

            File.WriteAllBytes(path, imageBytes);

            return true;
        }

        public async Task<RestUtilResponse> UploadImage(string url, string path)
        {
            RestUtilResponse _restResponse = new RestUtilResponse();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            var multiForm = new MultipartFormDataContent();
            // add file and directly upload it
            FileStream fs = File.OpenRead(path);
            multiForm.Add(new StreamContent(fs), "file", Path.GetFileName(path));
            var response = await _httpClient.PostAsync(url, multiForm);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                _restResponse.Content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                _restResponse.Message = "OK";
                _restResponse.Success = true;
            }
            _restResponse.HttpStatusCode = response.StatusCode;

            return _restResponse;
        }
    }
}
