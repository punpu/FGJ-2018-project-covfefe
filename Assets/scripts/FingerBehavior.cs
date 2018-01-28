using UnityEngine;

public class FingerBehavior : MonoBehaviour {
    public float moveSpeed = 1f;
    public float endX = 0;
    public float endY = 3;
    public GameObject badEndMenu;

    private Vector2 endCoordinates;
    private Vector3 endPosition;

    void Start() {
        endCoordinates = new Vector2(endX, endY); 
        endPosition = new Vector3(endX, endY, 0);
    }

    void Update () {
        if (transform.position == endPosition) {
            badEndMenu.SetActive(true);
        }
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, endCoordinates, step);
	}
}
