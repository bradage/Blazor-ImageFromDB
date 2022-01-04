using Dapper;
using ImageUploadDisplayDB.Data;
using ImageUploadDisplayDB.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadDisplayDB.Service
{
    public class StudentService : IStudentService
    {
        Student _oStudent = new Student();
        public Student GetSavedStudent()
        {
            _oStudent = new Student();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var oStudents = con.Query<Student>("SELECT TOP(1)* FROM Students").ToList();

                if (oStudents != null && oStudents.Count() > 0)
                {
                    _oStudent = oStudents.FirstOrDefault();
                }
            }
            return _oStudent;
        }

        public Student Save(Student oStudent)
        {
            _oStudent = new Student();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var oStudents = con.Query<Student>("SP_Student",
                    this.SetParameters(oStudent),
                    commandType: CommandType.StoredProcedure);

                if (oStudents != null && oStudents.Count() > 0)
                {
                    _oStudent = oStudents.FirstOrDefault();
                }
            }
            return _oStudent;
        }

        private DynamicParameters SetParameters(Student oStudent)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@StudentId", oStudent.StudentId);
            parameters.Add("@Name", oStudent.Name);
            parameters.Add("@Roll", oStudent.Roll);
            parameters.Add("@Photo", oStudent.Photo);

            return parameters;
        }
    }
}
