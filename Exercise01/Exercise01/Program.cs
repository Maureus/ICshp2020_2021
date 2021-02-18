using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            const string address = "Josef Novák\nJindrišská 16\n111 50, Praha 1\n";
            Console.Write(address);
        }
    }
}
