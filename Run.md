Guía de Ejecución del Proyecto
Este documento describe los pasos necesarios para clonar, configurar y ejecutar esta API en un entorno de desarrollo local.

Prerrequisitos
Antes de comenzar, asegúrate de tener instalado el siguiente software en tu máquina:

.NET SDK 9.0 o superior.

Git para clonar el repositorio.

Pasos para la Ejecución
Sigue estas instrucciones desde tu terminal o línea de comandos preferida.

1. Clonar el Repositorio
Primero, clona el código fuente del proyecto desde su repositorio.

git clone https://github.com/RamiroItok/MELI.Challenge.git

3. Navegar a la Carpeta del Proyecto
Ingresa al directorio que se acaba de crear.

cd MELI.Challenge

5. Restaurar Dependencias
Este comando descargará todos los paquetes de NuGet necesarios para que la solución funcione correctamente

dotnet restore

7. Ejecutar la API
Este es el comando final para compilar y ejecutar el proyecto de API. La aplicación se iniciará y quedará escuchando peticiones HTTP.

dotnet run --project MELI.Challenge.API/MELI.Challenge.API.csproj

Acceder a la API
Una vez que el comando anterior se ejecute exitosamente, verás un mensaje en la consola indicando que la aplicación está escuchando en una URL, por ejemplo: https://localhost:5051.

Abre tu navegador web.

Navega a la URL de la documentación interactiva de Swagger, que generalmente es la URL base seguida de /swagger.

Ejemplo: https://localhost:5051/swagger

Desde la interfaz de Swagger, podrás ver todos los endpoints disponibles, sus detalles y ejecutarlos directamente para probar la funcionalidad de la API.
