using Microsoft.AspNetCore.Mvc;
using webapp.Models;

namespace webapp.Controllers;
public class BaseController : Controller
{
    SiteProvider? provider;
    protected SiteProvider Provider =>
        provider ??= new (HttpContext.RequestServices.GetRequiredService<IConfiguration>());
}