using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebHojaCosto.Models.Response
{
    public class Rol
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("funcionalidades")]
        public string Funcionality { get; private set; }

        public string GetName()
        {
            return this.Name;
        }

        public string GetFuncionality()
        {
            return this.Funcionality;
        }
    }
}