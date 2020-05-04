using Microsoft.EntityFrameworkCore;
using PersonalPage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPage.Data.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private ApplicationDbContext db;

        public AuthorRepository()
        {
            this.db = new ApplicationDbContext();
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
