using SundayMobility_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayMobility_Task.Services
{
   public interface IStudent
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentByID(int id);
        Task<int> AddStudent(Student model);
        Task<int> UpdateStudent(Student model);
        Task<string> DeleteStudent(int id);
    }
}
