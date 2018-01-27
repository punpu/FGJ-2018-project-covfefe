using UnityEngine;

public class FingerBehavior : MonoBehaviour {
    public float moveSpeed = 1f;

    void Update () {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 3), step);
	}
}
