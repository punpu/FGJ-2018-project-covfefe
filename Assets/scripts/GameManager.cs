using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject president;
    public PresidentBehavior presidentBehavior;

    public float dayTimer = 0f;
    public float dayLength = 120f;

    // Use this for initialization
    void Start () {
        president = GameObject.Find("president");
        presidentBehavior = president.GetComponent<PresidentBehavior>();

    }
	
	// Update is called once per frame
	void Update () {
		if(presidentBehavior.panicCounter > 100)
        {
            // set scene bad end
            Debug.Log("BAD END!!!");
        }

        dayTimer += Time.deltaTime;
        
        if(dayTimer > dayLength)
        {
            //set scene good end
            Debug.Log("GOOD END!!!");
        }
	}
}
