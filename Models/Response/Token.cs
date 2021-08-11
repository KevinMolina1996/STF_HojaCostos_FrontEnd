using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebHojaCosto.Models.Response
{
    public class Token
    {
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; private set; }

        [JsonProperty("id_token")]
        public string IdToken { get; private set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        [JsonProperty("access_token")]
        public string AccesToken { get; private set; }

        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        [JsonProperty("scope")]
        public string Scope { get; private set; }

        public long GetExpisesIn()
        {
            return this.ExpiresIn;
        }

        public string GetRefreshToken()
        {
            return this.RefreshToken;
        }

        public string GetAccesToken()
        {
            return this.AccesToken;
        }

        public string GetTokenType()
        {
            return this.TokenType;
        }
    }
}