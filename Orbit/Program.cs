using System;
using System.IO;

/* Program: Orbit, simple message encoding
 * Program.cs : Unit tests for Encryption
 *
 */
namespace Galaxxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean exitcode = false;
            do
            {
                Orbit orbit = new Orbit();
                var message = File.ReadAllText("/users/kyleprince/test.txt");
                Console.WriteLine("Message: " + message);

                var encMessage = orbit.EncryptMessage(message);
                Console.WriteLine("Encrypted message: " + encMessage);

                var key = orbit.fKey;
                Console.WriteLine("Encrypted with key: " + key);

                Orbit orbit2 = new Orbit();
                var decMessage = orbit2.DecryptMessage(encMessage, key);
                Console.WriteLine("Decrypted message: " + decMessage);


                Console.Write(">_ ");
                var command = Console.ReadLine();
                if (command == "exit")
                {
                    exitcode = true;
                }

            } while (exitcode == false);
            
        }
    }
}
