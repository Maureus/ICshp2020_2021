using System;
using Fei.BaseLib;

namespace Delegat {
    class Delegat {
        static void Main(string[] args) {
            try {
                var delegateApp = new DelegateApp();
                delegateApp.Run();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}