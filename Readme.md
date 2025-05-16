# ATM_API

Una API REST para simular operaciones básicas de un cajero automático:
- Ingresar dinero (máx. 3000 EUR)
- Retirar dinero (máx. 1000 EUR)
- Consultar saldo

## Tecnologías utilizadas

- ASP.NET Core 8
- Arquitectura por capas siguiendo DDD
- Principios SOLID
- xUnit para tests unitarios

## Cómo ejecutar el proyecto

1. Abrir la solución `ATM_API.sln` en Visual Studio 2022+
2. Ejecutar el proyecto (F5 o botón Run)
3. Acceder a la documentación en Swagger: https://localhost:<puerto>/swagger


## Endpoints disponibles

| Método | Ruta                         | Descripción                      |
|--------|------------------------------|----------------------------------|
| POST   | `/api/atm/ingresar`          | Ingresar dinero en la cuenta     |
| POST   | `/api/atm/retirar`           | Retirar dinero de la cuenta      |
| GET    | `/api/atm/saldo/{cuenta}`    | Consultar saldo de la cuenta     |

## Cómo ejecutar los tests

1. Abre el explorador de tests en Visual Studio:  
`Test > Test Explorer`

2. Ejecuta todos los tests con el botón "Run All".

Los tests cubren:
- Operaciones válidas de ingreso y retiro
- Errores por monto inválido
- Errores por saldo insuficiente
- Errores por cuenta inexistente

## Notas

- Los datos están en memoria para simplificar la lógica y evaluación.
- No se implementó persistencia ni creación de cuentas por requerimiento.

