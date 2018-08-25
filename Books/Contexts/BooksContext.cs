using Books.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Contexts
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("7e024344-2e8f-4221-9dd4-30a1a1583e19"),
                    FirstName = "George",
                    LastName = "RR Martin"
                },
                new Author()
                {
                    Id = Guid.Parse("80a69425-841f-4a41-bb76-066edbcc27ca"),
                    FirstName = "Stephen",
                    LastName = "Fry"
                },
                new Author()
                {
                    Id = Guid.Parse("4801a767-7686-42d8-bc5d-21be5e77f09a"),
                    FirstName = "Douglas",
                    LastName = "Adams"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("c1db50b3-d8f3-46f9-b206-7670642f59f9"),
                    AuthorId = Guid.Parse("3cd38d75-3902-412c-9505-a5cd94655224"),
                    Title = "The Winds of Winter",
                    Description = "The book that seems impossible to write."
                },
                new Book()
                {
                    Id = Guid.Parse("085f56b1-22a2-4e7e-ad87-95f53fbbb4a5"),
                    AuthorId = Guid.Parse("b4bf6403-d0f1-44a1-aa91-d9495b7b6e2d"),
                    Title = "Mythos",
                    Description = "The Greek myths are amongst the best stories ever told."
                },
                new Book
                {
                    Id = Guid.Parse("a82f3d1b-b73a-4c9b-baa2-dde17ace455a"),
                    AuthorId = Guid.Parse("0d7550d9-fdeb-4251-9ba7-5d54d28639b6"),
                    Title = "American Tabloid",
                    Description = "American Tabloid is a 1995 novel by James Ellroy."
                },
                new Book
                {
                    Id = Guid.Parse("ccf51053-355c-4761-a316-6a6524b6a32d"),
                    AuthorId = Guid.Parse("5f677fd5-ed28-4b7c-a4bb-0bf8470c6865"),
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description = "In the Hitchhiker's Guide to the Galaxy."
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
