using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GasBubble : MonoBehaviour
{
    public float oxygen;
    public float upgas;
    public float downgas;

    [SerializeField] SpriteRenderer bubbleSprite;
    CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        UpdateBubble();
    }

    public void SetGasses(float ox, float up, float down)
    {
        oxygen = ox;
        upgas = up;
        downgas = down;

        UpdateBubble();
    }

    protected void UpdateBubble()
    {
        bubbleSprite.transform.localScale = Vector3.one * (oxygen + upgas + downgas) / 10f;
        circleCollider.radius = (oxygen + upgas + downgas) / 10f / 2f;

        //set color
        float total = downgas + upgas + oxygen;
        bubbleSprite.color = new Color(downgas / total, upgas / total, oxygen / total, 0.5f);
    }
}
