using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public GameControllerScript gameController;
    public int healthPoints;
    public GameObject relayTower;
    public float relayMakeOffSet;

    public float walkingSpeed = 1;
    private Vector2 touchStartPos;
    private Vector2 touchCurrentPos;

	public float maxYOffSet, maxXOffSet;
	//public float maxDeltaMagnitude;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameControllerScript)) as GameControllerScript;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStartPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || touchCurrentPos != touchStartPos)
        {
            // Get movement of the finger since last frame
            // Vector2 touchDeltaPosition = touchStartPos - Input.GetTouch(0).position;
            //touchDeltaPosition.Normalize();

			touchCurrentPos = Input.GetTouch(0).position;

			Vector2 touchDeltaPosition = touchStartPos - touchCurrentPos;
			//Debug.Log("magnitude: " + touchCurrentPos.magnitude);
			//Debug.Log("deltaTouchPos: " +touchDeltaPosition);
			
			if(touchDeltaPosition.x > maxXOffSet)
			{
				touchDeltaPosition.x = maxXOffSet;
			}
			else if(touchDeltaPosition.x < -maxXOffSet)
			{
				touchDeltaPosition.x = -maxXOffSet;
			}
			if(touchDeltaPosition.y > maxYOffSet)
			{
				touchDeltaPosition.y = maxYOffSet;
			}
			else if(touchDeltaPosition.y < -maxYOffSet)
			{
				touchDeltaPosition.y = -maxYOffSet;
			}

            // Move object across XY plane
            transform.Translate(-touchDeltaPosition.x * walkingSpeed, -touchDeltaPosition.y * walkingSpeed, 0);
            //transform.position = new Vector2(transform.position.x + touchDeltaPosition.x*walkingSpeed, transform.position.y + touchDeltaPosition.y*walkingSpeed);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Resource")
        {
            gameController.ResourceAmountUpdate();
            Destroy(other.gameObject);
        }
        
    } 

    public void OnMakeRelayTower()
    {
        if(gameController.resourceAmount > gameController.requiredResourceAmount)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y+relayMakeOffSet);
            Instantiate(relayTower,pos,Quaternion.identity);
            gameController.requiredResourceAmount = (int)Mathf.Pow(gameController.requiredResourceAmount,gameController.resourceReqPow); 
        }
        
    }

}

