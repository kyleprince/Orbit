using System;
using System.IO;

/* Class: Orbit, Namespace: Galaxxy
 * Description: Isolated Encryption Class
 * 
 *  USE THIS OVER ORBIT FS FOR:
 *      * This class can be incorporated in another project entirely
 *          isolated, create instance, call encrypt or decrypt and
 *          receive variable results
 *
 *  
 * ex. Orbit <object> = new Orbit();
 *      <object>.Encrypt(message) <object>.Decrypt(message, key)
 *      key is readonly from each instance
 *  Create a new instance to get a new key
 */

namespace Galaxxy
{
    public class Orbit
    {
        public Char fKey { get; }

        public Orbit()
        {
            fKey = BuildKey();
        }

        private Char BuildKey()
        {
            int signature;
            Random r = new Random();
            signature = r.Next(65, 90);
            Char key = Convert.ToChar(signature);
            return key;
        }

        public String EncryptMessage(String message)
        {
            String resultMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                resultMessage += char.ToString((char)(message[i] ^ fKey));
            }
            return resultMessage;
        }

        public String DecryptMessage(String message, Char key)
        {
            String resultMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                resultMessage += char.ToString((char)(message[i] ^ key));
            }
            return resultMessage;
        }


        /* Key_Store Methods
         * Designate a file for a Key_Store
         * Keys will be saved in a single string,
         * so you only have to grab the index of a single string
         *
         * KeyStore() will store the key used by that instance
         * KeyStoreReturn() will return either the specified key or the last key
         */

        public void KeyStore(String location)
        {
            File.AppendAllText(location, fKey.ToString());
        }

        public Char KeyStoreReturn(String location, Int32 index)
        {
            String file = File.ReadAllText(location);
            Char key = file[index];

            return key;
        }

        public Char KeyStoreReturn(String location)
        {
            String file = File.ReadAllText(location);
            Char key = file[(file.Length - 1)];

            return key;
        }
    }
}