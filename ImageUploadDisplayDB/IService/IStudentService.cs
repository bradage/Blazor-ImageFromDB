using ImageUploadDisplayDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadDisplayDB.IService
{
    public interface IStudentService
    {
        Student Save(Student oStudent);
        Student GetSavedStudent();
    }
}
