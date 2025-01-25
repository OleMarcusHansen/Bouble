using Unity.VisualScripting;
using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    float oxygen = 10;
    float upgas = 10;
    float downgas = 10;

    [SerializeField] Transform bubbleSprite;
    CircleCollider2D circleCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        oxygen -= Time.deltaTime;

        UpdateSize();
    }

    void AddOxygen(float amount)
    {
        oxygen += amount;
    }
    void AddUpgas(float amount)
    {
        upgas += amount;
    }
    void AddDowngas(float amount)
    {
        downgas += amount;
    }

    void UpdateSize()
    {
        bubbleSprite.localScale = Vector3.one * (oxygen + upgas + downgas) / 10f;
        circleCollider.radius = (oxygen + upgas + downgas) / 10f / 2f;
    }


    void OnCollisionEnter2D(Collision collision)
    {
        Debug.Log("collided with: " + collision.gameObject);

        if (collision.gameObject.GetComponent<GasBubble>())
        {

        }
    }
}
