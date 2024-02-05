﻿using System;

namespace Coding.Exercise
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        public int Age
        {
            // todo :)
        }

        public string Fly()
        {
            // todo
        }

        public string Crawl()
        {
            // todo
        }
    }
}
