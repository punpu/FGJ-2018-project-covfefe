﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyBehaviour : MonoBehaviour {

    private float nextActionTime = 0.0f;
    public float currentPeriod = 0f;
    public float periodMax = 1f;
    public float moveSpeed = 2f;

    public bool isActive;
    public GameObject president;
    public Vector2 activePosition;
    public Vector2 hiddenPosition;
    public float panicCount;

    public void Activate()
    {
        gameObject.GetComponent<TransmitterBehavior>().isTransmitting = true;
        isActive = true;
    }

    public void Deactivate()
    {
        gameObject.GetComponent<TransmitterBehavior>().isTransmitting = false;
        isActive = false;
    }

    public void Transmit()
    {
        president.SendMessage("ApplyPanic", panicCount);
    }

    // Use this for initialization
    void Start () {
        isActive = false;
        president = GameObject.FindGameObjectWithTag("president");
        panicCount = 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, activePosition, step);

            currentPeriod -= Time.deltaTime;

            if (currentPeriod < 0f)
            {
                Transmit();
                currentPeriod = periodMax;
            }
        }

        else
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, hiddenPosition, step);
        }
    }
}
