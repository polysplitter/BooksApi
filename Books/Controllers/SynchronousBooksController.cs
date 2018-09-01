﻿using Books.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    [Route("api/synchronousbooks")]
    [ApiController]
    public class SynchronousBooksController : ControllerBase
    {
        private IBooksRepository _booksRepository;

        public SynchronousBooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository ?? throw new ArgumentException(nameof(booksRepository));
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var bookEntities = _booksRepository.GetBooks();
            return Ok(bookEntities);
        }
    }
}
