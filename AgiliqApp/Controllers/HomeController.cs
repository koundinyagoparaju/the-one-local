using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiliqApp.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace AgiliqApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCode()
        {
            GetCodeModel gcm = new GetCodeModel();
            gcm.client_id = "KZMA1XOCwrhxF70VDMFTJ25gg1QPsJPHNunZL7vsoHHKQAT1Gj";
            gcm.redirect_uri = "http://54.84.112.141/Home/GetAuthToken";
            gcm.state = "12345678";
            return View(gcm);
            //return View();
        }
        public ActionResult GetAuthToken(string state="",string code="")
        {          
                GetCodeModel gcm = new GetCodeModel();
                gcm.client_id = "KZMA1XOCwrhxF70VDMFTJ25gg1QPsJPHNunZL7vsoHHKQAT1Gj";
                gcm.client_secret = "Um0Pg8upfWaA4GQPWOJ1KvzT5jctbD3U1EpAY1Y0H8KFZBjS1Z";
                gcm.redirect_uri = "http://54.84.112.141/Home/GetAuthToken";
                gcm.state = state;
                gcm.code = code;
                string requestParams = "client_id="+gcm.client_id+"&client_secret="+gcm.client_secret+"&code="+gcm.code+"&redirect_uri="+gcm.redirect_uri+"&state="+gcm.state;                
                string requestUri = "http://join.agiliq.com/oauth/access_token/";
                Dictionary<string, string> response = GetAsync(requestUri, requestParams);
                gcm.access_token = response["access_token"];
                return View("Apply", gcm);
               // return View(gcm);
            
        }
        public ActionResult Apply(string access_token, string scope, string token_type)
        {
            GetCodeModel gcm = new GetCodeModel();
            gcm.access_token = access_token;
            return View(gcm);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        

public Dictionary<string,string> GetAsync(string uri, string requestParams)
{
    WebClient wc = new WebClient();
   // wc.Headers[HttpRequestHeader.ContentType] = "multipart/form-data";
    //wc.UploadString()
        string HtmlResult = wc.UploadString(uri,requestParams);
    
   FileStream fs = new FileStream("c:\\inetpub\\wwwroot\\log.txt", FileMode.Create);
  
    try
    {
        fs.Write(System.Text.Encoding.UTF8.GetBytes(HtmlResult), 0, System.Text.Encoding.UTF8.GetByteCount(HtmlResult));
        return (Dictionary<string, string>)JsonConvert.DeserializeObject(HtmlResult, typeof(Dictionary<string, string>));
    }
    catch(Exception ee)
    {
        
        return new Dictionary<string, string>();
    }
    
}

    }
}
