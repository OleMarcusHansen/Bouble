using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerBubble : GasBubble
{
    [SerializeField] TMP_Text oxygenText;
    [SerializeField] TMP_Text upgasText;
    [SerializeField] TMP_Text downgasText;

    // Update is called once per frame
    void Update()
    {
        oxygen -= Time.deltaTime;
        oxygenText.text = "Oxygen: \n" + Mathf.Round(oxygen * 10f) / 10f;

        UpdateBubble();
    }

    void AddGasses(float ox, float up, float down)
    {
        oxygen += ox;
        upgas += up;
        downgas += down;

        oxygenText.text = "Oxygen: \n" + Mathf.Round(oxygen * 10f) / 10f;
        upgasText.text = "Upgas: \n" + Mathf.Round(upgas * 10f) / 10f;
        downgasText.text = "Downgas: \n" + Mathf.Round(downgas * 10f) / 10f;
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
