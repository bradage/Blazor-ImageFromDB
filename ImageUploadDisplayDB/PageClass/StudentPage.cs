using ImageUploadDisplayDB.Data;
using ImageUploadDisplayDB.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadDisplayDB.PageClass
{
    public class StudentPage
    {
        IStudentService _studentService = null;
        public StudentPage(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public string SaveInformations(byte[] fileBytes, Student oStudent)
        {
            oStudent.Photo = fileBytes;
            oStudent = _studentService.Save(oStudent);
            if (oStudent.StudentId > 0)
            {
                return "Saved";
            }
            return "Failed";
        }
        //Store Procedure
        public Student GetSavedStudent()
        {
            var student = _studentService.GetSavedStudent();
            student.Photo = this.GetImage(Convert.ToBase64String(student.Photo));
            student.ImageUrl = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(student.Photo));
            return student;
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
    }
}
