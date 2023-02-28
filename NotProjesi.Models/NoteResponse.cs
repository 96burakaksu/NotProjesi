using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProject.Models
{
    public class NoteResponse
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
    }
}
