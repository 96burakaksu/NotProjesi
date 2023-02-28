using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteProject.Models;
using NoteProject.RepositoryApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProject.RepositoryApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class NotesApiController : ControllerBase
    {
        private readonly IApisService _apisService;

        public NotesApiController(IApisService apisService)
        {
            _apisService = apisService;
        }

        [HttpPost]
        public CustomResponse AddNote(AddNoteRequest request)
        {
            return _apisService.AddNote(request);

        }
        [HttpPost]
        public CustomResponse DeleteNote(DeleteNoteRequest request)
        {
            return _apisService.DeleteNote(request);

        }


        [HttpPost]
        public CustomResponse<List<NoteResponse>> NoteList()
        {
            var noteList = _apisService.NoteList();
            return new CustomResponse<List<NoteResponse>>()
            {
                Success = noteList.Count > 0,
                Data = noteList,
                Message = noteList.Count > 0 ? "İşlem Başarılı": "Kayıt Bulunamadı"

            };
        }
    }
}
