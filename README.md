# PruebaAPI
Solución hecha en Visual Studio
<br>
<br>
1- Crear la base de datos (vacía). Se debe de llamar PruebaAPI, si se desea cambiar el nombre, se debe de incluir ese nombre nuevo en el string de conexión.
<br>
<br>
2- Correr script anexo en el correo para popular la base de datos.
<br>
<br>
3- Cambiar string de conexión apuntando a la nueva base de datos creada. Se debe de cambiar en dos lugares.
<br>
  ... En el appsetting.json del proyecto API
<br>
  ... En la clase PruebaAPIDBContext del proyecto DL (optionsBuilder.UseSqlServer)
<br>
<br>
4. Si la carpeta WEB/ClientApp no tiene los node_modules instalados, abrir un CMD en la carpeta ClientApp del proyecto WEB y ejecutar el comando npm install, para descargar los node_modules
<br>
<br>
5. Elegir los "Set Start Projects" seleccionar los proyectos WEB y API
<br>
<br>
6. Ejecutar Visual Studio
