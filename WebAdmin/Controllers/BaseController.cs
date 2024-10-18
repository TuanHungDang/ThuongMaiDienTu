using Microsoft.AspNetCore.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers;
public class BaseController : Controller
{
    SiteProvider? provider;
    protected SiteProvider Provider =>
        provider ??= new (HttpContext.RequestServices.GetRequiredService<IConfiguration>());
}