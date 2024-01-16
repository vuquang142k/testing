using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Error
{
    [Serializable]
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string information = "\nКнига не найдена!\n") : base(information) { }
        public BookNotFoundException(Exception inner, string information = "\nКнига не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class BookExistsException : Exception
    {
        public BookExistsException(string information = "\nКнига уже существует!\n") : base(information) { }
        public BookExistsException(Exception inner, string information = "\nКнига уже существует!\n") : base(information, inner) { }
    }
    [Serializable]
    public class DeleteBookErrorException : Exception
    {
        public DeleteBookErrorException(string information = "\nНе удалось осуществить действие!\n") : base(information) { }
        public DeleteBookErrorException(Exception inner, string information = "\nНе удалось осуществить действие!\n") : base(information, inner) { }
    }
    [Serializable]
    public class BookstoreNotFoundException : Exception
    {
        public BookstoreNotFoundException(string information = "\nBookstore не найден!\n") : base(information) { }
        public BookstoreNotFoundException(Exception inner, string information = "\nBookstore не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddBookstoreErrorException : Exception
    {
        public AddBookstoreErrorException(string information = "\nBookstore не удалось добавить!\n") : base(information) { }
        public AddBookstoreErrorException(Exception inner, string information = "\nBookstore не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class BusyBookNotFoundException : Exception
    {
        public BusyBookNotFoundException(string information = "\nЗанятая книга не найдена!\n") : base(information) { }
        public BusyBookNotFoundException(Exception inner, string information = "\nЗанятая книга не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddBusyBookErrorException : Exception
    {
        public AddBusyBookErrorException(string information = "\nЗанятая книга не удалось добавить!\n") : base(information) { }
        public AddBusyBookErrorException(Exception inner, string information = "\nЗанятая книга не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class PlaceBookNotFoundException : Exception
    {
        public PlaceBookNotFoundException(string information = "\nPlaceBook не найдена!\n") : base(information) { }
        public PlaceBookNotFoundException(Exception inner, string information = "\nPlaceBook не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class PlaceBookExistsException : Exception
    {
        public PlaceBookExistsException(string information = "\nКнига уже существует!\n") : base(information) { }
        public PlaceBookExistsException(Exception inner, string information = "\nКнига уже существует!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string information = "\nПользователь не найден!\n") : base(information) { }
        public AccountNotFoundException(Exception inner, string information = "\nПользователь не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddAccountErrorException : Exception
    {
        public AddAccountErrorException(string information = "Пользователя не удалось добавить!\n") : base(information) { }
        public AddAccountErrorException(Exception inner, string information = "Пользователя не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class DeleteAccountErrorException : Exception
    {
        public DeleteAccountErrorException(string information = "\nНе удалось осуществить действие!\n") : base(information) { }
        public DeleteAccountErrorException(Exception inner, string information = "\nНе удалось осуществить действие!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AccountExistsException : Exception
    {
        public AccountExistsException(string information = "Пользователя уже существует\n") : base(information) { }
        public AccountExistsException(Exception inner, string information = "Пользователя уже существует\n") : base(information, inner) { }
    }
    [Serializable]
    public class LoginNotFoundException : Exception
    {
        public LoginNotFoundException(string information = "Пользователя не существует\n") : base(information) { }
        public LoginNotFoundException(Exception inner, string information = "Пользователя не существует\n") : base(information, inner)
        {
            Console.WriteLine(information);
        }
    }
    [Serializable]
    public class IncorrectPasswordExcept : Exception
    {
        public IncorrectPasswordExcept(string information = "Incorrect password\n") : base(information) { }
        public IncorrectPasswordExcept(Exception inner, string information = "Incorrect password\n") : base(information, inner) { }
    }
    [Serializable]
    public class DataBaseConnectException : Exception
    {
        public DataBaseConnectException(string information = "Не получилось подключиться к Базе данных!\n") : base(information) { }
        public DataBaseConnectException(Exception inner, string information = "Не получилось подключиться к Базе данных!\n") : base(information, inner) { }
    }
    [Serializable]
    public class DataBaseRunErrorException : Exception
    {
        public DataBaseRunErrorException(string information = "Ошибка в БД\n") : base(information) { }
        public DataBaseRunErrorException(Exception inner, string information = "Ошибка в БД\n") : base(information, inner) { }
    }
}
