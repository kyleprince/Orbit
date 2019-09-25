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
        // Constants for file locations
        static String TEST_FILE = "/users/kyleprince/test.txt";
        static String RESULT_FILE = "/users/kyleprince/result.txt";
        static String KEY_STORE = "/users/kyleprince/keystore.txt";

        static void Main(string[] args)
        {
            Boolean exitcode = false;
            do
            {
                Console.Clear();
                Orbit orbit = new Orbit();

                // READ MESSAGE
                var message = File.ReadAllText(TEST_FILE);
                Console.WriteLine("Message: " + message);

                // ENCRYPT MESSAGE
                var encMessage = orbit.EncryptMessage(message);
                Console.WriteLine("Encrypted message: " + encMessage);

                var key = orbit.fKey;
                Console.WriteLine("Encrypted with key: " + key);

                // STORE THE KEY
                orbit.KeyStore(KEY_STORE);

                // CREATE NEW INSTANCE, DECRYPT THE MESSAGE USING THE KEY FROM THE KEY_STORE
                Orbit orbit2 = new Orbit();
                var decMessage = orbit2.DecryptMessage(encMessage, orbit.KeyStoreReturn(KEY_STORE));
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
