using System.Collections;
using UnityEngine;

public class SpawnBubbleManager : MonoBehaviour
{
    [SerializeField] GameObject gasBubblePrefab;

    [SerializeField] Drift playerDrift;

    [SerializeField] float spawnDistance = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnBubbleAhead), 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBubbleAhead()
    {
        Vector3 position = playerDrift.transform.position;
        position += new Vector3 (playerDrift.driftHorizontalDirection * spawnDistance, playerDrift.driftVerticalDirection * spawnDistance, 0);
        SpawnBubble(position);
    }

    void SpawnBubble(Vector3 position)
    {
        GasBubble newBubble = Instantiate(gasBubblePrefab, position, new Quaternion(0, 0, 0, 0)).GetComponent<GasBubble>();
        newBubble.SetGasses(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }
}
