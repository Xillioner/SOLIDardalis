﻿using ArdalisRating.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class ConsoleLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}