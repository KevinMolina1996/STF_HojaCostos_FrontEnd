using AppWebHojaCosto.Models.Response;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppWebHojaCosto.Controllers
{
    public class OAuthController : Controller
    {
        private Token token = new Token();
        private User user = new User();

        public ActionResult Authorize()
        {
            Guid state = Guid.NewGuid();

            return new RedirectResult(GetAuthorizationUrl(state.ToString()));
        }

        private static string GetAuthorizationUrl(string state)
        {
            UriBuilder uriBuilder = new UriBuilder(ConfigurationManager.AppSettings["AuthUrl"]);
            System.Collections.Specialized.NameValueCollection queryParams = HttpUtility.ParseQueryString(uriBuilder.Query ?? string.Empty);

            queryParams["client_id"] = ConfigurationManager.AppSettings["ClientAppId"];
            queryParams["client_secret"] = ConfigurationManager.AppSettings["ClientAppSecret"];
            queryParams["response_type"] = "code";
            queryParams["state"] = state;
            //queryParams["scope"] = ConfigurationManager.AppSettings["Scope"];
            //queryParams["redirect_uri"] = ConfigurationManager.AppSettings["CallbackUrl"];

            uriBuilder.Query = queryParams.ToString();

            return uriBuilder.ToString();
        }

        private static string EncodeTo64(string toEncode)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(toEncode));
        }

        public async Task<ActionResult> Callback(string code, Guid state)
        {
            JObject jobject = new JObject();
            JObject jobjectUser = new JObject();
            using (HttpClient httpClient = new HttpClient())
            {
                string parameter = EncodeTo64(ConfigurationManager.AppSettings["ClientAppId"] + ":" + ConfigurationManager.AppSettings["ClientAppSecret"]);
                string uriString = ConfigurationManager.AppSettings["TokenUrl"] + "?client_id=" + ConfigurationManager.AppSettings["ClientAppId"] + "&grant_type=authorization_code&code=" + code + "&redirect_uri="
                    + HttpUtility.UrlEncode(ConfigurationManager.AppSettings["CallbackUrl"], Encoding.UTF8);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", parameter);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(uriString),
                    Method = new HttpMethod("POST")
                };

                using (Task<HttpResponseMessage> task = httpClient.SendAsync(request))
                {
                    string str = task.Result.Content.ReadAsStringAsync().Result.ToString();
                    if (task.Result.IsSuccessStatusCode)
                    {
                        token = JsonConvert.DeserializeObject<Token>(str);
                        jobject = JObject.Parse(str);
                        jobject.Add("Status", JToken.FromObject("Ok"));
                        jobject.Add("Message", JToken.FromObject("Respuesta Exitosa"));
                        user = JsonConvert.DeserializeObject<User>(UserInfo().ToString());

                        AuthenticationProperties options = new AuthenticationProperties();

                        options.AllowRefresh = false;
                        options.IsPersistent = true;

                        options.ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(token.ExpiresIn.ToString()));

                        Claim[] claims = new[]
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim("FirstName", user.FirstName),
                            new Claim("LastName", user.LastName),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim("Permission", GetUserpermissions().ToString()),
                            new Claim("AcessToken", string.Format("Bearer {0}", token.AccesToken)),
                            new Claim("RefreshToken", string.Format("Bearer {0}", token.RefreshToken)),
                            new Claim("ExpireIn", token.ExpiresIn.ToString()),
                        };

                        ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie");

                        Request.GetOwinContext().Authentication.SignIn(options, identity);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ValidarTiempo()
        {
            ClaimsIdentity claims = (ClaimsIdentity)HttpContext.User.Identity;
            //if (!claims.IsAuthenticated)
            //{
            //    HttpContext.GetOwinContext().Authentication.SignOut();
            //    Guid state = Guid.NewGuid();
            //    string url = "X";//GetAuthorizationUrl(state.ToString());
            //    return Json(new { ruta = url }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
                string usuario = GetSpecificClaim(claims, "FirstName") + " " + GetSpecificClaim(claims, "LastName");
                string permisos = GetSpecificClaim(claims, "Permission");
                return Json(new { usuario, permisos }, JsonRequestBehavior.AllowGet);
            //}
        }

        public static string GetSpecificClaim(ClaimsIdentity claimsIdentity, string claimType)
        {
            Claim claim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == claimType);

            return (claim != null) ? claim.Value : string.Empty;
        }

        public JObject UserInfo()
        {
            JObject jobject = new JObject();
            string error = null;
            if (!string.IsNullOrEmpty(token.AccesToken))
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string userInfoEndpoint = ConfigurationManager.AppSettings["ProfileUrl"];
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccesToken);
                    httpClient.DefaultRequestHeaders.Add("access_token", token.AccesToken);
                    HttpRequestMessage request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(userInfoEndpoint),
                        Method = new HttpMethod("GET")
                    };
                    using (Task<HttpResponseMessage> task = httpClient.SendAsync(request))
                    {
                        string str = task.Result.Content.ReadAsStringAsync().Result.ToString();
                        if (task.Result.IsSuccessStatusCode)
                        {
                            user = JsonConvert.DeserializeObject<User>(str);
                            jobject = JObject.Parse(str);
                            jobject.Add("Status", JToken.FromObject("Ok"));
                            jobject.Add("Message", JToken.FromObject("Respuesta Exitosa"));
                        }
                        else
                        {
                            jobject = JObject.Parse(str);
                            jobject.Add("Status", JToken.FromObject("Error"));
                            jobject.Add("Message", JToken.FromObject("Error al intentar obtener informacíon de usuario"));
                        }
                    }
                }
            }
            else
            {
                error = "Invalid refresh token";
            }

            if (!string.IsNullOrEmpty(error))
            {
                ViewBag.Error = error;
            }

            return jobject;
        }

        public JObject GetUserpermissions()
        {
            JObject jobject = new JObject();
            string error = null;
            if (!string.IsNullOrEmpty(token.AccesToken))
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string userInfoEndpoint = ConfigurationManager.AppSettings["PermissionsUrl"];
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccesToken);
                    httpClient.DefaultRequestHeaders.Add("username", user.UserName);
                    httpClient.DefaultRequestHeaders.Add("client_id", ConfigurationManager.AppSettings["ClientAppId"]);
                    HttpRequestMessage request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(userInfoEndpoint),
                        Method = new HttpMethod("GET")
                    };
                    using (Task<HttpResponseMessage> task = httpClient.SendAsync(request))
                    {
                        string str = task.Result.Content.ReadAsStringAsync().Result.ToString();
                        if (task.Result.IsSuccessStatusCode)
                        {
                            JArray jarray = JArray.Parse(str);
                            jobject.Add("Permissions", jarray);
                            jobject.Add("Status", JToken.FromObject("Ok"));
                            jobject.Add("Message", JToken.FromObject("Respuesta Exitosa"));

                            user.Roles = JsonConvert.DeserializeObject<List<Rol>>(str);
                        }
                        else
                        {
                            jobject = JObject.Parse(str);
                            jobject.Add("Status", JToken.FromObject("Error"));
                            jobject.Add("Message", JToken.FromObject("Error al intentar obtener informacíon de usuario"));
                        }
                    }
                }
            }
            else
            {
                error = "Invalid refresh token";
            }

            if (!string.IsNullOrEmpty(error))
            {
                ViewBag.Error = error;
            }

            return jobject;
        }

        public ActionResult Logout()
        {
            Guid state = Guid.NewGuid();

            JObject jobject = new JObject();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    ClaimsIdentity claims = (ClaimsIdentity)HttpContext.User.Identity;
                    String token = GetSpecificClaim(claims, "AcessToken").Replace("Bearer", "");
                    string parameter = EncodeTo64(ConfigurationManager.AppSettings["ClientAppId"] + ":" + ConfigurationManager.AppSettings["ClientAppSecret"]);
                    string uriString = ConfigurationManager.AppSettings["RevokenToken"] + "/" + token.Trim();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", parameter);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                    HttpRequestMessage request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(uriString),
                        Method = new HttpMethod("POST")
                    };
                    using (Task<HttpResponseMessage> task = httpClient.SendAsync(request))
                    {
                        string str = task.Result.Content.ReadAsStringAsync().Result.ToString();
                        if (task.Result.IsSuccessStatusCode)
                        {
                            HttpCookie aCookie;
                            string cookieName;
                            int limit = Request.Cookies.Count;
                            for (int i = 0; i < limit; i++)
                            {
                                cookieName = Request.Cookies[i].Name;
                                aCookie = new HttpCookie(cookieName);
                                aCookie.Value = null;
                                aCookie.Expires = DateTime.Now.AddDays(-1); // make it expire yesterday
                                Response.Cookies.Add(aCookie); // overwrite it
                            }

                            jobject.Add("Status", JToken.FromObject("Ok"));
                            jobject.Add("Message", JToken.FromObject(str));
                            HttpContext.GetOwinContext().Authentication.SignOut();
                            return Json(new { url = Url.Action("Index", "Login") }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            jobject = JObject.Parse(str);
                            jobject.Add("Status", JToken.FromObject("Error"));
                            jobject.Add("Message", JToken.FromObject("Error al intentar remover el token"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                jobject.Add("Status", JToken.FromObject("Error"));
                jobject.Add("Message", JToken.FromObject(ex.ToString()));
            }

            return Json(new { url = GetAuthorizationUrl(state.ToString()) }, JsonRequestBehavior.AllowGet);
        }

    }
}