using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace AppWebHojaCosto.Models.Json
{
    public static class JSONOutput
    {
        public static string GETJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public static string POSTJson(string url)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] data = encoder.GetBytes(url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            try
            {
                request.GetRequestStream().Write(data, 0, data.Length);

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public static string GETUrl(string strMetodo, Object[] parametros)
        {
            string URL = ConfigurationManager.AppSettings["ServerApiRest"].ToString();
            if (!String.IsNullOrEmpty(strMetodo))
            {
                URL = URL + strMetodo;

                if (parametros != null)
                {
                    if (parametros.Count() > 0)
                    {
                        URL = URL + "?";

                        foreach (var index in parametros)
                        {
                            URL = URL + index.ToString();
                        }
                    }
                }
            }

            return URL;
        }
    }
}