using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Application.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}

// CQRS is a pattern that separates the read and write operations of an application
// it is used to improve the performance ,scalability and security of an application
// it is used to create a clear  separation of concerns between the read and write operations

// MediatR is a library that implements the CQRS pattern
// it is used to send commands and queries to the appropriate handlers
// Without MediatR we would have to create a separate class for each command and query
// this would make the code more complex and harder to maintain
// MediatR allows us to  create a single class for each command and query

// we use would in english to indicate that somthing is possible but not certain
// we use would in programming to indicate that somthing is possible but not certain
// the difference  between would and will is that would is used to indicate a future
// action that is not certain but would is used to indicate a future action that is certain

// the difference between would and could is that would is used to indicate a future but could is used to indicate a past action
// we use could to indicate that somthing is possible but not certain in the past for example we could have gone to the party
