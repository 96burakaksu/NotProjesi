using NoteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Service.Interfaces
{
    public interface INoteService
    {
        CustomResponse DeleteNote(DeleteNoteRequest content);
        CustomResponse<List<NoteResponse>> NoteList();
        CustomResponse AddNote(AddNoteRequest content);
    }
}
