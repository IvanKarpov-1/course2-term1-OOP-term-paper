using System;

namespace BLL.Exceptions
{
    public class EntitiesEmptyException : Exception
    {
        public EntitiesEmptyException(string message) : base(message)
        {
        }
    }
}