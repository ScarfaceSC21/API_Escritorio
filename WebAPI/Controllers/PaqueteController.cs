using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {
        public readonly DbA9ed7aPaqueteriaContext _dbcontext;

        public PaqueteController(DbA9ed7aPaqueteriaContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public List<Paquete> Lista()
        {
            List<Paquete> lista = new List<Paquete>();

            try
            {
                lista = _dbcontext.Paquetes.ToList();

                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
        }

        [HttpGet]
        [Route("Obtener/{cajon}")]
        public IActionResult Obtener(int cajon)
        {
            try
            {
                var oPaquete = _dbcontext.Paquetes.Where(p => p.Cajon == cajon).ToList();
                
                return Ok(oPaquete);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Paquete objeto)
        {
            try
            {
                _dbcontext.Paquetes.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Paquete objeto)
        {
           Paquete oPaquete = _dbcontext.Paquetes.Find(objeto.Iidpaquete);


            if (oPaquete == null)
            {
                return BadRequest("El cajon no existe");
            }

            try
            {
                oPaquete.Cajon = objeto.Cajon is null ? oPaquete.Cajon : objeto.Cajon;
                oPaquete.Tracking = objeto.Tracking is null ? oPaquete.Tracking : objeto.Tracking;
                oPaquete.Nombre = objeto.Nombre is null ? oPaquete.Nombre : objeto.Nombre;
                oPaquete.Tipo = objeto.Tipo is null ? oPaquete.Tipo : objeto.Tipo;
                oPaquete.Precio = objeto.Precio is null ? objeto.Precio : objeto.Precio;
                oPaquete.Fechasalida = objeto.Fechasalida is null ? oPaquete .Fechasalida : objeto.Fechasalida;
                oPaquete.Firma = objeto.Firma is null ? oPaquete.Firma : objeto.Firma;

                _dbcontext.Paquetes.Update(oPaquete);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idPaquete:int}")]
        public IActionResult Eliminar(int idPaquete)
        {
            Paquete oPaquete = _dbcontext.Paquetes.Find(idPaquete);


            if (oPaquete == null)
            {
                return BadRequest("El cajon no existe");
            }

            try
            {

                _dbcontext.Paquetes.Remove(oPaquete);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
