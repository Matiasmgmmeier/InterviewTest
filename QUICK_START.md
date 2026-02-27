# 🚀 Quick Start Guide

Guía rápida para poner en marcha el proyecto en menos de 5 minutos.

## ✅ Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

- ✔️ .NET 8 SDK ([Descargar](https://dotnet.microsoft.com/download/dotnet/8.0))
- ✔️ MySQL Server 8.0+ ([Descargar](https://dev.mysql.com/downloads/mysql/))
- ✔️ Un editor de código (Visual Studio, VS Code, o Rider)

## 📦 Paso 1: Configurar MySQL

### Opción A: MySQL Local

1. Inicia MySQL Server
2. Crea un usuario y contraseña (o usa root)

### Opción B: MySQL con Docker (Recomendado)

```bash
docker run --name mysql-cleanarch -e MYSQL_ROOT_PASSWORD=root -p 3306:3306 -d mysql:8.0
```

## ⚙️ Paso 2: Configurar la Cadena de Conexión

Edita el archivo `src/CleanArchitecture.WebAPI/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=CleanArchitectureDB;User=root;Password=TU_PASSWORD;"
  }
}
```

**Importante**: Reemplaza `TU_PASSWORD` con tu contraseña real de MySQL.

## 🗄️ Paso 3: Crear la Base de Datos

Abre una terminal en la carpeta raíz del proyecto y ejecuta:

```bash
dotnet ef database update --project src/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj --startup-project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj
```

Este comando:
- ✅ Crea la base de datos `CleanArchitectureDB`
- ✅ Crea las 3 tablas (Usuario, Factura, DetalleFactura)
- ✅ Inserta datos de ejemplo (3 usuarios, 3 facturas, 9 detalles)

## 🎯 Paso 4: Ejecutar la Aplicación

```bash
dotnet run --project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj
```

La aplicación estará disponible en:
- 🌐 HTTP: http://localhost:5000
- 🔒 HTTPS: https://localhost:5001
- 📚 Swagger: https://localhost:5001/swagger

## 🧪 Paso 5: Probar la API

### Opción A: Usar Swagger UI

1. Abre tu navegador en: https://localhost:5001/swagger
2. Explora los endpoints disponibles
3. Prueba cualquier endpoint haciendo clic en "Try it out"

### Opción B: Usar cURL

```bash
# Obtener todos los usuarios
curl -X GET "https://localhost:5001/api/usuarios" -k

# Obtener una factura con detalles
curl -X GET "https://localhost:5001/api/facturas/1" -k

# Crear un nuevo usuario
curl -X POST "https://localhost:5001/api/usuarios" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Test User",
    "email": "test@example.com",
    "telefono": "+34 600 000 000",
    "activo": true
  }' -k
```

### Opción C: Usar Postman

1. Importa la colección desde Swagger
2. Configura la URL base: `https://localhost:5001`
3. Desactiva la verificación SSL en Settings

## 📊 Datos de Ejemplo Incluidos

El proyecto viene con datos de prueba:

### Usuarios
| ID | Nombre | Email | Estado |
|----|--------|-------|--------|
| 1 | Juan Pérez | juan.perez@email.com | Activo |
| 2 | María García | maria.garcia@email.com | Activo |
| 3 | Carlos López | carlos.lopez@email.com | Inactivo |

### Facturas
| ID | Número | Usuario | Total | Estado |
|----|--------|---------|-------|--------|
| 1 | FAC-2024-001 | Juan Pérez | $1,250.50 | Pagada |
| 2 | FAC-2024-002 | María García | $850.75 | Pendiente |
| 3 | FAC-2024-003 | Juan Pérez | $2,100.00 | Pagada |

## 🔧 Solución de Problemas

### Error: "Unable to connect to MySQL"

**Solución:**
1. Verifica que MySQL esté corriendo: `mysql -u root -p`
2. Verifica la cadena de conexión en `appsettings.json`
3. Asegúrate de que el puerto 3306 esté disponible

### Error: "dotnet ef command not found"

**Solución:**
```bash
dotnet tool install --global dotnet-ef --version 8.0.11
```

### Error: "Build failed"

**Solución:**
```bash
# Limpiar y reconstruir
dotnet clean
dotnet build
```

### Error: "Port 5001 already in use"

**Solución:**
Edita `src/CleanArchitecture.WebAPI/Properties/launchSettings.json` y cambia los puertos.

## 📁 Estructura del Proyecto

```
CleanArchitectureDemo/
├── src/
│   ├── CleanArchitecture.Domain/          # Entidades e Interfaces
│   ├── CleanArchitecture.Application/     # Servicios y DTOs
│   ├── CleanArchitecture.Infrastructure/  # Repositorios y DbContext
│   └── CleanArchitecture.WebAPI/          # API REST
├── README.md                               # Documentación completa
├── API_EXAMPLES.md                         # Ejemplos de uso de la API
├── INTERVIEW_GUIDE.md                      # Guía para entrevistas
└── QUICK_START.md                          # Esta guía
```

## 🎓 Próximos Pasos

1. **Explora el código**: 
   - Revisa las entidades en `Domain/Entities/`
   - Mira los servicios en `Application/Services/`
   - Estudia los controladores en `WebAPI/Controllers/`

2. **Prueba los endpoints**:
   - Consulta `API_EXAMPLES.md` para ejemplos detallados
   - Experimenta con Swagger UI

3. **Prepárate para entrevistas**:
   - Lee `INTERVIEW_GUIDE.md`
   - Practica explicando la arquitectura
   - Prepara respuestas sobre patrones de diseño

4. **Personaliza el proyecto**:
   - Agrega nuevas entidades
   - Implementa validaciones
   - Agrega autenticación JWT

## 📚 Documentación Adicional

- **README.md**: Documentación completa del proyecto
- **API_EXAMPLES.md**: Ejemplos de uso de todos los endpoints
- **INTERVIEW_GUIDE.md**: Preguntas y respuestas para entrevistas técnicas

## 💡 Comandos Útiles

```bash
# Ver migraciones aplicadas
dotnet ef migrations list --project src/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj --startup-project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj

# Crear nueva migración
dotnet ef migrations add NombreMigracion --project src/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj --startup-project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj

# Revertir última migración
dotnet ef migrations remove --project src/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj --startup-project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj

# Ver SQL que se ejecutará
dotnet ef migrations script --project src/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj --startup-project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj

# Compilar solución
dotnet build

# Ejecutar tests (cuando los agregues)
dotnet test

# Publicar para producción
dotnet publish -c Release
```

## 🎉 ¡Listo!

Tu proyecto está configurado y funcionando. Ahora puedes:

- ✅ Explorar la API con Swagger
- ✅ Probar los endpoints
- ✅ Estudiar el código
- ✅ Prepararte para entrevistas

**¿Necesitas ayuda?** Consulta los otros archivos de documentación o revisa el código fuente.

---

**¡Buena suerte con tus entrevistas! 🚀**
