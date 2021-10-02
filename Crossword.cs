using System;
using System.Collections.Generic;
using Functions.Crossword;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Crossword : MonoBehaviour
{
    public InputField inputField;
    public Text txtWord;
    public Text txtResult;
    public TextAsset resourceDictionaryJson;
    private DictionaryRus _dictionary;
    private char [] _hiddenWord;
    
    private void Start()
    { 
        _dictionary = DictionaryRus.CreateFromJson(resourceDictionaryJson.text);
        
        _hiddenWord = GetRandomWord();
        print(new string(_hiddenWord));

        foreach (char letter in _hiddenWord)
        {
            txtWord.text += "*";
        }
    }

    private char [] GetRandomWord()
    {
        int rnd = Random.Range(0, _dictionary.words.Length);
        return _dictionary.words[rnd].ToCharArray();
    }

    public void GuessLetter()
    {
        if (inputField.text.Length == 0) return;
        char letter = inputField.text.ToLower()[0];

        for (int i = 0; i < _hiddenWord.Length; i++)
        {
            if (_hiddenWord[i] == letter)
            {
                char [] openWord = txtWord.text.ToCharArray();
                openWord[i] = _hiddenWord[i];
                txtWord.text = new string(openWord);
            }
        }

        txtResult.text = $"Найдено {WordsHandler.GetLetterCount(letter, new string (_hiddenWord))} букв";
    }

    [Serializable]
    public class DictionaryRus
    {
        public string [] words;
    
        public static DictionaryRus CreateFromJson (string jsonString)
        {
            return JsonUtility.FromJson<DictionaryRus>(jsonString);
        }
    }
}
