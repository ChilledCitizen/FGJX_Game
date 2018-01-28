using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if(transform.position.x < 40)
		{
			Destroy(gameObject);
		}
		else if(transform.position.x > 1500)
		{
			Destroy(gameObject);
		}
		if(transform.position.y < 20)
		{
			Destroy(gameObject);
		}
		else if(transform.position.y > 1530)
		{
			Destroy(gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
