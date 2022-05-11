using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true)
        {
            //Mesaj göndererek işlem sonucunu true döndürür.
        }
        public SuccessResult():base(true)
        {
            //Mesaj göndermeden işlem sonucunu true döndürür
        }
    }
}
