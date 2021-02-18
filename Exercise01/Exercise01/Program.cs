using System;
using System.Text;

namespace Address
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string address = "Josef Novák\nJindrišská 16\n111 50, Praha 1\n";
            Console.Write(address);
        }
    }
}