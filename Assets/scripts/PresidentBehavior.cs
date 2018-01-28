using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PresidentBehavior : MonoBehaviour {
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public float minTime = 0.5f;
	public float maxTime = 1.5f;
	public float moveSpeed = 1;
    public string transmitterTag = "Transmitter";
    public bool tinfoilHatActive = false;

    public float randomX;
    public float randomY;
    private GameObject[] transmitters;
    private Animator animator;
    private Vector3 randomTarget;

    private Transform tinfoilHat;

    public float panicCounter;
    
    // Use this for initialization
    void Start () {
        transmitters = GameObject.FindGameObjectsWithTag(transmitterTag);
        animator = GetComponent<Animator>();
        Debug.Log(transmitters);
        tinfoilHat = transform.Find("tinfoilHat");
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);
        randomTarget = new Vector3(randomX, randomY, 0);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject activeTransmitter = GetClosestActiveTransmitter();
        if (activeTransmitter != null) {
            float step = moveSpeed * Time.deltaTime;
            bool isMovingLeft = transform.position.x <= activeTransmitter.transform.position.x;
            animator.SetBool("isMovingLeft", isMovingLeft);
            transform.position = Vector2.MoveTowards(transform.position, activeTransmitter.transform.position, step);
        }
        else {
            if (transform.position == randomTarget) {
                randomX = Random.Range(minX, maxX);
                randomY = Random.Range(minY, maxY);
                randomTarget = new Vector3(randomX, randomY, 0);
            }
            float step = moveSpeed * Time.deltaTime;
            bool isMovingLeft = transform.position.x <= randomX;
            animator.SetBool("isMovingLeft", isMovingLeft);
            transform.position = Vector2.MoveTowards(transform.position, randomTarget, step);
        }
    }

    GameObject GetClosestActiveTransmitter () {
        List<GameObject> activeTransmitters = new List<GameObject>();
        if (!transmitters.Any()) {
            return null;
        }
        foreach (var obj in transmitters) {
            if (obj.GetComponent<TransmitterBehavior>().isTransmitting) {
                activeTransmitters.Add(obj);
            }
        }
        activeTransmitters = activeTransmitters.OrderBy(
            x => Vector2.Distance(transform.position, x.transform.position)
           ).ToList();
        return activeTransmitters.Any() ? activeTransmitters[0] : null;
    }

    // Called when an item is dragged on the president
    public void OnItemUse(GameObject item)
    {
        if (item.name == "TinfoilHat")
        {
            item.SendMessage("SetOnCooldown");
            tinfoilHat.gameObject.SetActive(true);
            tinfoilHatActive = true;
            StartCoroutine(RemoveTinfoilHatAfter5Seconds());
        }
        else
        {
            Debug.Log("President wants the tinfoilhat!");
        }
    }

    public void ApplyPanic(float appliedPanic)
    {
        if (!tinfoilHatActive)
        {
            panicCounter = panicCounter + appliedPanic;
            animator.speed = 0.5f + Mathf.Floor(panicCounter / 20);
            GetComponentInChildren<AudioSource>().Play();
        }
    }

    IEnumerator RemoveTinfoilHatAfter5Seconds()
    {
        yield return new WaitForSeconds(5);
        tinfoilHat.gameObject.SetActive(false);
        tinfoilHatActive = false;
    }

}
