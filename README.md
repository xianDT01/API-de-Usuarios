# API de Usuarios

## Descripción
Esta es una API RESTful diseñada para gestionar usuarios mediante operaciones CRUD (Crear, Leer, Actualizar, Eliminar). La API utiliza autenticación JWT para garantizar la seguridad de las operaciones y permite la validación de datos.

## Características
- **Autenticación**: Utiliza JSON Web Tokens (JWT) para autenticar a los usuarios.
- **Operaciones CRUD**: Permite realizar las siguientes operaciones:
  - Crear un nuevo usuario
  - Obtener la lista de usuarios
  - Obtener un usuario específico por ID
  - Actualizar un usuario existente
  - Eliminar un usuario
- **Validaciones**: Incluye validaciones en el modelo de datos para asegurar que los datos sean correctos antes de ser procesados.

## Tecnologías
- ASP.NET Core
- Entity Framework Core
- SQLite
- JWT (JSON Web Tokens)

## Endpoints
### Autenticación
- `POST /api/auth/login`
  - **Descripción**: Inicia sesión y genera un token JWT.
  - **Cuerpo**:
    ```json
    {
      "username": "string",
      "password": "string"
    }
    ```

### Usuarios
- `GET /api/usuarios`
  - **Descripción**: Obtiene la lista de usuarios.
  
- `GET /api/usuarios/{id}`
  - **Descripción**: Obtiene un usuario específico por ID.

- `POST /api/usuarios`
  - **Descripción**: Crea un nuevo usuario.
  - **Cuerpo**:
    ```json
    {
      "nombre": "string",
      "correoElectronico": "string",
      "passwordHash": "string"
    }
    ```

- `PUT /api/usuarios/{id}`
  - **Descripción**: Actualiza un usuario existente.
  - **Cuerpo**:
    ```json
    {
      "id": 1,
      "nombre": "string",
      "correoElectronico": "string",
      "passwordHash": "string"
    }
    ```

- `DELETE /api/usuarios/{id}`
  - **Descripción**: Elimina un usuario por ID.

## Instalación
1. Clona el repositorio:
   ```bash
   git clone https://github.com/xianDT01/ApiUsuarios.git
