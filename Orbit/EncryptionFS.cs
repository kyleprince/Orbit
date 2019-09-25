using System;
using System.IO;

/* Class: OrbitFS, Program/Namespace: Galaxxy
 * Description: Isolated Encryption Class
 *              Without StringBlaster or other dependencies
 *              Pass parameters and encrypt or decrypt a message
 *              
 *  USE THIS OVER REGULAR ORBIT:
 *      * If you need to encrypt a text message from a text file
 *      * OR you need your results in a text file
 *      * This supports manual entry of a plain text message,
 *          but the encrypted message will always end up in a text file
 *
 * 
 *  
 * ex. Encryption <object> = new Encryption(parameter, messageLocation, optionalKey);
 *      <object>.Orbit() will return the private key used to encrypt
 */

namespace Galaxxy
{
    public class OrbitFS
    {
        private Char fKey;
        private String param, input;

        public OrbitFS(String parameter, String messageLocation, String decryptKey)
        {
            if (parameter == "-d")
            {
                fKey = Convert.ToChar(decryptKey);
            }
            else
            {
                fKey = BuildKeys();
            }
            param = parameter; input = messageLocation;
        }

        // METHODS - Entry point: Orbit
        /* Param options:
         *  -e : Encrypt a file
         *  -d : Decrypt a file
         *  -em : Encrypt a string message -> results file
         */
        public Char EncryptDecrypt()
        {
            if (param == "-e")
            {
                var message = File.ReadAllBytes(input);
                EncryptFile(message);
            }
            else if (param == "-d")
            {
                var message = File.ReadAllLines(input);
                DecryptFile(message, fKey);
            }
            else if (param == "-em")
            {
                Byte[] message = new Byte[input.Length];

                int i = 0;
                foreach (Char c in input)
                {
                    message[i] = Convert.ToByte(c);
                    i++;
                }

                EncryptFile(message);
            }
            return fKey;
        }

        private Char BuildKeys()
        {
            int signature;
            Random r = new Random();
            signature = r.Next(65, 90);
            Char privKey = Convert.ToChar(signature);
            return privKey;
        }

        private void EncryptFile(Byte[] message)
        {
            int[] encMessage = new int[message.Length];
            int i = 0;
            foreach (Byte b in message)
            {
                encMessage[i] = b ^ fKey;
                File.AppendAllText("/Users/kyleprince/result.txt", (encMessage[i]) + "\n");
                i++;
            }
            Console.WriteLine("Encrypted with private key: " + fKey);
        }

        private void DecryptFile(String[] message, Char key)
        {
            Byte[] byteMessage = new Byte[message.Length];
            Char[] outputString = new char[message.Length];

            int i = 0;
            foreach (String s in message)
            {
                byteMessage[i] = (Byte)(Convert.ToInt32(s) ^ fKey);
                i++;
            }
            i = 0;
            foreach (Byte b in byteMessage)
            {
                outputString[i] = Convert.ToChar(b);
                i++;
            }
            foreach (Char c in outputString)
            {
                Console.Write(c);
            }
        }
    }
}
