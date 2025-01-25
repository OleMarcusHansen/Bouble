using System.Diagnostics.Tracing;
using UnityEngine;

public class BubbleSplit : MonoBehaviour
{
    public MovementBehavior movementBehavior;
    public GameObject bubblePrefab;
    public PlayerBubble playerBubble;
    public float minScale = 1f;
    private Vector3 bubblesize;
    void SplitBubble(){
            GameObject bubblecopy = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            bubblecopy.GetComponent<GasBubble>().SetGasses(playerBubble.oxygen/2, playerBubble.upgas/2, playerBubble.downgas/2); 
            playerBubble.oxygen /= 2;
            playerBubble.upgas /= 2;
            playerBubble.downgas /= 2;
            movementBehavior.bubbleBoostValue = 100f;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SplitBubble();  
        }

    }
}
