# Ejemplos de Uso de la API

Este archivo contiene ejemplos prácticos de cómo usar todos los endpoints de la API.

## 🚀 Antes de Empezar

1. Asegúrate de que la base de datos esté creada:
```bash
dotnet ef database update --project src/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj --startup-project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj
```

2. Ejecuta la aplicación:
```bash
dotnet run --project src/CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj
```

3. La API estará disponible en: `https://localhost:5001` o `http://localhost:5000`

## 📋 Usuarios

### Obtener todos los usuarios
```bash
curl -X GET "https://localhost:5001/api/usuarios" -k
```

### Obtener usuario por ID
```bash
curl -X GET "https://localhost:5001/api/usuarios/1" -k
```

### Obtener usuario por email
```bash
curl -X GET "https://localhost:5001/api/usuarios/email/juan.perez@email.com" -k
```

### Obtener usuarios activos
```bash
curl -X GET "https://localhost:5001/api/usuarios/activos" -k
```

### Crear un nuevo usuario
```bash
curl -X POST "https://localhost:5001/api/usuarios" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Ana Martínez",
    "email": "ana.martinez@email.com",
    "telefono": "+34 645 678 901",
    "activo": true
  }' -k
```

### Actualizar un usuario
```bash
curl -X PUT "https://localhost:5001/api/usuarios/1" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Juan Pérez Actualizado",
    "email": "juan.perez.nuevo@email.com",
    "telefono": "+34 612 999 888",
    "activo": true
  }' -k
```

### Eliminar un usuario
```bash
curl -X DELETE "https://localhost:5001/api/usuarios/3" -k
```

## 🧾 Facturas

### Obtener todas las facturas
```bash
curl -X GET "https://localhost:5001/api/facturas" -k
```

### Obtener factura por ID (con detalles)
```bash
curl -X GET "https://localhost:5001/api/facturas/1" -k
```

### Obtener facturas de un usuario
```bash
curl -X GET "https://localhost:5001/api/facturas/usuario/1" -k
```

### Crear una nueva factura con detalles
```bash
curl -X POST "https://localhost:5001/api/facturas" \
  -H "Content-Type: application/json" \
  -d '{
    "numeroFactura": "FAC-2024-004",
    "fechaEmision": "2024-08-15T10:30:00",
    "estado": "Pendiente",
    "usuarioId": 1,
    "detalles": [
      {
        "producto": "Mouse Inalámbrico Logitech",
        "cantidad": 2,
        "precioUnitario": 25.50
      },
      {
        "producto": "Teclado Mecánico RGB",
        "cantidad": 1,
        "precioUnitario": 89.99
      },
      {
        "producto": "Alfombrilla Gaming XXL",
        "cantidad": 1,
        "precioUnitario": 15.00
      }
    ]
  }' -k
```

### Actualizar una factura
```bash
curl -X PUT "https://localhost:5001/api/facturas/1" \
  -H "Content-Type: application/json" \
  -d '{
    "numeroFactura": "FAC-2024-001-MOD",
    "fechaEmision": "2024-06-01T00:00:00",
    "estado": "Pagada"
  }' -k
```

### Eliminar una factura
```bash
curl -X DELETE "https://localhost:5001/api/facturas/3" -k
```

## 📦 Detalles de Factura

### Obtener todos los detalles
```bash
curl -X GET "https://localhost:5001/api/detallesfactura" -k
```

### Obtener detalle por ID
```bash
curl -X GET "https://localhost:5001/api/detallesfactura/1" -k
```

### Obtener detalles de una factura específica
```bash
curl -X GET "https://localhost:5001/api/detallesfactura/factura/1" -k
```

### Agregar un detalle a una factura existente
```bash
curl -X POST "https://localhost:5001/api/detallesfactura/factura/1" \
  -H "Content-Type: application/json" \
  -d '{
    "producto": "Cable HDMI 2.1 - 2m",
    "cantidad": 3,
    "precioUnitario": 12.50
  }' -k
```

### Actualizar un detalle
```bash
curl -X PUT "https://localhost:5001/api/detallesfactura/1" \
  -H "Content-Type: application/json" \
  -d '{
    "producto": "Laptop Dell XPS 15 (Actualizado)",
    "cantidad": 1,
    "precioUnitario": 1299.99
  }' -k
```

### Eliminar un detalle
```bash
curl -X DELETE "https://localhost:5001/api/detallesfactura/9" -k
```

## 🔄 Flujo Completo de Ejemplo

### 1. Crear un nuevo usuario
```bash
curl -X POST "https://localhost:5001/api/usuarios" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Pedro Sánchez",
    "email": "pedro.sanchez@email.com",
    "telefono": "+34 656 789 012",
    "activo": true
  }' -k
```

### 2. Obtener el ID del usuario creado (aparecerá en la respuesta del paso anterior)
Supongamos que el ID es 4.

### 3. Crear una factura para ese usuario
```bash
curl -X POST "https://localhost:5001/api/facturas" \
  -H "Content-Type: application/json" \
  -d '{
    "numeroFactura": "FAC-2024-005",
    "fechaEmision": "2024-08-20T14:30:00",
    "estado": "Pendiente",
    "usuarioId": 4,
    "detalles": [
      {
        "producto": "MacBook Pro 14 M3",
        "cantidad": 1,
        "precioUnitario": 2199.00
      },
      {
        "producto": "Magic Mouse",
        "cantidad": 1,
        "precioUnitario": 89.00
      }
    ]
  }' -k
```

### 4. Consultar las facturas del usuario
```bash
curl -X GET "https://localhost:5001/api/facturas/usuario/4" -k
```

### 5. Agregar un producto adicional a la factura
Supongamos que la factura creada tiene ID 4.

```bash
curl -X POST "https://localhost:5001/api/detallesfactura/factura/4" \
  -H "Content-Type: application/json" \
  -d '{
    "producto": "USB-C Hub 7 en 1",
    "cantidad": 1,
    "precioUnitario": 45.99
  }' -k
```

### 6. Ver la factura completa con todos sus detalles
```bash
curl -X GET "https://localhost:5001/api/facturas/4" -k
```

### 7. Actualizar el estado de la factura a "Pagada"
```bash
curl -X PUT "https://localhost:5001/api/facturas/4" \
  -H "Content-Type: application/json" \
  -d '{
    "numeroFactura": "FAC-2024-005",
    "fechaEmision": "2024-08-20T14:30:00",
    "estado": "Pagada"
  }' -k
```

## 💡 Notas Importantes

1. **HTTPS y Certificados**: La opción `-k` en cURL ignora la validación de certificados SSL (útil en desarrollo). En producción, debes usar certificados válidos.

2. **Formato de Fechas**: Las fechas deben estar en formato ISO 8601: `YYYY-MM-DDTHH:mm:ss`

3. **Cálculo Automático**: 
   - El `Subtotal` de cada detalle se calcula automáticamente: `Cantidad * PrecioUnitario`
   - El `Total` de la factura se calcula automáticamente sumando todos los subtotales

4. **Relaciones en Cascada**: 
   - Al eliminar un usuario, se eliminan todas sus facturas
   - Al eliminar una factura, se eliminan todos sus detalles

5. **Validaciones**: 
   - El email debe ser único
   - Los campos requeridos no pueden estar vacíos
   - Las cantidades y precios deben ser mayores a 0

## 🧪 Pruebas con Swagger

También puedes probar la API usando Swagger UI:

1. Ejecuta la aplicación
2. Abre tu navegador en: `https://localhost:5001/swagger`
3. Explora y prueba todos los endpoints desde la interfaz gráfica

## 📊 Datos de Prueba Incluidos

El proyecto viene con datos de ejemplo (seed data):

**Usuarios:**
- ID 1: Juan Pérez (juan.perez@email.com) - Activo
- ID 2: María García (maria.garcia@email.com) - Activo
- ID 3: Carlos López (carlos.lopez@email.com) - Inactivo

**Facturas:**
- ID 1: FAC-2024-001 - Usuario 1 - $1,250.50 - Pagada
- ID 2: FAC-2024-002 - Usuario 2 - $850.75 - Pendiente
- ID 3: FAC-2024-003 - Usuario 1 - $2,100.00 - Pagada

**Detalles de Factura:**
- 9 detalles distribuidos en las 3 facturas
- Productos variados: laptops, periféricos, smartphones, etc.

## 🔍 Respuestas de Ejemplo

### GET /api/facturas/1
```json
{
  "id": 1,
  "numeroFactura": "FAC-2024-001",
  "fechaEmision": "2024-06-01T00:00:00",
  "total": 1250.50,
  "estado": "Pagada",
  "usuarioId": 1,
  "nombreUsuario": "Juan Pérez",
  "detalles": [
    {
      "id": 1,
      "producto": "Laptop Dell XPS 15",
      "cantidad": 1,
      "precioUnitario": 1200.00,
      "subtotal": 1200.00,
      "facturaId": 1
    },
    {
      "id": 2,
      "producto": "Mouse Logitech MX Master",
      "cantidad": 1,
      "precioUnitario": 50.50,
      "subtotal": 50.50,
      "facturaId": 1
    }
  ]
}
```

### POST /api/usuarios (Respuesta)
```json
{
  "id": 4,
  "nombre": "Ana Martínez",
  "email": "ana.martinez@email.com",
  "telefono": "+34 645 678 901",
  "fechaRegistro": "2024-08-20T15:30:45.123",
  "activo": true
}
```

## 🎯 Casos de Uso para Entrevistas

### Demostración de Relaciones
```bash
# 1. Obtener una factura con todos sus detalles y datos del usuario
curl -X GET "https://localhost:5001/api/facturas/1" -k

# 2. Obtener todas las facturas de un usuario específico
curl -X GET "https://localhost:5001/api/facturas/usuario/1" -k
```

### Demostración de Transacciones
```bash
# Crear una factura completa con múltiples detalles en una sola transacción
curl -X POST "https://localhost:5001/api/facturas" \
  -H "Content-Type: application/json" \
  -d '{
    "numeroFactura": "FAC-2024-006",
    "fechaEmision": "2024-08-21T00:00:00",
    "estado": "Pendiente",
    "usuarioId": 1,
    "detalles": [
      {"producto": "Producto A", "cantidad": 2, "precioUnitario": 10.00},
      {"producto": "Producto B", "cantidad": 1, "precioUnitario": 20.00},
      {"producto": "Producto C", "cantidad": 3, "precioUnitario": 5.00}
    ]
  }' -k
```

### Demostración de Actualización en Cascada
```bash
# Al agregar un detalle, el total de la factura se recalcula automáticamente
curl -X POST "https://localhost:5001/api/detallesfactura/factura/1" \
  -H "Content-Type: application/json" \
  -d '{
    "producto": "Nuevo Producto",
    "cantidad": 1,
    "precioUnitario": 100.00
  }' -k

# Verificar que el total se actualizó
curl -X GET "https://localhost:5001/api/facturas/1" -k
```
