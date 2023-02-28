using NoteProject.Models;
using NoteProject.RepositoryApi.Interfaces;
using NotProjesi.RepositoryApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProject.RepositoryApi.Services
{
    public class ApisService : IApisService
    {
        private readonly IApisRepository _apisRepository;

        public ApisService(IApisRepository apisRepository)
        {
            _apisRepository = apisRepository;
        }

        public CustomResponse AddNote(AddNoteRequest request)
        {
            return _apisRepository.AddNote(request);
        }
        public CustomResponse DeleteNote(DeleteNoteRequest request)
        {
            return _apisRepository.DeleteNote(request);
        }
        public  List<NoteResponse> NoteList()
        {
            return _apisRepository.NoteList();
        }
    }
}
