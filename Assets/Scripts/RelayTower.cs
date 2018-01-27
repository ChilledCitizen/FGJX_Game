using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayTower : MonoBehaviour {

	public GameControllerScript gameController;
	public float outputStength;
	public float healthPoints;
	void Start () {
		if(!gameController)
		{
			gameController = FindObjectOfType(typeof(GameControllerScript)) as GameControllerScript;
		}
		if(gameController)
		{
			gameController.relayTowerList.Add(this.gameObject);
			gameController.CountingOuPut();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(healthPoints <= 0)
		{
			gameController.relayTowerList.Remove(this.gameObject);
			Destroy(gameObject);
			
		}
		
	}
}
