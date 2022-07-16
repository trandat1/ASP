using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssimentASP.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
