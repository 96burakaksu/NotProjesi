using Dapper;
using NoteProject.Models;
using NoteProject.RepositoryApi.Context;
using NotProjesi.RepositoryApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProject.RepositoryApi.Repository
{
    public class ApisRepository : IApisRepository
    {
        private readonly DapperContext _context;

        public ApisRepository(DapperContext context)
        {
            _context = context;
        }
        public CustomResponse AddNote(AddNoteRequest request)
        {
            var sql = "";
            if (request.Id == 0)
            {
                 sql = "INSERT INTO Notes (Pid, Title, Contentt) Values (@Pid, @Title, @Contentt)";
            }
            else
            {
                sql = "UPDATE Notes SET Pid = @Pid, Title = @Title, Contentt = @Contentt WHERE Id = @Id";

            }
            var parametre = new DynamicParameters();
            parametre.Add("Id", request.Id);
            parametre.Add("Pid", request.Pid);
            parametre.Add("Title", request.Title);
            parametre.Add("Contentt", request.Contentt);
            

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(sql, parametre);
            }
            return new CustomResponse { Success = true };
        }
       public List<NoteResponse> NoteList()
        {
            var sql = "SELECT Id, Pid, Title as Baslik, Contentt as Detay FROM notes WHERE Silindi!=1";
            using(var connection = _context.CreateConnection())
            {
               return connection.Query<NoteResponse>(sql).ToList();
            }
        }
        public CustomResponse DeleteNote(DeleteNoteRequest request)
        {
            var sql = "UPDATE Notes SET Pid = @Pid WHERE Pid = @Id; UPDATE notes SET Silindi = 1 WHERE Id = @Id ";
            var parametre = new DynamicParameters();
            parametre.Add("Id", request.Id);
            parametre.Add("Pid", request.Pid);

            using(var connection = _context.CreateConnection())
            {
                connection.Execute(sql, parametre);
            }
            return new CustomResponse { Success = true };

        }
    }
}
