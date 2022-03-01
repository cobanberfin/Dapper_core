using Dapper_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_core.Models
{
    public class StudentModel
    {
        public Student student  { get; set; }
        public List<Student> sList { get; set; }

    }
}
