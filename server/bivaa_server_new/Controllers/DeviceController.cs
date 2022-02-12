using bivaa_server_new.Services;
using bivaa_server_new.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace bivaa_server_new.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class DeviceController : ApiController
    {
        public HttpResponseMessage GetDevices()
        {
            DeviceService a = new DeviceService();
            var devices = a.GetDevices();
            string resultString = devices.ToJson();
            HttpResponseMessage result = new HttpResponseMessage();
            result.Content = new StringContent(resultString);
            result.ApplyJsonContentType();
            return result;
        }

        public HttpResponseMessage PostDevice(HttpRequestMessage req)
        {

            var requestBody = req.Content.ReadAsStringAsync().Result;
            var requestDevice = requestBody.FromJson<devices>();
            DeviceService a = new DeviceService();

            var createdDevice = a.PostDevice(requestDevice);
            var result = new HttpResponseMessage();
            result.Content = new StringContent(createdDevice.ToJson());
            result.ApplyJsonContentType();
            return result;


        }

        public HttpResponseMessage PutDevice(HttpRequestMessage req)
        {
            var requestBody = req.Content.ReadAsStringAsync().Result;
            var requestDevice = requestBody.FromJson<devices>();
            DeviceService a = new DeviceService();

            var updatedDevice = a.PutDevice(requestDevice.device_ID, requestDevice);
            var result = new HttpResponseMessage();
            result.Content = new StringContent(updatedDevice.ToJson());
            result.ApplyJsonContentType();
            return result;

        }

        public HttpResponseMessage DeleteDevice(int id)
        {
            var a = new DeviceService();
            a.DeleteDevice(id);
            var res = new HttpResponseMessage();
            res.StatusCode = System.Net.HttpStatusCode.OK;
            return res;
        }
    }


}