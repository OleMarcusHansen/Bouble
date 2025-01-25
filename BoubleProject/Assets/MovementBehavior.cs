using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public GameObject splitIndicator;
    public float bubbleBoostValue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 splitIndicatorDirection = splitIndicator.transform.right;
        float moveHorizontalMove = 0.0001f * bubbleBoostValue;
        float moveVerticalMove = 0.035f * bubbleBoostValue;
        transform.position += splitIndicatorDirection * moveHorizontalMove * bubbleBoostValue;
        if (bubbleBoostValue > 0) {
            bubbleBoostValue -= 1f;
        }
    }
}
