using System;
using System.Web;
using System.Xml;

namespace CoreFramework.ASP
{
    public class QueryHandler
    {
        protected XmlDocument Request { get; set; }
        protected XmlDocument Response { get; set; }
        
        protected void SetError(string errorType, string errorMsg)
        {
            XmlElement errNode = Response.CreateElement("Error");
            errNode.SetAttribute("err_type", errorType);
            errNode.InnerText = errorMsg;
            Response.AppendChild(errNode);
        }

        protected void WriteError(HttpContext context, string errorType, string errorMsg)
        {
            SetError(errorType, errorMsg);
            Response.Save(context.Response.OutputStream);
        }

        protected bool SetupHandler(HttpContext context)
        {
            context.Response.ContentType = "text/xml";

            Request = new XmlDocument();
            Response = new XmlDocument();
            
            try
            {
                Request.Load(context.Request.InputStream);
            }
            catch(XmlException)
            {
                SetError("bad_request", "XML request could not be parsed.");
            }

            return true;
        }
    }
}
