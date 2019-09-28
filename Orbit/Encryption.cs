using System;
using System.IO;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Class: Orbit, Namespace: Galaxxy
 * Description: Isolated Encryption Class
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *
 * ex. Orbit <object> = new Orbit(); Initializer builds the key
 *      <object>.Encrypt(message)
 *      <object>.Decrypt(message, <object>.KeyStoreReturn(path, index))
 *
 *  Key is only internal, then saved to the keystore. User keeps index.
 *  Create a new instance to get a new key
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *
 * Key_Store Methods
 *
 * KeyStore() : store the key used by that instance and return the index 
 * KeyStoreReturn() : return the specified key given the index
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


namespace Galaxxy
{
    public class Orbit
    {
        private readonly Char privKey;

        public Orbit()
        {
            privKey = this.BuildKey();
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
                resultMessage += Char.ToString((Char)(message[i] ^ privKey));
            }
            return resultMessage;
        }

        public String DecryptMessage(String message, Char key)
        {
            String resultMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                resultMessage += Char.ToString((Char)(message[i] ^ key)); 
            }
            return resultMessage;
        }

        public Int32 KeyStore(String path)
        {
            File.AppendAllText(path, privKey.ToString());
            String keyStore = File.ReadAllText(path);
            Int32 keyIndex = 0;
            foreach (Char c in keyStore)
            {
                keyIndex++;
            }
            keyIndex -= 1;

            return keyIndex;
        }

        public Char KeyStoreReturn(String path, Int32 pubKey)
        {
            String file = File.ReadAllText(path);
            Char key = file[pubKey];

            return key;
        }
    }
}