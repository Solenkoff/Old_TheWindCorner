namespace TheWindCorner.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        protected bool IsGuidValid(string? id, ref Guid entityGuid)
        {
            if(String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out entityGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
