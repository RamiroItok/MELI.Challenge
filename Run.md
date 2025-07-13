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
2. Navegar a la Carpeta Raíz del Proyecto
Ingresa al directorio que se acaba de crear, que contiene la solución completa.

cd MELI.Challenge
3. Restaurar Dependencias
Este comando descarga todos los paquetes de NuGet necesarios. Aunque dotnet run lo hace automáticamente, ejecutarlo por separado es una buena práctica para asegurar que todo esté en orden.

dotnet restore
4. Ejecutar la Aplicación (Método Recomendado)
Este es el paso clave. Con un solo comando, compilaremos y ejecutaremos la API utilizando el perfil de lanzamiento correcto, el mismo que usa Visual Studio. Esto evita el error 404.

dotnet run --project MELI.Challenge.API --launch-profile https

Acceder a la API
Una vez que el comando anterior se ejecute exitosamente, verás un mensaje en la consola indicando que la aplicación está escuchando en una URL, por ejemplo: https://localhost:7130.

Abre tu navegador web.

Navega a la URL de la documentación interactiva de Swagger, que generalmente es la URL base seguida de /swagger.

Ejemplo: https://localhost:7130/swagger

Desde la interfaz de Swagger, podrás ver todos los endpoints disponibles, sus detalles y ejecutarlos directamente para probar la funcionalidad de la API.
