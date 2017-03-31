using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip audioClip;
    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public static int brickCount = 0;
    private bool isBreakable;
    public GameObject smoke;

    // Use this for initialization
    void Start () {

        isBreakable = (this.tag == "Breakable");

        if(isBreakable)
        {
            brickCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();


    }
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        AudioSource.PlayClipAtPoint(audioClip, this.transform.position, 1.0f);
        if(isBreakable)
        {
            HandleHits();
        }

    }

    void HandleHits()
    {
        timesHit++;

        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            brickCount--;
            PuffSmoke();
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);

        ParticleSystem.MainModule particle = smokePuff.GetComponent<ParticleSystem>().main;

        particle.startColor = new ParticleSystem.MinMaxGradient(gameObject.GetComponent<SpriteRenderer>().color);
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }


}
