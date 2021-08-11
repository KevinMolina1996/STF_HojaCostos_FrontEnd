using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebHojaCosto.Models.Response
{
    public class User
    {
        [JsonProperty("username")]
        public string UserName { get; private set; }

        [JsonProperty("firstname")]
        public string FirstName { get; private set; }

        [JsonProperty("lastname")]
        public string LastName { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("enabled")]
        public string Enabled { get; private set; }

        public List<Rol> Roles { get; set; }

        public string GetUserName()
        {
            return this.UserName;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public string GetLastName()
        {
            return this.LastName;
        }

        public string GetEmail()
        {
            return this.Email;
        }

        public List<Rol> GetRoles()
        {
            return this.Roles;
        }

        public bool HasRole(string rol)
        {
            return this.Roles.Exists((Predicate<Rol>)(y => y.Name.ToString() == rol));
        }

        public bool HasPermissionByRol(string rol, string funcionality)
        {
            return this.Roles.Exists((Predicate<Rol>)(y => y.Name.ToString() == rol && y.Funcionality.Contains(funcionality)));
        }

        public bool HasPermission(string funcionality)
        {
            return this.Roles.Exists((Predicate<Rol>)(y => y.Funcionality.Contains(funcionality)));
        }
    }
}