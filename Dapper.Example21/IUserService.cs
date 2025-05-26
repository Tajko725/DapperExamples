using Dapper.Shared.Models;

namespace Dapper.Example21
{
    /// <summary>
    /// Interfejs serwisu użytkowników definiujący operacje CRUD oraz metody pomocnicze.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Dodaje nowego użytkownika do bazy danych.
        /// </summary>
        /// <param name="name">Imię i nazwisko użytkownika.</param>
        /// <param name="email">Adres e-mail użytkownika.</param>
        /// <returns>ID nowo dodanego użytkownika.</returns>
        int Add(string name, string email);

        /// <summary>
        /// Zwraca liczbę wszystkich użytkowników w bazie.
        /// </summary>
        /// <returns>Liczba użytkowników.</returns>
        int Count();

        /// <summary>
        /// Usuwa użytkownika na podstawie jego identyfikatora.
        /// </summary>
        /// <param name="id">Identyfikator użytkownika.</param>
        void Delete(int id);

        /// <summary>
        /// Zwraca listę wszystkich użytkowników.
        /// </summary>
        /// <returns>Lista obiektów typu <see cref="User"/>.</returns>
        List<User> GetAll();

        /// <summary>
        /// Pobiera użytkownika na podstawie identyfikatora.
        /// </summary>
        /// <param name="id">Identyfikator użytkownika.</param>
        /// <returns>Obiekt <see cref="User"/> lub null, jeśli nie znaleziono.</returns>
        User? GetById(int id);

        /// <summary>
        /// Zwraca statystyki: liczbę użytkowników i ostatniego użytkownika.
        /// </summary>
        /// <returns>Krotka: liczba użytkowników i ostatni użytkownik.</returns>
        (int Count, User? LastUser) GetUserStats();

        /// <summary>
        /// Aktualizuje wszystkie dane użytkownika.
        /// </summary>
        /// <param name="user">Obiekt użytkownika z uzupełnionym ID.</param>
        void Update(User user);

        /// <summary>
        /// Aktualizuje wyłącznie adres e-mail danego użytkownika.
        /// </summary>
        /// <param name="id">Identyfikator użytkownika.</param>
        /// <param name="newEmail">Nowy adres e-mail.</param>
        /// <returns>Liczba zmodyfikowanych rekordów (0 lub 1).</returns>
        int UpdateUserEmail(int id, string newEmail);
    }

}