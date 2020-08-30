using System;

namespace TheData.Exceptions
{
    public class RecordAlreadyExistsException<TRecord> : ApplicationException
    {   
        public TRecord ExistingRecord { get; set; }
    }
}