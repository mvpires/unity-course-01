using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private AudioSource audio;

    // Use this for initialization
    void Start () {

        audio = GetComponent<AudioSource>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(!hasStarted)
        {
            transform.position = paddle.transform.position + paddleToBallVector;
        }

        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));

        if(hasStarted)
        {
            GetComponent<Rigidbody2D>().velocity += tweak;
            audio.Play();
            
        }
    }
}
