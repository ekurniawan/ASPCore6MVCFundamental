using SampleASP.Models;
using System.Data.SqlClient;
using Dapper;

namespace SampleASP.DAL
{
    public class EnrollmentDAL : IEnrollmentDAL
    {
        private IConfiguration _config;
        public EnrollmentDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public void DeleteEnrollment(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewEnrollment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewEnrollment> GetByCourse(string courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewEnrollment> GetByStudent(string studentId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from ViewEnrollments where StudentID=@StudentID";
                var param = new { StudentID=studentId };
                var results = conn.Query<ViewEnrollment>(strSql,param);
                return results;
            }
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }
    }
}
