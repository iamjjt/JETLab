using System.Web.Mvc;

namespace Mall.Areas.SysManagement
{
    public class SysManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysManagement_default",
                "SysManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
