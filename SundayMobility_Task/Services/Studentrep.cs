using Microsoft.EntityFrameworkCore;
using SundayMobility_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayMobility_Task.Services
{
    public class Studentrep:IStudent
    {
        private TaskContext _Context;
        public Studentrep(TaskContext context)
        {
            _Context = context;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _Context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentByID(int id)
        {
            return await _Context.Students.Where(m=>m.StudentID==id).FirstOrDefaultAsync();
        }
        public async Task<int> AddStudent(Student model)
        {
            await _Context.AddAsync(model);
            await _Context.SaveChangesAsync();
            return model.StudentID;

        }
        public async Task<int> UpdateStudent(Student model)
        {
            var dbModel = await _Context.Students.Where(m => m.StudentID == model.StudentID).FirstOrDefaultAsync();
            if (dbModel != null)
            {
                dbModel.Address = model.Address;
                dbModel.Age = model.Age;
                dbModel.Email = model.Email;
                dbModel.FirstName = model.FirstName;
                dbModel.LastName = model.LastName;
                dbModel.Phone = model.Phone;
            }
            await _Context.SaveChangesAsync();
            return model.StudentID;

        }
        public async Task<string> DeleteStudent(int id)
        {
            var model= await _Context.Students.Where(m => m.StudentID == id).FirstOrDefaultAsync();
            if (model != null)
            {
                _Context.Students.Remove(model);
                await _Context.SaveChangesAsync();
            }
            return "Delete successfully";
        }
    }
}
