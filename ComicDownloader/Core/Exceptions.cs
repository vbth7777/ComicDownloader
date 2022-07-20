using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Core
{
    public class Exceptions
    {

        [Serializable]
        public class BusyException : Exception
        {
            public BusyException() { }
            public BusyException(string message) : base(message) { }
            public BusyException(string message, Exception inner) : base(message, inner) { }
            protected BusyException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        [Serializable]
        public class WrongTagElementException : Exception
        {
            public WrongTagElementException() { }
            public WrongTagElementException(string message) : base(message) { }
            public WrongTagElementException(string message, Exception inner) : base(message, inner) { }
            protected WrongTagElementException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

    }
}
