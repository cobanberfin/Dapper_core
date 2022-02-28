using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Models.Repository
{
   public interface IStudentRepository
    {
        List<Student> GetAll();
        Student Find(int id);
        Student Add(Student student);
        Student Update(Student student);
        void Remove(int id);



    }
}
