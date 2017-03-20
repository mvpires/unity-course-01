﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;

    // Use this for initialization
    void Start () {

        StartGame();
		
	}

    void StartGame()
    {

        max = 1000;
        min = 1;
        guess = 500;

        print("========================");
        print("Welcome to Number Wizard");
        print("Pick a number in your head, BUT don't tell me!");

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number lower than " + guess + "?");
        print("Press Up Arrow for higher, Down Arrow for lower and Enter for equal");

        max += 1;
    }

    void NextGuess()
    {
        guess = (max + min) / 2;

        print("Higher or lower than " + guess + "?");
        print("Press Up Arrow for higher, Down Arrow for lower and Enter for equal");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("Up arrow pressed");

            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //print("Down arrow pressed");

            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
        }
		
	}
}
