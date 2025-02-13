//Creacion de la Base de Datos

CREATE DATABASE Unigis;

CREATE TABLE [dbo].[Usuarios] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]       NVARCHAR (50)  NOT NULL,
    [Login]        NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR (MAX) NOT NULL,
    [Rol]          NVARCHAR (10)  CHECK (Rol IN ('Admin', 'Usuario')) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Productos] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (100)  NOT NULL,
    [Alto]          DECIMAL (18, 2) ,
    [Ancho]         DECIMAL (18, 2) ,
    [Profundidad]   DECIMAL (18, 2) ,
    [Volumen]       DECIMAL (18, 2) ,
    [Peso]          DECIMAL (18, 2) ,
    [FechaCreacion] DATETIME        CONSTRAINT [DEFAULT_Productos_FechaCreacion] DEFAULT GETDATE() NOT NULL,
    [Activo]        BIT             CONSTRAINT [DEFAULT_Productos_Activo] DEFAULT 1 ,
    CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([Id] ASC)
);



//Instalar Paquetes

dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package FluentValidation
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

//Cambiar la cadena conexion que se encuentra en el archivo appsettings.json por sus respectivos accesos
"UnigisConnection" : "Server=localhost,1433; Database=Unigis; User=sa; Password=; Trust Server Certificate=True"
