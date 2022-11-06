using System;

namespace BLL.Exceptions
{
    public class NoMatchesFoundException : Exception
    {
        public NoMatchesFoundException(string message) : base(message)
        {
        }
    }
}