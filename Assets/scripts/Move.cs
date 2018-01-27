using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Vector2 location;

    public float panicCounter;

    public void ApplyPanic(float appliedPanic)
    {
        panicCounter = panicCounter + appliedPanic;
    }

	// Use this for initialization
	void Start () {
        panicCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //location.x = location.x + (float)0.001;
        //location.y = location.y + (float)0.001;
        //MoveTo();
	}

    void MoveTo ()
    {
        transform.Translate(location);
    }
}
