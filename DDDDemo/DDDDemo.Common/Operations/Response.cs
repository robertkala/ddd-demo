﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Common.Operations
{
    public class Response
    {
        public bool Succeeded { get; set; }
        public string FailureReason { get; set; }

        public static Response CreateSuccessfulResponse()
        {
            return new Response { Succeeded = true };
        }

        public static Response CreateFailureResponse(string failureReason)
        {
            return new Response { Succeeded = false, FailureReason = failureReason };
        }

        public override string ToString()
        {
            return Succeeded ? "Operation succeeded" : "Operation failed, reason: " + FailureReason;
        }
    }
}
