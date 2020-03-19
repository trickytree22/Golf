using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    [Serializable]
    public class GolferException : Exception 
    {
        public GolferException() { }

        public GolferException(string message)
            : base(message) { }


        public GolferException(string message, Exception inner)
            : base(message, inner) { }

    }
}
