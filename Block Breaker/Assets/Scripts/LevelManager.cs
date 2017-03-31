using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadNextLevel()
    {
        Brick.brickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void LoadLevel(string name){

        Brick.brickCount = 0;
        Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);


    }

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void BrickDestroyed()
    {
        if(Brick.brickCount <= 0)
        {
            LoadNextLevel();
        }
    }

}
