using System.Collections.Generic;
using System.Linq;

namespace OsAssigment.Helpers
{
    public class VMemory
    {
        public List<Page> Pages { get; set; }
    }
    public class Page
    {
        public string Name {get;set;}
        public byte Piority { get; set; }
        public byte ProcessId{get;set;}
        public byte DataSize{get;set;}
        public byte[] PCB {get;set;} = Enumerable.Repeat<byte>(0, 16).ToArray();
        public List<PageTable> PageTables{get;set;}
    }
    public class PageTable
    {
        public List<byte> Value { get; set; }
    }
}