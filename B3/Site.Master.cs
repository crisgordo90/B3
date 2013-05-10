using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;

namespace B3
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public static string USUARIO = "";

        public Boolean Usuario()
        {
            if (USUARIO.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
