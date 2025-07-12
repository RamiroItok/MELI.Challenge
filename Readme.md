Desafío Backend - API de Detalles de Producto

Este proyecto es una implementación de una API de backend desarrollada como parte de un desafío técnico. El objetivo es proporcionar todos los datos necesarios para renderizar una página de detalles de un producto, inspirada en el diseño de Mercado Libre.

Arquitectura Implementada

El proyecto sigue los principios de Arquitectura Limpia (Clean Architecture), separando las responsabilidades en distintas capas para lograr un sistema desacoplado, mantenible y fácil de probar.

* Domain: Contiene la lógica y las reglas de negocio más puras. Define las entidades (Item, Review), los objetos (Price, SellerInfo) y los contratos (interfaces de los repositorios como IItemRepository). No depende de ninguna otra capa.

* Application, es como si fuera un Orquestador: Contiene los casos de uso específicos de la aplicación. Implementa el patrón CQRS (Command Query Responsibility Segregation) con Requests y Handlers para orquestar el flujo de datos entre la API y el Dominio.

* Infrastructure: Implementa los contratos definidos en el Dominio. Se encarga del acceso a datos (leyendo los archivos .json), comunicación con servicios externos, etc.

* API: Expone la funcionalidad al mundo exterior a través de una API REST. Es responsable de la configuración, el enrutamiento, la autenticación y la validación de las peticiones. Es el punto de ensamblaje de todas las capas a través de la Inyección de Dependencias.

* Tests: contiene los métodos de prueba necesarios para comprobar la correcta funcionalidad del servicio. Se utiliza Unit Testing, con la librería xUnit. 

La regla fundamental es la Inversión de Dependencias: todas las dependencias apuntan hacia el interior, hacia el Domain, haciendo que el núcleo del negocio sea independiente de los detalles de implementación.

¿Por que se utiliza el patrón CQRS?

Este patrón Command Query Responsibility Segregation implica:
* Crecimiento Sostenible: Es fácil agregar nueva funcionalidad. Solo creas un nuevo par de archivos (petición y manejador) y no tocas nada de lo que ya existe y funciona.
* Paralelismo en Equipos: Si dos desarrolladores necesitan trabajar en dos funcionalidades distintas, es muy poco probable que editen los mismos archivos, lo que reduce los conflictos de código.
* Rendimiento: Permite optimizar las lecturas (Queries) de forma separada a las escrituras (Commands), lo cual es muy útil en sistemas de alto rendimiento.
* Escalabilidad independiente
* Single-responsibility principle

Estrategia técnica:

Tecnologías Utilizadas
- .NET 9
- ASP.NET Core: Para la construcción de la API REST.
- Documentación de API: Swagger (OpenAPI).
- Pruebas testing unitario: xUnit.
- Persistencia de Datos: Archivos JSON locales.

GenAI:

Se utilizó un asistente de IA (Gemini) como consultor técnico durante todo el proceso. Su rol fue importante para mejorar la eficiencia en varias áreas:
* Diseño Arquitectónico y Tutoría: El asistente ayudó a definir y explicar los fundamentos de la Arquitectura Limpia, el patrón CQRS y el Principio de Inversión de Dependencias, asegurando que la base del proyecto fuera sólida y siguiera las mejores prácticas
