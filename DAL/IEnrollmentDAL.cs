using SampleASP.Models;

namespace SampleASP.DAL
{
    public interface IEnrollmentDAL
    {
        IEnumerable<ViewEnrollment> GetAll();
        IEnumerable<ViewEnrollment> GetByStudent(string studentId);
        IEnumerable<ViewEnrollment> GetByCourse(string courseId);
        void AddEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int id);
    }
}
