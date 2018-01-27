using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : MonoBehaviour {

    GameManager gameManager;

    public Vector2 startPos;
    public Vector2 midPos1;
    public Vector2 midPos2;
    public Vector2 endPos;
    

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        var fraction = gameManager.dayTimer / gameManager.dayLength;

        transform.position = CubeBezier3(startPos, midPos1, midPos2, endPos, fraction);
    }


    public static Vector3 CubeBezier3(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return (((-p0 + 3 * (p1 - p2) + p3) * t + (3 * (p0 + p2) - 6 * p1)) * t + 3 * (p1 - p0)) * t + p0;
    }

}
