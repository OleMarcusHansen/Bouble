using Unity.VisualScripting;
using UnityEngine;

public class PlayerBubble : GasBubble
{

    // Update is called once per frame
    void Update()
    {
        oxygen -= Time.deltaTime;

        UpdateBubble();
    }

    void AddGasses(float ox, float up, float down)
    {
        oxygen += ox;
        upgas += up;
        downgas += down;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with: " + collision.gameObject);

        if (collision.gameObject.GetComponent<GasBubble>())
        {
            GasBubble otherBubble = collision.gameObject.GetComponent<GasBubble>();

            AddGasses(otherBubble.oxygen, otherBubble.upgas, otherBubble.downgas);

            Destroy(otherBubble.gameObject);
        }
    }
}
