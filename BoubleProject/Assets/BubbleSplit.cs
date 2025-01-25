using System.Diagnostics.Tracing;
using UnityEngine;

public class BubbleSplit : MonoBehaviour
{
    public GameObject bubblePrefab;
    private Vector3 bubblesize;
    void SplitBubble(){
            Debug.Log("bubble split");
            GameObject bubblecopy = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            bubblesize.x /= 2;
            bubblesize.y /= 2;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubblesize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SplitBubble();
        }
        transform.localScale = bubblesize;
    }
}
