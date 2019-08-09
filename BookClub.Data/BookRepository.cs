using System.Collections.Generic;
using System.Data;
using System.Linq;
using BookClub.Entities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace BookClub.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _db;
        private readonly ILogger<BookRepository> logger;

        public BookRepository(IDbConnection db, ILogger<BookRepository> logger)
        {
            _db = db;
            this.logger = logger;
        }

        public List<Book> GetAllBooks()
        {
            logger.LogInformation("GetAllBooks call");
            var books = _db.Query<Book>("GetAllBooks", commandType: CommandType.StoredProcedure)
                .ToList();
            return books;
        }
    }
}
