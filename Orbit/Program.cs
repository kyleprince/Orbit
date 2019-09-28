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
        static readonly String SRC_FILE = "/users/kyleprince/projects/datafiles/test.txt";
        static readonly String ENC_FILE = "/users/kyleprince/projects/datafiles/enc_message.gxm";
        static readonly String DEC_FILE = "/users/kyleprince/projects/datafiles/dec_message.txt";
        static readonly String KEY_STORE = "/users/kyleprince/projects/datafiles/keystore.db";
        static readonly String TEXT_FOLDER = "/users/kyleprince/projects/datafiles/";

        static void Main(string[] args)
        {
            Boolean exitcode = false;
            do
            {
                Console.Clear();
                Orbit orbit = new Orbit();

                // READ SRC MESSAGE
                var message = File.ReadAllText(SRC_FILE);
                Console.WriteLine("Message: " + message);

                // ENCRYPT MESSAGE
                var encMessage = orbit.EncryptMessage(message);

                // Encrypted message saved to file
                File.WriteAllText(ENC_FILE, encMessage);

                // STORE THE KEY
                var keyIndex = orbit.KeyStore(KEY_STORE);
                Console.WriteLine("Key number: " + keyIndex);

                // CREATE NEW INSTANCE, DECRYPT THE MESSAGE USING THE KEY FROM THE KEY_STORE
                Orbit orbit2 = new Orbit();
                var decMessage = orbit2.DecryptMessage(encMessage, orbit.KeyStoreReturn(KEY_STORE, keyIndex));
                File.WriteAllText(DEC_FILE, decMessage);


                // ENTER COMMAND
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
