using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadDisplayDB.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public byte[] Photo { get; set; }
        public string ImageUrl { get; set; }
    }
}
