using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bivaa_server_new.Interfaces
{
    public interface IExamService
    {
        List<exam_type> GetExamTypes();
        List<exam> GetExams();
        exam PostExam(exam ex);
        exam PutExam(int id, exam requestExam);
        void DeleteExam(int id);


    }
}
