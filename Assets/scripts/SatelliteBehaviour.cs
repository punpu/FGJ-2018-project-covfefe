using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteBehaviour : MonoBehaviour {

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    public GameObject president;

    public Vector2 activePosition;
    public Vector2 hiddenPosition;

    public float panicCount;
    public bool isActive;

    // Interacts with the president
    private void Transmit()
    {
        president.SendMessage("ApplyPanic", panicCount);
    }

    // A suspicious satellite appears
    private void Descend()
    {
        transform.Translate(activePosition);
    }

    // Satellite disappears
    private void Ascend()
    {
        transform.Translate(hiddenPosition);
    }

    // Call when president gon get rekt
    void Activate()
    {
        Descend();
        isActive = true;
    }

    void Deactivate()
    {
        isActive = false;
        Ascend();
    }

    // Use this for initialization
    void Start () {
        president = GameObject.FindGameObjectWithTag("president");
        panicCount = 69;
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (isActive)
            {
                Transmit();
            }
        }
    }
}
