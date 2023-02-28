using Microsoft.AspNetCore.Mvc;
using NoteProject.Models;
using NoteProject.Service.Interfaces;

namespace NotProjesi.WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;

        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }

        //List<NoteResponse> notlars = new List<NoteResponse>
        //    {
        //        new NoteResponse{Id=1, Baslik = "Tarih Notu", Detay="Tarih Notu Detayı", Pid=0},
        //        new NoteResponse{Id=7, Baslik = "Tarih Notu7", Detay="Tarih Notu Detayı", Pid=0},
        //        new NoteResponse{Id=2, Baslik = "Tarih Notu2", Detay="Tarih Notu Detayı2", Pid=1},
        //        new NoteResponse{Id=3, Baslik = "Tarih Notu3", Detay="Tarih Notu Detayı3", Pid=1},
        //        new NoteResponse{Id=4, Baslik = "Tarih Notu3", Detay="Tarih Notu Detayı3", Pid=2},
        //        new NoteResponse{Id=5, Baslik = "Tarih Notu3", Detay="Tarih Notu Detayı3", Pid=2},
        //        new NoteResponse{Id=6, Baslik = "Tarih Notu3", Detay="Tarih Notu Detayı3", Pid=1},
        //        new NoteResponse{Id=6, Baslik = "Tarih Notu3", Detay="Tarih Notu Detayı3", Pid=7},
        //        new NoteResponse{Id=6, Baslik = "yENİ", Detay="yENİ", Pid=0},
        //    };

        //NotlarModel notlars = new NotlarModel { Id = 2, Başlık = "asdf", Detay = "sfdgfd", Pid = 0 };
        public IActionResult Index()
        {

            return View();
        }

        public JsonResult VerileriGetir()
        {
            var noteList = _noteService.NoteList();
            return Json(noteList.Data);
        }

        [HttpPost]
        public JsonResult AddNote(AddNoteRequest request)
        {
           
            return Json(_noteService.AddNote(request));
        }
        [HttpPost]
        public JsonResult DeleteNote(DeleteNoteRequest request)
        {
           
            return Json(_noteService.DeleteNote(request));
        }
 
    }
}
