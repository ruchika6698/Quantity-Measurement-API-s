using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.CustomException
{
    public class CustomException: Exception
    {
        public enum ExceptionType
        {
            INPUT_NULL, TYPE_NOT_MATCH
        }
        public ExceptionType type;

        //Constructor
        public CustomException(ExceptionType type)
        {
            this.type = type;
        }

        public CustomException(ExceptionType type, String message) : base(message)
        {
            this.type = type;
        }
    }
}
