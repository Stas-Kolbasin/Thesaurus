using System;

namespace TheData.Exceptions
{
    public class WordAlreadyExistsException : ApplicationException
    {
        private const string DefaultMessage = "The word with this base already exists";

        public WordAlreadyExistsException() : base(DefaultMessage)
        {
        }

        public WordAlreadyExistsException(Exception e) : base(DefaultMessage, e)
        {
        }

        public string WordBase { get; set; }
    }
}