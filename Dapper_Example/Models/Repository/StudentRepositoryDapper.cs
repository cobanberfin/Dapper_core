using Dapper;
using Dapper_Example.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Models.Repository
{
    public class StudentRepositoryDapper : IStudentRepository
    {
        private IDbConnection db;
        public StudentRepositoryDapper(IConfiguration configuration)
        {

            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Student Add(Student student)
        {
            var sql = "Insert Into Students(Name,Surname,Email) values(@Name,@SurName,@Email);" + "Select cast(scope_IDENTITY()as int)";
            var id = db.Query<int>(sql, student).Single();
            student.Id = id;
            return student;

        }

        public Student Find(int id)
        {
            var sql = "Select * from Students where Id=@Studentid";
            return db.Query<Student>(sql, new { @Studentid = id }).Single();
        }

        public List<Student> GetAll()
        {
            var sql = "select * from Students";
            return db.Query<Student>(sql).ToList();
        }

        public void Remove(int id)
        {
            var sql = "Delete from Students where Id=@id";
            db.Execute(sql, new { id });
        }

    
        public Student Update(Student student)
        {
            var sql = "Update Students Set Name=@Name,Surname=@Surname,Email=@Email Where Id=id";
            db.Execute(sql, student);
            return student;
        }
       
    }
}
