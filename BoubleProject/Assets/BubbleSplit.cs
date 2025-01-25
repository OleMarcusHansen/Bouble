using System.Diagnostics.Tracing;
using UnityEngine;

public class BubbleSplit : MonoBehaviour
{
    public MovementBehavior movementBehavior;
    public GameObject bubblePrefab;
    public float minScale = 1f;
    private Vector3 bubblesize;
    void SplitBubble(){
            GameObject bubblecopy = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            bubblecopy.transform.localScale = bubblesize/2;
            bubblesize.x /= 2;
            bubblesize.y /= 2;
            movementBehavior.bubbleBoostValue = 10f;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubblesize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bubblesize.x > minScale +1 && bubblesize.y > minScale +1)
        {
            SplitBubble();  
        }
        transform.localScale = bubblesize;
    }
}
