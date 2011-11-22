
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace prep.kata
{
    
    class bloomFilter
    {

        private int[] field = new int[2000];
        private List<string> dictionary = new List<string>();

        public bloomFilter()
        {
            //zero out the field
            for (int i = 0; i < 2000; i++)
            {
                field[i] = 0;
            }

            //create dictionary
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\words.txt");
            while ((line = file.ReadLine()) != null)
            {
                dictionary.Add(line);
            }

            file.Close();

            //hash dictionary and set bits in field

            int val = -1;
            foreach (string word in dictionary)
            {
                val = word.GetHashCode()%2000;
                field[val] = 1;
            }

        }

        public bool lookup(string word)
        {
            //hash the word and look up the bits
            if (field[word.GetHashCode() %2000] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        


    }
}
