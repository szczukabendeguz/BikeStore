# 🚴‍♀️ BikeStore Projekt 🚴‍♀️

## Leírás
A BikeStore egy egyszerű házifeladat API projekt, kerékpár áruház adatainak kezelésére szolgál. A rendszer támogatja a kerékpár márkák és modellek kezelését, felhasználók regisztrációját és autentikációját, valamint JSON Web Token (JWT) alapú hitelesítést.

## Funkciók
- **Kerékpár márkák és hírdetett modellek kezelése**: Márkák és hirdetések hozzáadása, módosítása, törlése.
- **Felhasználók kezelése**: Felhasználók regisztrációja, autentikációja.
- **JWT alapú hitelesítés**: Biztonságos hozzáférés a védett API végpontokhoz.

## Példaadatok
Az alkalmazás indulásakor az **InMemoryDb** adatbázis feltöltésre kerül:
- **Kerékpár márkák**: Például *Trek*, *Giant*, *Specialized*.
- **Kerékpár modellek**: Hegyi kerékpárok különböző utazási távolsággal és árakkal.
- **Felhasználók**: Adminisztrátor és normál felhasználók különböző jogosultságokkal.

## API Végpont példák
- **GET /api/bikes** - Kerékpármodellek listázása.
- **POST /api/auth/register** - Új felhasználó regisztrálása.
- **POST /api/auth/login** - Bejelentkezés és JWT token igénylése.
- **GET /api/brands** - Márkák listázása.

## Fejlesztési környezet
- **.NET 6**
- **Entity Framework Core**
- **InMemoryDatabase** adatbázis
- **Swagger/OpenAPI** dokumentáció

Indítás után a Swagger felületen demozható
