namespace WebApplication1.Dominio.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        /// <summary>
        /// Path relativo donde se guarda la imagen
        /// </summary>
        public string FotoPerfil { get; set; }

        public string NombreSignificativoImagen
        {
            get
            {
                //en caso de ambos null, devuelve "ApellidoNombre"
                return string.Format("{0}{1}", this.Apellido ?? "Apellido", this.Nombre ?? "Nombre");
            }
        }

    }
}