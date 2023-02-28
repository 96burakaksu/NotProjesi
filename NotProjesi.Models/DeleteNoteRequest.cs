using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Models
{
   public class DeleteNoteRequest
    {
        public int Id { get; set; }
        public int Pid { get; set; }
    }
}
