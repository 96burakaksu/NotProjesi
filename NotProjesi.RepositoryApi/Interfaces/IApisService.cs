using NoteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProject.RepositoryApi.Interfaces
{
    public interface IApisService
    {
        CustomResponse DeleteNote(DeleteNoteRequest request);
        List<NoteResponse> NoteList();
        CustomResponse AddNote(AddNoteRequest request);
    }
}
