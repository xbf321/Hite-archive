﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hite.Web.Forum
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ReplyThread",
                "replythread",
                new { controller = "Home", action = "ReplyThread"}
            );
            routes.MapRoute(
                "EditThread",
                "publishthread/{forumId}-{topicId}.html",
                new { controller = "Home", action = "PulishThread" },
                new { forumId = @"\d+", topicId = @"\d+" }
            );
            routes.MapRoute(
                "PublishThread",
                "publishthread/{forumId}.html",
                new { controller = "Home", action = "PulishThread" },
                new { forumId = @"\d+"}
            );            
            routes.MapRoute(
                "Catalog",
                "catalog/{id}.html",
                new { controller = "Home", action = "ShowCatalog", id = @"\d+" }
            );
            routes.MapRoute(
                "Thread",
                "thread/{id}.html",
                new { controller = "Home", action = "ShowThread", id = @"\d+" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            log4net.Config.XmlConfigurator.Configure();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}