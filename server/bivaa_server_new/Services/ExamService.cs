using bivaa_server_new.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bivaa_server_new.Services
{
    public class ExamService : IExamService
    {
        public List<exam_type> GetExamTypes()
        {
            using (var db = new DbModel())
            {
                var examTypes = (from et in db.exam_type select et).ToList();
                return examTypes;
            }
        }


        public List<exam> GetExams()
        {
            using (var db = new DbModel())
            {
                var exams = (from e in db.exam select e).ToList();
                return exams;
            }
        }

        public exam PostExam(exam ex)
        {
            using (var db = new DbModel())
            {
                db.exam.Add(ex);
                db.SaveChanges();
                return ex;
            }
        }

        public exam PutExam(int id, exam requestExam)
        {
            using (var db = new DbModel())
            {
                var ex = (from e in db.exam where e.ID == id select e).SingleOrDefault();
                if (ex != null)
                {
                    ex.exam_name = requestExam.exam_name;
                    ex.form_label = requestExam.form_label;
                    ex.responsible = requestExam.responsible;
                    ex.prep_time_est = requestExam.prep_time_est;
                    ex.exam_time_est = requestExam.exam_time_est;
                    ex.device = requestExam.device;
                    ex.exam_type = requestExam.exam_type;

                    db.SaveChanges();
                    return ex;
                }
                else
                {
                    return null;
                }
            }
        }

        public void DeleteExam(int id)
        {
            using (var db = new DbModel())
            {
                var ex = new exam { ID = id };
                db.exam.Attach(ex);
                db.exam.Remove(ex);
                db.SaveChanges();
            }
        }
    }
}