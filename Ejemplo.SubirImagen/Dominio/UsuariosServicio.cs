using System.Collections.Generic;
using WebApplication1.Dominio.Entidades;
using System.Linq;

namespace WebApplication1.Dominio
{
    public class UsuariosServicio
    {
        private static readonly List<Usuario> Usuarios = new List<Usuario>();

        public List<Usuario> ObtenerUsuarios()
        {
            return Usuarios;
        }

        public void Agregar(Usuario usuario)
        {
            usuario.IdUsuario = Usuarios.Count + 1;
            Usuarios.Add(usuario);
        }

        public void Modificar(Usuario usuario)
        {
            //Usuarios.FirstOrDefault(o=> o.Id );
            Usuarios.Add(usuario);
        }

        public void Eliminar(int idUsuario)
        {
            Usuarios.RemoveAll(o => o.IdUsuario == idUsuario);
        }
    }
}