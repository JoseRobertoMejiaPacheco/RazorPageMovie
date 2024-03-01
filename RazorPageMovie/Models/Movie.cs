using Azure.Core;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Formats.Asn1.AsnWriter;

namespace RazorPageMovie.Models
{
    public class Movie
    {
        //Id
        //Title
        //ReleaseDate
        //Genre
        //Price
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.DateTime)]
        //Indica al framework que debe generar un control de entrada de fecha y hora en la vista asociada a ese formulario,
        //y también podría realizar validaciones automáticas para garantizar que el usuario ingrese una fecha y hora válida
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string? Rating { get; set; }
        //Agregando el scaffolding se crea la estructura de ficheros para crear una pagina por cada modelo para su crud, parecido a odoo orm, alchemy, dapper etc... pero con .Net
        //Paginas de Razor CRUD

        //Una vez realizado el scaffold nos habilita las url de cada pagina creada http://localhost:5179/Movies/Create ya con un formulario establecido
        //Para que haga conexion es necesario instalar sql server ya que se conecta de manera local
        //SqlException: Cannot open database "RazorPageMovieContextDb-acb8b26b-c355-4425-8eb7-87264b227be0" requested by the login.The login failed.
        //Login failed for user 'DESKTOP-2LFP097\isscj'.

        //Desde PM ejecutar # Add-Migration InitialCreate 
        //    Tools > NuGet Package Manager > Package Manager Console

        //Con eso se agrega la carpeta Migrations donde estara el ContextDB de cada modelo y las creaciones iniciales de los modelos/tablas
        //Ejecutar en PM #Update-Database para mandar los cambios a la base de datos
        //Hasta este punto ya se puede realizar el CRUD sin problemas
        //La clase SeedData se usa para crear objetos en cuanto se inicialice, para que inicialice se debe realizar la instancia en la clase program.cs
        //Para que pueda ser instanciada desde cualquier lugar se debe definir la clase como estatica y publica
        //var app = builder.Build();
        //using (var scope =app.Services.CreateScope())
        //{
        //    var services = scope.ServiceProvider;
        //    SeedData.Initialize(services);
        //}

        //Si hay un error en el nombre de alguna variable y se renombra se debe hacer lo siguiente para eliminar las migraciones y borrar la base de datos desde PM
        //Elimina las migraciones existentes:
        //    #Get-Migration
        //    #Update-Database -Migration    
        //    #Update-Database -Migration 20240301041000_InitialCreate
        //    #Remove-Migration
        //    #Drop-Database
        //    #Add-Migration InitialCreate
        //    #Add-Migration InitialCreate
        //    #Update-Database
        //Update-Database -Migration 20240301050830_Updated 



    }
}
