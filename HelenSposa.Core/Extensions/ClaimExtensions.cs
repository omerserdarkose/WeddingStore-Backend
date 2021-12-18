using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims,string eMail)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, eMail));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameId)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, nameId));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role=> claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
