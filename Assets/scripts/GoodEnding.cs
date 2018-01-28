using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnding : MonoBehaviour {
    public int secondsToMenuOpen = 4;
    public GameObject goodEndMenu;

	// Use this for initialization
	void Start () {
        StartCoroutine(OpenMenuTimeout());
	}
	
    IEnumerator OpenMenuTimeout()
    {
        yield return new WaitForSeconds(secondsToMenuOpen);
        goodEndMenu.SetActive(true);
    }
}
