# DapperExamples – Kompletny przewodnik po Dapperze w .NET 9 🚀

To repozytorium zawiera **22 praktyczne projekty konsolowe** prezentujące wykorzystanie biblioteki **Dapper** w aplikacjach .NET 9 (C#), od podstawowych zapytań po zaawansowane wzorce, serwisy i wielobazowe podejście.

---

## 📦 Technologie

- .NET 9 (C# 12)
- Dapper ORM
- SQL Server / SQLite / MySQL
- Visual Studio 2022+
- Operator `[..]` (spread syntax – C# 12)

---

## 📁 Struktura rozwiązania

```
DapperExamples/
├── Dapper.Shared/                # Modele i fabryki połączeń współdzielone przez inne projekty
│   ├── Db/
│   │   ├── DbConnectionFactory.cs
│   │   ├── ISqlConnectionFactory.cs
│   │   ├── SqlServerConnectionFactory.cs
│   │   ├── MySqlConnectionFactory.cs
│   │   └── SqliteConnectionFactory.cs
│   └── Models/
│       ├── User.cs
│       ├── Order.cs
│       └── Globals.cs
├── Dapper.Example01/             # Instalacja i pierwsze połączenie
├── Dapper.Example02/             # Testowanie połączenia
├── Dapper.Example03–07/          # SELECT, INSERT, UPDATE, DELETE
├── Dapper.Example08–13/          # Parametry, DTO, transakcje, async
├── Dapper.Example14/             # Multi-mapping: relacje 1:N
├── Dapper.Example15/             # QueryMultiple – wiele SELECT w jednym zapytaniu
├── Dapper.Example16/             # Buforowanie zapytań
├── Dapper.Example17/             # Repozytorium użytkowników
├── Dapper.Example18/             # Value Object (EmailAddress) i TypeHandler
├── Dapper.Example19/             # Dynamiczne zapytania SQL
├── Dapper.Example20/             # Fabryka połączeń dla różnych baz danych
├── Dapper.Example21/             # Serwis użytkowników z CRUD i statystykami
└── DapperExamples.sln
```

---

## 🚀 Jak uruchomić

1. **Klonuj repozytorium:**

```bash
git clone https://github.com/Tajko725/DapperExamples.git
cd DapperExamples
```

2. **Zainstaluj zależności:**

```bash
dotnet restore
```

3. **Przygotuj bazę danych:**
   - **SQL Server**: utwórz bazę `DapperTestDb`, tabele `Users`, `Orders` itp.
   - **SQLite**: plik `DapperTestDb.db` tworzy się automatycznie
   - **MySQL**: skonfiguruj dane dostępowe i stwórz bazę `DapperTestDb`

4. **Uruchom wybrany przykład:**

```bash
dotnet run --project Dapper.Example14
```

---

## 🔍 Zakres tematów

| Poziom        | Tematy                                                                 |
|---------------|------------------------------------------------------------------------|
| 🟢 Podstawowy  | Instalacja, SELECT, INSERT, UPDATE, DELETE                            |
| 🟡 Średni      | Parametry, transakcje, procedury, async                               |
| 🔵 Zaawansowany| Multi-mapping, TypeHandler, repozytorium, dynamic SQL, ValueObject    |
| 🧠 Architektura| Fabryka połączeń, wzorce, oddzielenie warstw, serwisy, DI             |

---

## ✅ Cechy projektu

- Wszystkie klasy i metody zawierają **komentarze XML**
- Projekty są **rozdzielone tematycznie** (Dapper.Example01–21)
- Kod jest gotowy do rozszerzenia o **Web API / DI / Unit testy**
- Wspólny projekt `Dapper.Shared` zawiera **modele i fabryki połączeń**
- Każdy przykład można **uruchomić niezależnie**

---

## 📦 NuGet Packages

Zainstalowane w projektach:

- `Dapper`
- `Microsoft.Data.SqlClient` (SQL Server)
- `Microsoft.Data.Sqlite` (SQLite)
- `MySql.Data` (MySQL)

---

## 📄 Licencja

MIT – możesz swobodnie używać, rozwijać i modyfikować ten kod we własnych projektach.

---

## ✍️ Autor

Projekt stworzony przez [Tajko725] jako kompletny zbiór przykładów do nauki Dappera.  
Zachęcam do ⭐ na GitHubie lub podzielenia się z innymi.
