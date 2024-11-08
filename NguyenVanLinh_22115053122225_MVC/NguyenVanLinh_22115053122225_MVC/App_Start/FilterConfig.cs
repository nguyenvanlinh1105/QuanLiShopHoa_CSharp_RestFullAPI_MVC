using System.Web;
using System.Web.Mvc;

namespace NguyenVanLinh_22115053122225_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
