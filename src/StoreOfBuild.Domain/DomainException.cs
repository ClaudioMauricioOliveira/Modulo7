﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOfBuild.Domain
{
    public class DomainException : Exception
    {
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainException(error);
            }
        }

        public DomainException(string error) : base(error)
        {
        }
    }
}
