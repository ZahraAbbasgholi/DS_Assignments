﻿using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public Dictionary<int, string> PhoneBook;
        public string[] Solve(string [] commands)
        {
            PhoneBook = new Dictionary<int, string>();
            List<string> result = new List<string>();
            foreach(var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number));
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number)
        {
            if (PhoneBook.ContainsKey(number))
            {
                PhoneBook.Remove(number);
            }
            PhoneBook.Add(key: number, value: name);
        }
        public void Delete(int number)
        {
            if (PhoneBook.ContainsKey(number))
            {
                PhoneBook.Remove(number);
            }
        }
        public string Find(int number)
        {
            if (PhoneBook.ContainsKey(number))
                return PhoneBook[number];
                // return PhoneBook.FirstOrDefault(x => x.Key == number).Value;
            else
                return "not found";
        }   
    }
}
