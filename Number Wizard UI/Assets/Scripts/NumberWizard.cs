using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;
    int maxGuessesAllowed;
    public Text text;

    // Use this for initialization
    void Start () {

        StartGame();
		
	}

    void StartGame()
    {

        max = 1000;
        min = 1;
        NextGuess();
        maxGuessesAllowed = 5;
    }

    void NextGuess()
    {
        guess = Random.Range(min, max+1);
        maxGuessesAllowed -= 1;
        text.text = guess.ToString();

        if (maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }

    }
	
    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
        
    }
}


