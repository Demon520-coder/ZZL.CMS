using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ZZL.CMS.Web
{
    public class MyJsonResult : JsonResult
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public string DateFormatString { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context is null");
            }

            if (context.RequestContext.HttpContext.Request.HttpMethod == HttpMethod.Get.Method && this.JsonRequestBehavior == JsonRequestBehavior.DenyGet)
            {
                throw new NotSupportedException("不支持get请求");
            }

            HttpResponseBase httpResponseBase = context.RequestContext.HttpContext.Response;

            if (string.IsNullOrEmpty(this.ContentType))
            {
                httpResponseBase.ContentType = "application/json";
            }
            else
            {
                httpResponseBase.ContentType = this.ContentType;
            }

            if (ContentEncoding == null)
            {
                httpResponseBase.ContentEncoding = Encoding.UTF8;
            }
            else
            {
                httpResponseBase.ContentEncoding = this.ContentEncoding;
            }

            if (string.IsNullOrEmpty(this.DateFormatString))
            {
                this.DateFormatString = "yyyy-MM-dd";
            }

            if (Data != null)
            {
                Newtonsoft.Json.JsonSerializerSettings serializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
                serializerSettings.DateFormatString = this.DateFormatString;
                serializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                serializerSettings.ContractResolver = new DefaultContractResolver();
                httpResponseBase.Write(JsonConvert.SerializeObject(new { code = this.Code, msg = this.Msg, data = this.Data }, serializerSettings));
            }
        }
    }
}