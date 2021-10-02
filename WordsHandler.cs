namespace Functions.Crossword
{
    /***
     * Реализовать функцию, которая подсчитывает и возвращает количество
     * символов в слове
     */
    public class WordsHandler
    {
        public static int GetLetterCount(char symbol, string word)
        {
            int counter = 0;
            
            char[] textArray = word.ToCharArray();
            
            for (int i = 0; i < word.Length; i++)
            {
                if (textArray[i] == symbol) counter++;
            }

            return counter;
        }
    }
}