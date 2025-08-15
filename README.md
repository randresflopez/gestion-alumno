# Proyecto: API RESTful y Front-End para Gestión de Alumnos

Este proyecto es una aplicación completa para la gestión de registros de alumnos, que consta de una API RESTful desarrollada en .NET y una interfaz de usuario básica creada con React.

### Características Principales

* **API RESTful en .NET:**
    * Desarrollada con **ASP.NET Core**.
    * **Autenticación Básica** para proteger los endpoints.
    * **Inserción de Registros:** Permite agregar nuevos alumnos a la base de datos.
    * **Consulta de Registros:** Permite buscar alumnos por grado.
* **Base de Datos MySQL:**
    * Utiliza **MySQL** para el almacenamiento de datos.
    * El acceso se gestiona a través de **Entity Framework Core**.
* **Front-End en React:**
    * Desarrollado con **React** y **Bootstrap** para una interfaz limpia y responsiva.
    * Interactúa con la API para **insertar** y **consultar** datos de alumnos en tiempo real.

---

### Requisitos de Software

Para ejecutar este proyecto, necesitas las siguientes herramientas instaladas en tu sistema:

* **.NET SDK 8.0 o superior:** [https://dotnet.microsoft.com/download/dotnet/8.0]
* **Node.js y npm:** [https://nodejs.org/]
* **MySQL Server y MySQL Workbench:** [https://dev.mysql.com/downloads/workbench/]
* **Un editor de código:** (Visual Studio Code, Visual Studio, etc.)

---

### Configuración y Ejecución del Proyecto

Sigue estos pasos en orden para poner en marcha la aplicación.

#### Paso 1: Configurar la Base de Datos (Back-End)

1.  Abre **MySQL Workbench** y crea una base de datos llamada `EscuelaDB`.
2.  Navega a la carpeta de la API (`AlumnosApi`).
3.  Abre el archivo `appsettings.json` y actualiza la cadena de conexión con tu contraseña de MySQL.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=EscuelaDB;Uid=root;Pwd=5W11y8m1.,;"
    }
    ```
4.  Abre una terminal en la carpeta `AlumnosApi` y ejecuta las migraciones para crear la tabla de alumnos:
    ```bash
    dotnet ef database update
    ```
5.  Inicia la API:
    ```bash
    dotnet run
    ```

#### Paso 2: Configurar y Ejecutar el Front-End

1.  Abre una **nueva terminal** y navega a la carpeta del front-end (`alumnos-front`).
2.  Instala las dependencias de React:
    ```bash
    npm install
    ```
3.  Asegúrate de que la URL de la API en `src/components/AlumnosForm.js` y `src/components/AlumnosList.js` sea correcta (por ejemplo, `http://localhost:5062/api/Alumnos`).
4.  Inicia la aplicación de React:
    ```bash
    npm start
    ```

La aplicación se abrirá automáticamente en tu navegador predeterminado.

---

### Uso de la API

Puedes usar herramientas como **Postman** o **Insomnia** para probar la API directamente.

**Endpoints:**

* **`POST /api/Alumnos`**: Inserta un nuevo alumno.
    * **Headers:** `Authorization: Basic YWRtaW46cGFzc3dvcmQ=`
    * **Body:** `application/json` con los datos del alumno.
* **`GET /api/Alumnos/grado?grado={nombre_grado}`**: Consulta los alumnos de un grado específico.
    * **Headers:** `Authorization: Basic YWRtaW46cGFzc3dvcmQ=`

---

### Autor

* RicardoFuentes