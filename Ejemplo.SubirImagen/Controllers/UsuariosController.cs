using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Dominio;
using WebApplication1.Dominio.Entidades;
using System.Linq;
using System.Text.RegularExpressions;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuariosServicio _usuariosServicio = new UsuariosServicio();

        // GET: Usuarios
        public ActionResult Index()
        {
            ViewBag.NuevoUsuarioCreado = EsNuevoUsuario();

            var usuarios = _usuariosServicio.ObtenerUsuarios();

            return View(usuarios);
        }

        // GET: Usuarios/Create
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                string nombreSignificativo = usuario.NombreSignificativoImagen;
                //Guardar Imagen
                string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                usuario.FotoPerfil = pathRelativoImagen;
            }

            _usuariosServicio.Agregar(usuario);

            TempData["usuarioCreado"] = true;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Usuario usuarioBD = _usuariosServicio.ObtenerUsuarios().FirstOrDefault(o => o.IdUsuario == id);
            return View(usuarioBD);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            Usuario usuarioBD = _usuariosServicio.ObtenerUsuarios().FirstOrDefault(o => o.IdUsuario == usuario.IdUsuario);

            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                if (!string.IsNullOrEmpty(usuario.FotoPerfil))
                {
                    //recordar eliminar la foto anterior si tenia
                    if (!string.IsNullOrEmpty(usuarioBD.FotoPerfil))
                    {
                        ImagenesUtility.Borrar(usuario.FotoPerfil);
                    }

                    //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                    string nombreSignificativo = usuario.NombreSignificativoImagen;
                    //Guardar Imagen
                    string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                    usuarioBD.FotoPerfil = pathRelativoImagen;
                }
            }

            usuarioBD.Apellido = usuario.Apellido;
            usuarioBD.Nombre = usuario.Nombre;

            TempData["usuarioCreado"] = true;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {            
            Usuario usuarioBD = _usuariosServicio.ObtenerUsuarios().FirstOrDefault(o => o.IdUsuario == id);
            if (!string.IsNullOrEmpty(usuarioBD.FotoPerfil))
            {
                ImagenesUtility.Borrar(usuarioBD.FotoPerfil);
            }

            _usuariosServicio.Eliminar(id);
            return RedirectToAction("Index");
        }

        private bool EsNuevoUsuario()
        {
            return TempData["usuarioCreado"] != null;
        }
    }
}
