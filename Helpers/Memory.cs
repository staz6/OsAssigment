using System;
using System.Collections.Generic;

namespace OsAssigment.Helpers
{
    /// <summary>
    /// Define one to many relationship
    /// </summary>
    public class Memory
    {
       public List<Data> Data { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }

        public byte Piority { get; set; }
        public byte ProcessId{get;set;}
        public byte DataSize{get;set;}
        public List<byte> DataFrame { get; set; }
        public List<byte> CodeFrame{get;set;}
    }
    
}