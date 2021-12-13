using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleASP.Models;

namespace SampleASP.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private IConfiguration _config;
        public StudentDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr(){
            return _config.GetConnectionString("DefaultConnection");
        }

        public void Delete(string studentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student> lstStudent = new List<Student>();
            using(SqlConnection conn = new SqlConnection(GetConnStr())){
                string strSql = @"select * from Students order by StudentID";
                SqlCommand cmd = new SqlCommand(strSql,conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows){
                    while(dr.Read()){
                        lstStudent.Add(new Student{
                            StudentID = dr["StudentID"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            EnrollmentDate = Convert.ToDateTime(dr["EnrollmentDate"])
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return lstStudent;
            }
        }

        public Student GetById(string studentID)
        {
            throw new NotImplementedException();
        }

        public void Insert(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(string studentID, Student student)
        {
            throw new NotImplementedException();
        }
    }
}