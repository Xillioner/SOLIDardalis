﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyJson);
    }
}