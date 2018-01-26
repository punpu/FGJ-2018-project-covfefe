using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Vector2 location;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        location.x = location.x + (float)0.1;
        location.y = location.y + (float)0.1;
        MoveTo();
	}

    void MoveTo ()
    {
        transform.Translate(location);
    }
}
