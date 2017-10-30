using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace lab29_brian.Models
{
    public class BriansOnly : IAuthorizationRequirement
    {
    }
}
