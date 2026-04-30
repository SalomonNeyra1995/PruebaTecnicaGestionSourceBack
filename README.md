# API de Casas - CRUD con .NET 7 y SQL Server

API REST para gestión de casas (CRUD) desarrollada con .NET 7, Entity Framework Core y SQL Server. Incluye endpoints para listar, crear, actualizar y eliminar registros (borrado lógico).

## 📋 Requisitos previos

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) (o superior compatible)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (2019 o superior).
- [Git](https://git-scm.com/) (para clonar el repositorio)
- [Postman](https://www.postman.com/) (opcional, para probar los endpoints)

## 🚀 Instrucciones para ejecutar la API localmente

Sigue estos pasos en orden:

### 1. Clonar el repositorio
 bash
git clone https://github.com/SalomonNeyra1995/PruebaTecnicaGestionSourceBack.git
cd PruebaTecnicaGestionSourceBack

### 2. Crear la base de datos y la tabla
Ejecuta el script SQL que se encuentra en la raíz del proyecto (migration.sql) sobre tu instancia de SQL Server.
Puedes hacerlo desde SQL Server Management Studio (SSMS) o con sqlcmd:
sqlcmd -S DESKTOP-M91V76V -U sa -P 123456 -d master -i migration.sql
Reemplaza DESKTOP-M91V76V por el nombre de tu servidor.
Reemplaza sa y 123456 por tu usuario y contraseña.
El script creará la base de datos CasasDB y la tabla Casas.
Si prefieres crear la base manualmente, ejecuta primero CREATE DATABASE CasasDB; y 
luego ejecuta solo la parte de creación de la tabla (dentro de la base CasasDB).

### 3. Configurar la cadena de conexión
Abre el archivo appsettings.json (dentro del proyecto PruebaTecnicaGestionSource) y modifica la sección ConnectionStrings:
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-M91V76V;Database=CasasDB;User Id=sa;Password=123456;TrustServerCertificate=true;"
}
Ajusta Server, User Id y Password según tu entorno. Si usas autenticación de Windows, 
usa Trusted_Connection=True; y elimina User Id y Password.

### 4. Ejecutar la API
Desde Visual Studio 2022
Abre el archivo PruebaTecnicaGestionSource.sln.
Presiona F5 (Iniciar depuración).
Swagger se abrirá automáticamente en https://localhost:7137/swagger.
Desde la línea de comandos
cd PruebaTecnicaGestionSource
dotnet run

La API estará disponible en https://localhost:7137 (el puerto puede variar; revisa la consola). Accede a https://localhost:7137/swagger para probar los endpoints.

📌 Endpoints disponibles
Método	Endpoint	Descripción
GET	/api/casas	Lista todas las casas activas
GET	/api/casas/{id}	Obtiene una casa por ID
POST	/api/casas	Crea una nueva casa
PUT	/api/casas/{id}	Actualiza una casa existente
DELETE	/api/casas/{id}	Elimina una casa (borrado lógico)


🛠️ Tecnologías utilizadas
.NET 7

Entity Framework Core 7 (con SQL Server)

SQL Server

Swagger / OpenAPI

👨‍💻 Autor
Salomón Neyra – PruebaTecnicaGestionSourceBackend






