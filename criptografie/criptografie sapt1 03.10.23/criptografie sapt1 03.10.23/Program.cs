namespace criptografie_sapt1_03._10._23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string text = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";
            int n = 3;

            StreamReader sr = new("../../../../TextFile.txt");
            string textFromFile = sr.ReadToEnd();
            string encryptedText = CeasarCipher(textFromFile, n);
            //Console.WriteLine();
            //CaesarDechiper(text, n);


            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            //string key = CipherMonoalphabeticSubstitution(text);
            //DechiperMonoalphabeticSubstitution(text, key);
            //Console.WriteLine(text);
            CriptAnalizing(encryptedText);
        }

        /// <summary>
        /// Cifrul lui Cezar
        /// </summary>
        private static string CeasarCipher(string inputText, int n)
        {
            if (n >= 26)
                n %= 26;

            inputText = inputText.ToUpper();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string outputText = string.Empty;

            for (int i = 0; i < inputText.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (!alphabet.Contains(inputText[i]))
                    {
                        outputText += inputText[i];
                        break;
                    }
                    if (inputText[i] == alphabet[j])
                    {
                        if (j + n < alphabet.Length)
                        {
                            outputText += alphabet[j + n];
                            break;
                        }
                        else
                        {
                            outputText += alphabet[25 - j + n - 1];
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(outputText.ToLower());
            return outputText;
        }

        private static void CaesarDechiper(string inputText, int n)
        {
            if (n >= 26)
                n %= 26;

            inputText = inputText.ToUpper();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string outputText = string.Empty;

            for (int i = 0; i < inputText.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (!alphabet.Contains(inputText[i]))
                    {
                        outputText += inputText[i];
                        break;
                    }
                    if (inputText[i] == alphabet[j])
                    {
                        if (j - n >= 0)
                        {
                            outputText += alphabet[j - n];
                            break;
                        }
                        else
                        {
                            outputText += alphabet[25 + j - n + 1];
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(outputText);
        }


        /// <summary>
        /// Substitutie Monoalphabetica
        /// </summary>
        private static string CipherMonoalphabeticSubstitution(string text)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string key = Shuffle(alphabet);
            string outputText = string.Empty;

            Console.WriteLine(alphabet);
            Console.WriteLine(key);

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        outputText += key[j];
                        break;
                    }
                    else if (!alphabet.Contains(text[i]))
                    {
                        outputText += text[i];
                        break;
                    }
                }
            }
            Console.WriteLine(outputText);
            return key;
        }

        private static void DechiperMonoalphabeticSubstitution(string text, string key)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string outputText = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (text[i] == key[j])
                    {
                        outputText += alphabet[j];
                        break;
                    }
                    else if (!key.Contains(text[i]))
                    {
                        outputText += text[i];
                        break;
                    }
                }
            }
            Console.WriteLine(outputText);
        }

        private static string Shuffle(string alphabet)
        {
            Random random = new();
            char[] c = alphabet.ToCharArray();
            for (int i = 0; i < alphabet.Length - 2; i++)
            {
                int j = random.Next(i, c.Length);
                (c[i], c[j]) = (c[j], c[i]);
            }
            string text = new(c);
            return text;
        }

        private static void CriptAnalizing(string text)
        {
            text = text.ToUpper();
            Dictionary<char, int> dictionary = new();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string englishLetterFrequency = "ETAOINSRHDLUCMFYWGPBVKXQJZ";
            for (int i = 0; i < alphabet.Length; i++)
            {
                dictionary.Add(alphabet[i], 0);
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (alphabet.Contains(text[i]))
                {
                    dictionary[text[i]]++;
                }
            }
            List<KeyValuePair<char, int>> keyValuePairs = dictionary.ToList();
            keyValuePairs.Sort((x, y) => y.Value.CompareTo(x.Value));

            string outputText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < keyValuePairs.Count; j++)
                {
                    if (!alphabet.Contains(text[i]))
                    {
                        outputText += text[i];
                        break;
                    }
                    if (text[i] == keyValuePairs[j].Key)
                    {
                        outputText += englishLetterFrequency[j];
                        break;
                    }
                }
            }

            Console.WriteLine(outputText.ToLower());
        }
    }
}