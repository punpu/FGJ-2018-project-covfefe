using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentBehavior : MonoBehaviour {
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public float minTime = 0.5f;
	public float maxTime = 1.5f;
	public float moveSpeed = 1;

	private float tChange = 0;
    private float randomX;
    private float randomY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Random direction at random intervals
        if (Time.time >= tChange) {
			randomX = Random.Range (minX, maxY);
			randomY = Random.Range (minY, maxY);
            tChange = Time.time + Random.Range (minTime, maxTime);
        }
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(randomX, randomY, 0), step);
    }
}
