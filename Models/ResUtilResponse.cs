using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BertoniTestNoriarmanMVC.Models
{
    public class RestUtilResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public string Content { get; set; }
        public bool Success { get; set; }
    }
}