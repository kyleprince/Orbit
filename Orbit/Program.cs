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
        static String TEST_FILE = "/users/kyleprince/projects/text/test.txt";
        static String RESULT_FILE = "/users/kyleprince/projects/text/result.txt";
        static String KEY_STORE = "/users/kyleprince/projects/text/keystore.db";
        static String TEXT_FOLDER = "/users/kyleprince/projects/text/";

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

                // Encrypted message saved to file
                File.WriteAllText(TEXT_FOLDER + "enc.txt", encMessage);

                var key = orbit.fKey;
                Console.WriteLine("Encrypted with key: " + key);

                // STORE THE KEY
                var keyIndex = orbit.KeyStore(KEY_STORE);

                // CREATE NEW INSTANCE, DECRYPT THE MESSAGE USING THE KEY FROM THE KEY_STORE
                Orbit orbit2 = new Orbit();
                var decMessage = orbit2.DecryptMessage(encMessage, orbit.KeyStoreReturn(KEY_STORE, keyIndex));
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
