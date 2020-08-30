using System;

namespace TheData.Exceptions
{
    public class RecordAlreadyExistsException<TRecord> : ApplicationException
    {
        private const string DefaultMessage = "The record with the same key already exists";

        public RecordAlreadyExistsException() : base(DefaultMessage)
        {
        }

        public RecordAlreadyExistsException(Exception e) : base(DefaultMessage, e)
        {
        }

        public TRecord ExistingRecord { get; set; }
    }
}