using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EvalBootcampASPNet1.Data;
using EvalBootcampASPNet1.Dtos;
using EvalBootcampASPNet1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvalBootcampASPNet1.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private IAuthor _author;
        private IMapper _mapper;
        public AuthorsController(IAuthor author, IMapper mapper)
        {
            _author = author ?? throw new ArgumentNullException(nameof(author));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorGDto>>> Get()
        {
                var authors = await _author.GetAll();
                var dtos = _mapper.Map<IEnumerable<AuthorGDto>>(authors);
                return Ok(dtos);         
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorGDto>> Get(int id)
        {
            var results = await _author.GetById(id);
            if (results == null)
                return NotFound();
            return Ok(_mapper.Map<AuthorGDto>(results));

        }

        [HttpGet("byname")]
        public async Task<ActionResult<AuthorGDto>> Get(string name)
        {
            var results = await _author.GetByName(name);
            if (results == null)
                return NotFound();
            return Ok(_mapper.Map<AuthorGDto>(results));
            //return Ok(results);

        }
        [HttpGet("{id}/course")]
        public async Task<ActionResult<CourseGDto>> GetByIDAuthor(int id)
        {
            var results = await _author.GetByIDCourse(id);
            if (results == null)
                return NotFound();
            //return Ok(_mapper.Map<CourseGDto>(results));
            return Ok(results);

        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<AuthorGDto>> Post([FromBody] AuthorCUDto author)
        {
            try
            {
                var dtos = _mapper.Map<Author>(author);
                var result = await _author.Insert(dtos);
                return Ok(_mapper.Map<AuthorGDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<AuthorGDto>> Post([FromBody] AuthorCUDto author)
        //{
        //    try
        //    {
        //        var dtos = _mapper.Map<Author>(author);
        //        var result = await _author.Insert(dtos);
        //        return Ok(_mapper.Map<AuthorGDto>(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorGDto>> Put(int id, [FromBody] AuthorCUDto author)
        {
            try
            {
                var result = await _author.Update(id, _mapper.Map<Author>(author));
                return Ok(_mapper.Map<AuthorGDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _author.Delete(id);
                return Ok($"Data student {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
