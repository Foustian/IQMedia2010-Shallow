﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQMedia.Common.Util;

namespace IQMedia.WebApplication.App_Code
{
    public class EndRequestModule : IHttpModule
    {
        public EndRequestModule()
        {
        }

        public String ModuleName
        {
            get { return "EndRequestModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.EndRequest +=
                 (new EventHandler(this.Application_EndRequest));

            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;

            System.Web.Configuration.SessionStateSection sessionStateSection = (System.Web.Configuration.SessionStateSection)System.Configuration.ConfigurationManager.GetSection("system.web/sessionState");

            var cookieName = sessionStateSection.CookieName;


            if (((filePath.ToLower().Trim()=="/sign-in" || filePath.ToLower().Trim()=="/signin") && context.Request.HttpMethod.ToLower() == "post"))
            {
                if (context.Request.Cookies.AllKeys.Contains(cookieName))
                {
                    context.Request.Cookies[cookieName].Value = "CCQ";
                }
            }
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;

            if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["CookieDebug"]))
            {
                for (int i = 0; i < context.Request.Cookies.Count; i++)
                {
                    Logger.Info("RQ: " + filePath + "..." + context.Request.Cookies[i].Name + "..." + context.Request.Cookies[i].Value);
                }

                for (int j = 0; j < context.Response.Cookies.Count; j++)
                {
                    Logger.Info("RS: " + filePath + "..." + context.Response.Cookies[j].Name + "..." + context.Response.Cookies[j].Value);
                }

                if (!string.IsNullOrEmpty(context.Response.Headers["Set-Cookie"]))
                {
                    Logger.Info("RSH :" + filePath + "..." + context.Response.Headers["Set-Cookie"]);
                }
            }

            if (context.Response.Cookies.AllKeys.Contains(System.Web.Security.FormsAuthentication.FormsCookieName))
            {
                context.Response.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName].Secure = true;
            }

        }

        public void Dispose() { }
    }
}