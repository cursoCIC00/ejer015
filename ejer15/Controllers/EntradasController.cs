﻿
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ejer15.Models;
using ejer15.Servicios;

namespace ejer15.Controllers
{
    public class EntradasController : ApiController
    {
        private IEntradasService entradasService;

        public EntradasController(IEntradasService _entradasService)
        {
            this.entradasService = _entradasService;
        }

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return entradasService.Get();
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada entrada = entradasService.Get(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.Id)
            {
                return BadRequest();
            }

            try
            {
                entradasService.Put(entrada);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entrada = entradasService.Create(entrada);

            return CreatedAtRoute("DefaultApi", new { id = entrada.Id }, entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada entrada;
            try
            {
                entrada = entradasService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(entrada);
        }
    }
}