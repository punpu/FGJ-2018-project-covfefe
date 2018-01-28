
using UnityEngine;

public class InventoryItemBehavior : MonoBehaviour, IItemInterface {


    public float cooldownMax = 5f;
    public float cooldownRemaining = 0f;
    public bool OnCooldown = false;

    bool IItemInterface.OnCooldown
    {
        get
        {
            return OnCooldown;
        }
    }

    // Use this for initialization
    void Start () {
		
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
        }
	}

    public void SetOnCooldown()
    {
        Debug.Log("I'm on cooldown!");
        cooldownRemaining = cooldownMax;
        OnCooldown = true;
    }
}
