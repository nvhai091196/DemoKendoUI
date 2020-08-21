using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiStudy.Presentation.Models
{
    public abstract class BaseWebViewPage : WebViewPage
    {
        public  string UrlApi = "http://localhost:39592/api/";
    }
    
}