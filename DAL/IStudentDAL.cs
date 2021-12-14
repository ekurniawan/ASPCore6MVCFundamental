using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASP.Models;

namespace SampleASP.DAL
{
    public interface IStudentDAL
    {
        public IEnumerable<Student> GetAll();
        public Student GetById(string studentID);
        void Insert(Student student);
        void Update(Student student);
        void Delete(string studentID);
    }
}