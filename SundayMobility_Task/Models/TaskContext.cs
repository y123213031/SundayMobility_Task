using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SundayMobility_Task.Models
{
    public class TaskContext:DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }

      public  DbSet<Student> Students { get; set; }


    }
}
