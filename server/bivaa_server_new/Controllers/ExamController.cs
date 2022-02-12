using bivaa_server_new.Utils;
using bivaa_server_new.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bivaa_server_new.Interfaces;
using System.Web.Http.Cors;

namespace bivaa_server_new.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class ExamController : ApiController
    {
        public HttpResponseMessage GetExamTypes()
        {
            ExamService a = new ExamService();
            var examTypes = a.GetExamTypes();
            string resultString = examTypes.ToJson();

            HttpResponseMessage result = new HttpResponseMessage();
            result.Content = new StringContent(resultString);
            result.ApplyJsonContentType();
            return result;
        }


        public HttpResponseMessage GetExams()
        {
            ExamService a = new ExamService();
            var exams = a.GetExams();
            string resultString = exams.ToJson();

            HttpResponseMessage result = new HttpResponseMessage();
            result.Content = new StringContent(resultString);
            result.ApplyJsonContentType();
            return result;
        }

        public HttpResponseMessage PostExam(HttpRequestMessage req)
        {

            var requestBody = req.Content.ReadAsStringAsync().Result;
            var requestExam = requestBody.FromJson<exam>();
            ExamService a = new ExamService();

            var createdExam = a.PostExam(requestExam);
            var result = new HttpResponseMessage();
            result.Content = new StringContent(createdExam.ToJson());
            result.ApplyJsonContentType();
            return result;


        }

        public HttpResponseMessage PutExam(HttpRequestMessage req)
        {
            var requestBody = req.Content.ReadAsStringAsync().Result;
            var requestExam = requestBody.FromJson<exam>();
            ExamService a = new ExamService();

            var updatedExam = a.PutExam(requestExam.ID, requestExam);
            var result = new HttpResponseMessage();
            result.Content = new StringContent(updatedExam.ToJson());
            result.ApplyJsonContentType();
            return result;

        }

        public HttpResponseMessage DeleteExam(int id)
        {
            var a = new ExamService();
            a.DeleteExam(id);
            var res = new HttpResponseMessage();
            res.StatusCode = System.Net.HttpStatusCode.OK;
            return res;
        }
    }


}
