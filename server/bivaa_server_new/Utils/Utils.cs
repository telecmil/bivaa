using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace bivaa_server_new.Utils
{
    public static class Utils
    {
        //public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
        public static string ToJson(this List<exam_type> list)
        {
            dynamic jArray = new JArray();
            foreach (exam_type i in list)
            {
                dynamic item = new JObject();
                item.type = i.type;
                jArray.Add(item);
              
            }
            return Convert.ToString(jArray);
        }

        public static string ToJson(this List<devices> list)
        {
            dynamic jArray = new JArray();
            foreach (devices i in list)
            {
                dynamic item = new JObject();
                item.device_ID = i.device_ID;
                item.device_name = i.device_name;
                item.last_inspection = i.last_inspection;
                jArray.Add(item);

            }
            return Convert.ToString(jArray);
        }

        public static string ToJson(this devices dev)
        {
            dynamic item = new JObject();
            item.device_ID = dev.device_ID;
            item.device_name = dev.device_name;
            item.last_inspection = dev.last_inspection;
            return Convert.ToString(item);

        }

        public static string ToJson(this List<exam> list)
        {
            dynamic jArray = new JArray();
            foreach (exam i in list)
            {
                dynamic item = new JObject();
                item.ID = i.ID;
                item.exam_name = i.exam_name;
                item.form_label = i.form_label;
                item.responsible = i.responsible;
                item.prep_time_est = i.prep_time_est;
                item.exam_time_est = i.exam_time_est;
                item.device = i.device;
                item.exam_type = i.exam_type;
                jArray.Add(item);

            }
            return Convert.ToString(jArray);
        }

        public static string ToJson(this exam i)
        {
            dynamic item = new JObject();
            item.ID = i.ID;
            item.exam_name = i.exam_name;
            item.form_label = i.form_label;
            item.responsible = i.responsible;
            item.prep_time_est = i.prep_time_est;
            item.exam_time_est = i.exam_time_est;
            item.device = i.device;
            item.exam_type = i.exam_type;
            return Convert.ToString(item);
        }
        public static T FromJson<T>(this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }

        public static void ApplyJsonContentType(this HttpResponseMessage msg, string mediaType = "application/json")
        {
            msg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType);
        }
    }
 
}