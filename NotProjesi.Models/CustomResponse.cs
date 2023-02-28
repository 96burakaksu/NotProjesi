using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Models
{
    public class CustomResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class CustomResponse<T> : CustomResponse
    {
        public T Data { get; set; }
    }
}
