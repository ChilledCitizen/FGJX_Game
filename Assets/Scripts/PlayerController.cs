﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public int healthPoints;

    public float walkingSpeed = 1;
    private Vector2 touchStartPos;
    private Vector2 touchCurrentPos;

    // Use this for initialization
    void Start()
    {

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


            // Move object across XY plane
            transform.Translate(-touchDeltaPosition.x * walkingSpeed, -touchDeltaPosition.y * walkingSpeed, 0);
            //transform.position = new Vector2(transform.position.x + touchDeltaPosition.x*walkingSpeed, transform.position.y + touchDeltaPosition.y*walkingSpeed);
        }

    }



}

