using System;

namespace TheData.Exceptions
{
    public class WordNotFoundException : ApplicationException
    {
        public string WordBase { get; set; }
    }
}