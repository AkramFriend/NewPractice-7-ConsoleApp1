using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractice_7_ConsoleApp1
{
    struct Worker
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; } //!
        public string BirthPlace { get; set; }
    }

}

