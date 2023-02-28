



using NoteProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotProjesi.RepositoryApi.Interfaces
{
    public interface IApisRepository
    {
        CustomResponse DeleteNote(DeleteNoteRequest request);
        List<NoteResponse> NoteList();
        CustomResponse AddNote(AddNoteRequest request);
    }
}
