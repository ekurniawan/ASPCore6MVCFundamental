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
            using(SqlConnection conn = new SqlConnection(GetConnStr())){

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