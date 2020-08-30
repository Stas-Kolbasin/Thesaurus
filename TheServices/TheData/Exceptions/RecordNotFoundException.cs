using System;

namespace TheData.Exceptions
{
    public class RecordNotFoundException : ApplicationException
    {
        public string RecordKey { get; set; }
    }
}