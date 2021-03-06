using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackCProyecto1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackCProyecto1.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ComentarioController : ControllerBase {
    private readonly AplicationDbContext _context;

    public ComentarioController(AplicationDbContext context) {
      _context = context;
    }

    //[HttpGet]
    //public string index() {
    //  return "hola";
    //}
    // GET: api/<ComentarioController>
    [HttpGet]
    public ActionResult<List<Comentario>> Get() {
      try {
        List<Comentario> list = new List<Comentario>();
        list = _context.Comentario.ToList();
        return Ok(list);

      } catch (Exception ex) {

        return BadRequest(ex.Message);
      }
    }

    // GET api/<ComentarioController>/5
    [HttpGet("{id}")]
    public ActionResult<Comentario> Get(int id) {
      try {
        Comentario comentario = new Comentario();
        comentario = _context.Comentario.Find(id);
        if (comentario==null) {
          return NotFound();
        }
        return Ok(comentario);

      } catch (Exception ex) {

        return BadRequest(ex.Message);
      }
    }

    // POST api/<ComentarioController>
    [HttpPost]
    public ActionResult Post([FromBody] Comentario comentario) {
      try {
        _context.Add(comentario);
        _context.SaveChanges();

        return Ok();

      } catch (Exception ex) {

        return BadRequest(ex.Message);
      }
    }

    // PUT api/<ComentarioController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Comentario comentario) {
      try {

        if (id!= comentario.Id) {
          return BadRequest();
        }
        _context.Entry(comentario).State = EntityState.Modified;
        _context.Update(comentario);
        _context.SaveChanges();

        return Ok();

      } catch (Exception ex) {

        return BadRequest(ex.Message);
      }
    }

    // DELETE api/<ComentarioController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id) {
      try {

        Comentario comentario = new Comentario();
        comentario = _context.Comentario.Find(id);
        if (comentario==null) {
          return NotFound();
        }
        _context.Remove(comentario);
        _context.SaveChanges();

        return Ok();

      } catch (Exception ex) {

        return BadRequest(ex.Message);
      }
    }
  }
}
