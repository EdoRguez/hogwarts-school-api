# Hogwarts School Api

API para el Colegio de Magia y Hechicer铆a Hogwarts que requiere dise帽ar su sistema de inscripciones para el pr贸ximo periodo acad茅mico.

## Comenzando 馃殌

Estas instrucciones te permitir谩n obtener una copia del proyecto en funcionamiento en tu m谩quina local para prop贸sitos de desarrollo y pruebas.

Adicionalmente el repositorio contiene un archivo PDF **(Hogwarts School API Documentation.pdf)** el cual contiene documentaci贸n acerca de como hacer las peticiones a la API.


### Pre-requisitos 馃搵

Que cosas necesitas para su instalaci贸n

```
- .NET Core 3.1
- Microsoft SQL Server
```

### Instalaci贸n 馃敡

Los siguientes pasos deben de llevarse a cabo para poder utilizar el proyecto.

1. Descargar o clonar el repositorio.

2. Abrir el proyecto en Visual Studio.

3. Modificar el connection string del archivo appsettings.json para que lea tu servidor de SQL Server local. Actualmente el servidor que aparece es el de mi m谩quina local personal.

```
"ConnectionStrings": {
    "sqlConnection": "Server=DESKTOP-THA70A1\\SQLSERVER;Database=HogwartsDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

4. Utilizar el siguiente comando usando el "package manager console" para que Entity Framework cree la base de datos, modelos y tablas automaticamente.

```
update-database
```

## Ejecutando las pruebas 鈿欙笍

Para ejecutar pruebas es necesario usar herramientas como **Postman** o en su defecto usar las pruebas que **Swagger** nos permite realizar en la siguiente URL local del proyecto: _/swagger/index.html_.

Podemos comenzar a hacer peticiones GET, PUT o DELETE, pero estas no nos servir谩n de nada si no tenemos informaci贸n, as铆 que la primera petici贸n que debemos realizar es la POST siguiendo el siguiente esquema.

```
{
  "name": "Test",
  "lastName": "Test",
  "identification": 12345,
  "age": 20,
  "id_House": 1
}
```

Esta petici贸n la podemos realizar cuantas veces sea de preferencia, recomiendo que en cada petici贸n se utilice diferentes datos para as铆 tener datos guardados variados.

Ya una vez con datos guardados podremos hacer peticiones GET, PUT o DELETE los cuales trabajar谩n y mostrar谩n los datos guardados.

## Construido con 馃洜锔?

* [.NET Core 3.1](https://dotnet.microsoft.com/download) - Framework utlizado
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Base de datos
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - ORM
* [Visual Studio 2019](https://visualstudio.microsoft.com/es/launch/) - IDE


## Autores 鉁掞笍

* **Eduardo Rodr铆guez** - *Autor* - [edorguez](https://github.com/edorguez)

