﻿using System;

namespace Coding.Exercise
{
    public interface ILog
    {
        // maximum # of elements in the log
        int RecordLimit { get; }

        // number of elements already in the log
        int RecordCount { get; set; }

        // expected to increment RecordCount
        void LogInfo(string message);
    }

    public class Account
    {
        private ILog log;

        public Account(ILog log)
        {
            this.log = log;
        }

        public void SomeOperation()
        {
            int c = log.RecordCount;
            log.LogInfo("Performing an operation");
            if (c + 1 != log.RecordCount)
                throw new Exception();
            if (log.RecordCount >= log.RecordLimit)
                throw new Exception();
        }
    }

    public class NullLog : ILog
    {
        private int number = 2;

        public int RecordLimit
        {
            get { return number; }
        }

        public int RecordCount
        {
            get
            {
                ++number;
                return number % 3;
            }
            set { }
        }

        public void LogInfo(string message)
        {
            
        }
    }
}