using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiniNotes.Data.Repositories;
using MiniNotes.Models;
using MiniNotes.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MiniNotes.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserRepository _userRepository;
        private readonly ActionExecutingContext _context;

        public DashboardController(INoteRepository noteRepository, ITagRepository tagRepository,
            IUserRepository userRepository, ActionExecutingContext context)
        {
            _noteRepository = noteRepository;
            _tagRepository = tagRepository;
            _userRepository = userRepository;
            _context = context;
        }

        [HttpPost("createNote")]
        public ActionResult CreateNote([FromBody] CreateNoteRequest request)
        {
            return Ok(request);
        }

    }
}
