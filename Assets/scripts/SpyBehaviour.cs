using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyBehaviour : MonoBehaviour {

    public bool isTransmitting;
    public GameObject president;
    public Vector2 activePosition;
    public Vector2 hiddenPosition;
    public float panicCount;

    public void Activate()
    {
        Ascend();
        isTransmitting = true;
    }

    public void Deactivate()
    {
        isTransmitting = false;
        Descend();
    }

    public void Transmit()
    {
        president.SendMessage("ApplyPanic", panicCount);
    }

    // spy disappears
    private void Descend()
    {
        transform.Translate(activePosition);
    }

    // A suspicious spy appears
    private void Ascend()
    {
        transform.Translate(hiddenPosition);
    }

    // Use this for initialization
    void Start () {
        isTransmitting = false;
        president = GameObject.FindGameObjectWithTag("president");
        panicCount = 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
