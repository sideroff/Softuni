﻿using System.Web;
using System.Web.Mvc;

namespace _2_Book_Library
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
