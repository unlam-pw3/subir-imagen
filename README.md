# **DESCRIPCIÓN**
Ejemplo simple para **subir una imagen** en un formulario utilizando **ASP.NET MVC** fmk 4.5

# **CONFIGURACIONES**
* En el **web.config** dentro de `appSettings` esta configurada la carpeta /Imagenes como carpeta destino, puede modificarse ej: `<add key="CarpetaImagenes" value="/Imagenes"/>`
* En el **web.config** se puede configurar el tamaño maximo de archivo (por defecto son 4MB), esto se hace modificando el valor de maxRequestLength en `httpRuntime` ej: `<httpRuntime maxRequestLength="21096"/>`

# **CONSIDERACIONES**
* No estan contempladas validaciones en el formulario de ningun tipo.
* Al momento de guardar la imagen, **se está generando un nombre único** para que la imagen no se repita y evitar pisar otra imagen guardada, para esto se esta utilizando una formula de `{Nombre,8 carac}-{Random,5 carac}` donde Nombre debería tener algun valor significativo, en este caso Apellido+Nombre, y Random es un alfanumerico aleatorio de 5 caracteres.


# **PANTALLAS**

## **INICIO**
![](https://user-images.githubusercontent.com/28361952/27363230-90d9931e-5609-11e7-9f8a-f6a08458fc56.png)

## **CREAR USUARIOS**
![](https://user-images.githubusercontent.com/28361952/27363231-90f96428-5609-11e7-8bda-7b9fac04eeeb.png)

## **LISTAR**
![](https://user-images.githubusercontent.com/28361952/27363232-910cb910-5609-11e7-84b6-8ed789e74688.png)

## **MODAL PREVIEW IMAGEN**
![](https://user-images.githubusercontent.com/28361952/27363234-91138c36-5609-11e7-8676-5adceb672450.png)

## **EDITAR**
![](https://user-images.githubusercontent.com/28361952/27363233-910fa27e-5609-11e7-907b-f448f190fa12.png)
