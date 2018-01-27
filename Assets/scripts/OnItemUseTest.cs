using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemUseTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnItemUse(GameObject item)
    {
        Debug.Log("Item used on me!");
        if(item.name == "TinfoilHat")
        {
            Debug.Log("Tinfoiled!");
            item.SendMessage("SetOnCooldown");
        }
        else
        {
            Debug.Log("That is not the tinfoilhat!");
        }
    }
}
