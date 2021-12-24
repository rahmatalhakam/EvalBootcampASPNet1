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
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;
        public CoursesController(ICourse course, IMapper mapper)
        {
            _course = course ?? throw new ArgumentNullException(nameof(course));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseGDto>>> Get()
        {
            var courses = await _course.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseGDto>>(courses);
            return Ok(dtos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseGDto>> Get(int id)
        {
            try
            {
                var results = await _course.GetById(id);
                return Ok(_mapper.Map<CourseGDto>(results));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            

        }

        [HttpGet("bytitle")]
        public async Task<ActionResult<CourseGDto>> GetTitle(string name)
        {
            var results = await _course.GetByName(name);
            if (results == null)
                return NotFound();
            //return Ok(_mapper.Map<CourseGDto>(results));
            return Ok(results);

        }

       

        [HttpGet("byauthor")]
        public async Task<ActionResult<CourseGDto>> Get(string author)
        {
            var results = await _course.GetByAuthor(author);
            if (results == null)
                return NotFound();
            //return Ok(_mapper.Map<CourseGDto>(results));
            return Ok(results);

        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<CourseGDto>> Post([FromBody] CourseCUDto course)
        {
            try
            {
                var dtos = _mapper.Map<Course>(course);
                var result = await _course.Insert(dtos);
                return Ok(_mapper.Map<CourseGDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseGDto>> Put(int id, [FromBody] CourseCUDto course)
        {
            try
            {
                var result = await _course.Update(id, _mapper.Map<Course>(course));
                return Ok(_mapper.Map<CourseGDto>(result));
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
                await _course.Delete(id);
                return Ok($"Data student {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
