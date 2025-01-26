using UnityEngine;

public class PlayerBubble : GasBubble
{

    // Update is called once per frame
    void Update()
    {
        if (oxygen > 0){
            oxygen -= Time.deltaTime* 0.2f;
        }
        UpdateBubble();

        if (oxygen < 0 || gasTotal < 10)
        {
            Debug.Log("Player died :(");
            Time.timeScale = 0;
        }
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
                if (!otherBubble.gracePeriod){
                    AddGasses(otherBubble.oxygen, otherBubble.upgas, otherBubble.downgas);
                    Destroy(otherBubble.gameObject);
                }

        }
    }
}
