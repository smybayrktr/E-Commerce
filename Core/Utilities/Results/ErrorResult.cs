using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false)
        {
            //Mesaj göndererek işlem sonucunu false döndürür.
        }
        public ErrorResult() : base(false)
        {
            //Mesaj göndermeden işlem sonucunu false döndürür
        }
    }
}
