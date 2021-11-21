# Hogwarts School Api

API para el Colegio de Magia y Hechicería Hogwarts que requiere diseñar su sistema de inscripciones para el próximo periodo académico.

## Comenzando 🚀

Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas.

Adicionalmente el repositorio contiene un archivo PDF **(Hogwarts School API Documentation.pdf)** el cual contiene documentación acerca de como hacer las peticiones a la API.


### Pre-requisitos 📋

Que cosas necesitas para su instalación

```
- .NET Core 3.1
- Microsoft SQL Server
```

### Instalación 🔧

Los siguientes pasos deben de llevarse a cabo para poder utilizar el proyecto.

1. Descargar o clonar el repositorio.

2. Abrir el proyecto en Visual Studio.

3. Modificar el connection string del archivo appsettings.json para que lea tu servidor de SQL Server local. Actualmente el servidor que aparece es el de mi máquina local personal.

```
"ConnectionStrings": {
    "sqlConnection": "Server=DESKTOP-THA70A1\\SQLSERVER;Database=HogwartsDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

4. Utilizar el siguiente comando usando el "package manager console" para que Entity Framework cree la base de datos, modelos y tablas automaticamente.

```
update-database
```

## Ejecutando las pruebas ⚙️

Para ejecutar pruebas es necesario usar herramientas como **Postman** o en su defecto usar las pruebas que **Swagger** nos permite realizar en la siguiente URL local del proyecto: _/swagger/index.html_.

Podemos comenzar a hacer peticiones GET, PUT o DELETE, pero estas no nos servirán de nada si no tenemos información, así que la primera petición que debemos realizar es la POST siguiendo el siguiente esquema.

```
{
  "name": "Test",
  "lastName": "Test",
  "identification": 12345,
  "age": 20,
  "id_House": 1
}
```

Esta petición la podemos realizar cuantas veces sea de preferencia, recomiendo que en cada petición se utilice diferentes datos para así tener datos guardados variados.

Ya una vez con datos guardados podremos hacer peticiones GET, PUT o DELETE los cuales trabajarán y mostrarán los datos guardados.

## Construido con 🛠️

* [.NET Core 3.1](https://dotnet.microsoft.com/download) - Framework utlizado
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Base de datos
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - ORM
* [Visual Studio 2019](https://visualstudio.microsoft.com/es/launch/) - IDE


## Autores ✒️

* **Eduardo Rodríguez** - *Autor* - [edorguez](https://github.com/edorguez)

