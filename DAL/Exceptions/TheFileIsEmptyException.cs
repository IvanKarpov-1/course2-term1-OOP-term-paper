using System;

namespace DAL.Exceptions
{
    public class TheFileIsEmptyException : Exception
    {
        public override string Message { get; }

        public TheFileIsEmptyException()
        {
            Message = "Неможливо прочитати порожній файл";
        }
    }
}