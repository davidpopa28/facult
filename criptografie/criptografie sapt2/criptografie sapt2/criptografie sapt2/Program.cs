namespace criptografie_sapt2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
             * A B C D E F G H I J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z 
             * 
                Plaintext:	attackatdawn
                Key:	    LEMONLEMONLE
                Ciphertext:	LXFOPVEFRNHR
                            LXFOPVEFRNHR
                            

             L E  M  O  N  L E  M  O  N  L E
            11 4 12 14 13 11 4 12 14 13 11 4

             */
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine("enter message");
            char[] message = Console.ReadLine().ToCharArray();
            Console.WriteLine("enter key");
            char[] key = Console.ReadLine().ToCharArray();
            string ciphertext = string.Empty;
            int[] shifts = new int[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (!alphabet.Contains(key[i]))
                        shifts[j] = -1;
                    else if (key[i] == alphabet[j])
                    {
                        shifts[i] = j;
                    }
                }
            }
            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (!alphabet.Contains(message[i]))
                    {
                        ciphertext += message[i];
                        break;
                    }
                    else if (message[i] == alphabet[j])
                    {
                        ciphertext += alphabet[(j + shifts[i]) % 26];
                        //if (j + shifts[i] < alphabet.Length)
                        //{
                        //    ciphertext += alphabet[j + shifts[i]];
                        //}
                        //else
                        //{
                        //    ciphertext += alphabet[(j + shifts[i])%26];
                        //}
                        break;
                    }
                }
            }
            Console.WriteLine("cipher text:");
            Console.WriteLine(ciphertext);
        }
    }
}