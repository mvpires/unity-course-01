﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;



	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}

    // Update is called once per frame
    void Update()
    {

        if (!autoPlay)
        { 
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }

    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0.0f);
        Vector3 ballPosition = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPosition.x, 0.5f, 15.5f);

        transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0.0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

        transform.position = paddlePos;
    }
}
