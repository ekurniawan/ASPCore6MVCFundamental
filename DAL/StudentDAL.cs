using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleASP.Models;
using Dapper;

namespace SampleASP.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private IConfiguration _config;
        public StudentDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public void Delete(string studentID)
        {
            var result = GetById(studentID);
            if (result == null)
                throw new Exception("Student tidak ditemukan");


            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Students where StudentID=@StudentID";
                var param = new { StudentID = studentID };
                try
                {
                    var output = conn.Execute(strSql, param);
                    if (output != 1)
                        throw new Exception("Gagal delete data");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Kesalahan: {sqlEx.Message}");
                }
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Students order by StudentID";
                var results = conn.Query<Student>(strSql);
                return results;
            }
        }

        /*public IEnumerable<Student> GetAll()
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
        }*/

        public Student GetById(string studentID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = "select * from Students where StudentID=@StudentID";
                var param = new { StudentID = studentID };
                var result = conn.QuerySingle<Student>(strSql, param);
                return result;
            }
        }

        public void Insert(Student student)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"insert into Students(StudentID,FirstName,LastName,EnrollmentDate) 
                             values(@StudentID,@FirstName,@LastName,@EnrollmentDate)";
                var param = new
                {
                    StudentID = student.StudentID,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    EnrollmentDate = student.EnrollmentDate
                };
                try
                {
                    var result = conn.Execute(strSql, param);
                    if (result != 1)
                        throw new Exception("Gagal menambahkan data !");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        public void Update(Student student)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Students set FirstName=@FirstName,LastName=@LastName,
                EnrollmentDate=@EnrollmentDate where StudentID=@StudentID";
                var param = new
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    EnrollmentDate = student.EnrollmentDate,
                    StudentID = student.StudentID
                };
                try
                {
                    var result = conn.Execute(strSql, param);
                    if(result != 1)
                        throw new Exception("Gagal update data");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Kesalahan: {sqlEx.Message}");
                }
            }
        }
    }
}