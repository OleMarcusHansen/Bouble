using System.Collections;
using UnityEngine;

public class SpawnBubbleManager : MonoBehaviour
{
    [SerializeField] GameObject gasBubblePrefab;
    [SerializeField] GameObject seaMinePrefab;

    Drift playerDrift;

    [SerializeField] float spawnDistance = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnClusterAhead), 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        playerDrift = GameObject.FindGameObjectWithTag("Player").GetComponent<Drift>();
    }

    void SpawnBubbleAhead()
    {
        Vector3 position = playerDrift.transform.position;
        position += new Vector3 (playerDrift.driftHorizontalDirection * spawnDistance, playerDrift.driftVerticalDirection * spawnDistance, 0);
        SpawnBubble(position);
    }

    void SpawnClusterAhead()
    {
        Vector3 position = playerDrift.transform.position;
        position += new Vector3(playerDrift.driftHorizontalDirection * spawnDistance, playerDrift.driftVerticalDirection * spawnDistance, 0);
        SpawnCluster(position);
    }

    void SpawnBubble(Vector3 position)
    {
        GasBubble newBubble = Instantiate(gasBubblePrefab, position, new Quaternion(0, 0, 0, 0)).GetComponent<GasBubble>();
        newBubble.SetGasses(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }

    void SpawnMine(Vector3 position)
    {
        Instantiate(seaMinePrefab, position, new Quaternion(0, 0, 0, 0)).GetComponent<GasBubble>();
    }

    void SpawnCluster(Vector3 position)
    {
        for (int i = 0; i < Random.Range(4, 14); i++)
        {
            if (Random.Range(0, 10) > 3)
            {
                SpawnBubble(position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0));
            }
            else
            {
                SpawnMine(position + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0));
            }
        }
    }
}
