using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class HtmlhelperExtention
    {
        public static MvcHtmlString MyLabel(this HtmlHelper helper, string str)
        {
            return new MvcHtmlString(string.Format("<span>{0}</span>",str));
        }
    }
}