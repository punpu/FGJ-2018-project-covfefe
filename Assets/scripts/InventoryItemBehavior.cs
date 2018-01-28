
using UnityEngine;

public class InventoryItemBehavior : MonoBehaviour, IItemInterface {


    public float cooldownMax = 5f;
    public float cooldownRemaining = 0f;
    public bool OnCooldown = false;

    public SpriteRenderer spriteRenderer;

    bool IItemInterface.OnCooldown
    {
        get
        {
            return OnCooldown;
        }
    }

    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(OnCooldown && cooldownRemaining > 0f)
        {
            cooldownRemaining -= Time.deltaTime;
        }
        else
        {
            OnCooldown = false;
            spriteRenderer.enabled = true;
        }
	}

    public void SetOnCooldown()
    {
        Debug.Log("I'm on cooldown!");
        cooldownRemaining = cooldownMax;
        OnCooldown = true;
        spriteRenderer.enabled = false;
        if(GetComponentInChildren<AudioSource>()!= null)    
            GetComponentInChildren<AudioSource>().Play();
    }
}
