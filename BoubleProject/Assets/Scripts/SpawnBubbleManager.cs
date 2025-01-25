using System.Collections;
using UnityEngine;

public class SpawnBubbleManager : MonoBehaviour
{
    [SerializeField] GameObject gasBubblePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBubble(Vector3 position)
    {
        Instantiate(gasBubblePrefab, position, new Quaternion(0, 0, 0, 0));
    }
}
