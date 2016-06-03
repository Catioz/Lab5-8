using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);



            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "HomeHome",
                url: "Home/",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "HomeAbout",
                url: "Home/About",
                defaults: new { controller = "Home", action = "About" }
            );
            routes.MapRoute(
                name: "NotepadNotepad",
                url: "Notepad/",
                defaults: new { controller = "Home", action = "Notepad" }
            );
  
            routes.MapRoute(
                name: "NotepadCreate",
                url: "Notepad/Create",
                defaults: new { controller = "Home", action = "Notepad" }
            );
            routes.MapRoute(
                name: "NotepadName",
                url: "Notepad/{Name}",
                defaults: new { controller = "Home", action = "NotepadName", Name = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Create",
                url: "Home/Create",
                defaults: new { controller = "Home", action = "Create" }
            );
            routes.MapRoute(
                name: "Record",
                url: "Home/Record",
                defaults: new { controller = "Home", action = "Record" }
            );
            routes.MapRoute(
                name: "Load",
                url: "Home/Load",
                defaults: new { controller = "Home", action = "Load" }
            );
            routes.MapRoute(
                name: "Image",
                url: "Home/Image",
                defaults: new { controller = "Home", action = "Image" }
            );



        }

    }
}
