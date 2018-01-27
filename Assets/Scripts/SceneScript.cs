using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneScript : MonoBehaviour {


	public int menu;
	public int mainLevel;
	public int winScreen;

	public Scene currentScene;
	

	// Use this for initialization
	void Start () {
		
			currentScene = SceneManager.GetActiveScene();
			
	}
	
	// Update is called once per frame
	public void LoadScene(int sceneID)
	{
		SceneManager.LoadScene(sceneID);
	}

	
}
