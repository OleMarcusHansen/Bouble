using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GasBubble : MonoBehaviour
{
    public bool gracePeriod;
    public float oxygen;
    public float upgas;
    public float downgas;

    public float gasTotal;

    [SerializeField] SpriteRenderer bubbleSprite;
    CircleCollider2D circleCollider;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        gracePeriod = true;
    }
    void Start()
    {
        UpdateBubble();
    }

    public void SetGasses(float ox, float up, float down)
    {
        oxygen = ox;
        upgas = up;
        downgas = down;

        gasTotal = downgas + upgas + oxygen;

        UpdateBubble();
    }

    protected void UpdateBubble()
    {
        bubbleSprite.transform.localScale = Vector3.one * (oxygen + upgas + downgas) / 10f;
        circleCollider.radius = (oxygen + upgas + downgas) / 10f / 2f;

        //set color
        gasTotal = downgas + upgas + oxygen;
        bubbleSprite.color = new Color(downgas / gasTotal, upgas / gasTotal, oxygen / gasTotal, 0.5f);
    }
}
