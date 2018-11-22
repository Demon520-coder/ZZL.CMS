using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ZZL.CMS.Web.Controllers
{
    public class BaseController : Controller
    {
        public ContentResult JsonContent(object data, string dateFormat = "yyyy-MM-dd", JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.DateFormatString = dateFormat;  //设置日期格式
            settings.ContractResolver = new DefaultContractResolver();  //设置属性输出默认值;

            if (Request.HttpMethod == HttpMethod.Get.Method)
            {
                if (behavior != JsonRequestBehavior.AllowGet)
                {
                    return Content("不支持的方法", "text/plain", Encoding.UTF8);
                }
            }

            return Content(JsonConvert.SerializeObject(data, settings), "application/json", Encoding.UTF8);
        }

        public ContentResult JsonContent(object data, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.ContractResolver = new DefaultContractResolver();  //设置属性输出默认值;

            if (Request.HttpMethod == HttpMethod.Get.Method)
            {
                if (behavior != JsonRequestBehavior.AllowGet)
                {
                    return Content("不支持的方法", "text/plain");
                }
            }

            return Content(JsonConvert.SerializeObject(data, settings), "application/json");
        }

        public ContentResult JsonContent(object data, Encoding encoding, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.ContractResolver = new DefaultContractResolver();  //设置属性输出默认值;

            if (Request.HttpMethod == HttpMethod.Get.Method)
            {
                if (behavior != JsonRequestBehavior.AllowGet)
                {
                    return Content("不支持的方法", "text/plain", encoding);
                }
            }

            return Content(JsonConvert.SerializeObject(data, settings), "application/json", encoding);
        }


        public MyJsonResult MyJson(int code, string msg, object data, string contentType, string dateFormatter, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            return new MyJsonResult
            {
                Code = code,
                Msg = msg,
                Data = data,
                ContentType = contentType,
                JsonRequestBehavior = behavior,
                DateFormatString = dateFormatter
            };
        }

        public MyJsonResult MyJson(int code, string msg, object data, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            return new MyJsonResult
            {
                Code = code,
                Msg = msg,
                Data = data,
                JsonRequestBehavior = behavior
            };
        }
    }

}