# ATM_API

Una API REST para simular operaciones b�sicas de un cajero autom�tico:
- Ingresar dinero (m�x. 3000 EUR)
- Retirar dinero (m�x. 1000 EUR)
- Consultar saldo

## Tecnolog�as utilizadas

- ASP.NET Core 8
- Arquitectura por capas siguiendo DDD
- Principios SOLID
- xUnit para tests unitarios

## C�mo ejecutar el proyecto

1. Abrir la soluci�n `ATM_API.sln` en Visual Studio 2022+
2. Ejecutar el proyecto (F5 o bot�n Run)
3. Acceder a la documentaci�n en Swagger: https://localhost:<puerto>/swagger


## Endpoints disponibles

| M�todo | Ruta                         | Descripci�n                      |
|--------|------------------------------|----------------------------------|
| POST   | `/api/atm/ingresar`          | Ingresar dinero en la cuenta     |
| POST   | `/api/atm/retirar`           | Retirar dinero de la cuenta      |
| GET    | `/api/atm/saldo/{cuenta}`    | Consultar saldo de la cuenta     |

## C�mo ejecutar los tests

1. Abre el explorador de tests en Visual Studio:  
`Test > Test Explorer`

2. Ejecuta todos los tests con el bot�n "Run All".

Los tests cubren:
- Operaciones v�lidas de ingreso y retiro
- Errores por monto inv�lido
- Errores por saldo insuficiente
- Errores por cuenta inexistente

## Notas

- Los datos est�n en memoria para simplificar la l�gica y evaluaci�n.
- No se implement� persistencia ni creaci�n de cuentas por requerimiento.

