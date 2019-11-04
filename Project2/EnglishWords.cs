using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
namespace Project2
{
        public class EnglishWords
        {
            List<string> englishWordsList = new List<string>();
   
           
            StreamReader input;

            // This constructor will initiate the loading of all words located
            // in the given dictionary. The constructor must return very quickly,
            // perhaps before the words have been completely loaded. Tasks will be
            // needed to do this.
            public EnglishWords()
            {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Project2.words.txt");
            using (var dictReader = new System.IO.StreamReader(stream))
            {
                while (!dictReader.EndOfStream) { 
                string line = dictReader.ReadLine();
                englishWordsList.Add(line);
            }
            }
        
        }

       
            //Loads the data from text file into a list
            //Returns a task of type List
            //Asynchronous method
            public async Task<List<string>> LoadDictionaryAsync()
            {
                using (input)
                {
                    while (!input.EndOfStream)
                    {
                        string line = await input.ReadLineAsync();
                    englishWordsList.Add(line);
                    }
                }
                input.Close();
                return englishWordsList;
            }

        // This method will return true only if the word appears in the
        // dictionary. This method will need to wait, if it is called
        // before the words have been completely loaded.
        public bool isLegal(string word)
        {
            return englishWordsList.Contains(word);
        }

        //Sets the wordList to contain the list from .txt file
        public List<String> getWordList()
        {
            return englishWordsList;
        }


        // This method will return an alphabetically sorted list of all words that
        // can be formed using a collection of letters and having the given length.
        // Each letter can only be used once. For example, consider length 5 words
        // the collection of letters: HERATH
        // Here are some of the words that can be formed: EARTH, HEART, ..
        // Some English words not part of the list: REATA, ARHAT
        // Like the previous method, this method may need to wait too.
        public List<string> AvailableWords(string letters, int len)
        {
            letters = letters.ToUpper();
            //  char[] wordCharArray;
            List<char> letterList = new List<char>();
            List<string> availableWordList = new List<string>();

            for (int i = 0; i < englishWordsList.Count; i++)
            {
                string word = englishWordsList[i];
                //   wordCharArray = word.ToCharArray();
                letterList.AddRange(letters);
                if (word.Length == len)
                {
                    int counter = 0;
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (letterList.Contains(word[j]))
                        {
                            letterList.Remove(word[j]);
                            counter++;
                        }
                    }
                    if (counter == len)
                    {
                        availableWordList.Add(word);

                    }

                }//end if
                letterList.Clear();
            }//end for loop
            return availableWordList;
        }
        //Takes in a string of letters and a length
        //Will return a list of all available words with specifid length that
        //contain letters from the parameter
        //Will accept duplicates
        public List<string> AvailableWordsDuplicate(string letters, int len)
        {
            letters = letters.ToUpper();
            //  char[] wordCharArray;
            List<char> letterList = new List<char>();
            List<string> availableWordList = new List<string>();

            //For each word
            for (int i = 0; i < englishWordsList.Count; i++)
            {
                string word = englishWordsList[i];
             
                letterList.AddRange(letters);

                if (word.Length == len)
                {
                    int counter = 0;
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (letterList.Contains(word[j]))
                        {
                           // letterList.Remove(word[j]);
                            counter++;
                        }
                    }
                    if (counter == len)
                    {
                        availableWordList.Add(word);

                    }

                }//end if
                letterList.Clear();
            }//end for loop
            return availableWordList;
        }

    }//End class
   
   

}//End namespace
