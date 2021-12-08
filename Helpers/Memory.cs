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
        public List<byte> Value { get; set; }
    }
}