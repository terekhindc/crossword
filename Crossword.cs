using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private char[] _hiddenWord;
    
    // Start is called before the first frame update
    void Start()
    {
        _dictionary = DictionaryRus.CreateFromJson(resourceDictionaryJson.text);
        _hiddenWord = GetRandom();

        foreach (var letter in _hiddenWord)
        {
            txtWord.text += "*";
        }
    }

    public void GetLetter()
    {
        if (inputField.text.Length == 0) return;
        char letter = inputField.text.ToLower()[0];

        int counter = 0;
        
        for (int i = 0; i < _hiddenWord.Length; i++)
        {
            if (_hiddenWord[i] == letter)
            {
                counter++;
                char[] openword = txtWord.text.ToCharArray();
                openword[i] = letter;
                txtWord.text = new string(openword);
            }
        }

        txtResult.text = $"Найдено {counter} букв";
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private char[] GetRandom()
    {
        int rnd = Random.Range(0, _dictionary.words.Length);
        return _dictionary.words[rnd].ToCharArray();
    }
}

[Serializable]
public class DictionaryRus
{
    public string[] words;

    public static DictionaryRus CreateFromJson(string json)
    {
        return JsonUtility.FromJson<DictionaryRus>(json);
    }
}