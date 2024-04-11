using Company.Project.Web.Interfaces;
using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _db;
        public CommentService(AppDbContext db)
        {
            this._db = db;
        }
        public async Task PostComment(Comments comments)
        {
            await _db.Comments.AddAsync(comments);
            await _db.SaveChangesAsync();
        }
    }
}
