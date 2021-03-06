using System;
using Fei.BaseLib;

namespace Delegat {
    class Delegat {
        static void Main(string[] args) {
            try {
                new DelegateApp().Run();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}