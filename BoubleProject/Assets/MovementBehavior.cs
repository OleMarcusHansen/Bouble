using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public float bubbleBoostValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontalMove = 1f * bubbleBoostValue;
        float moveVerticalMove = 1f * bubbleBoostValue;
        transform.position += new Vector3(moveHorizontalMove, moveVerticalMove, 0);
        bubbleBoostValue -= 1;
    }
}
