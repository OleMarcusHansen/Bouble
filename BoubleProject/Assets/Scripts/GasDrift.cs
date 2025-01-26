using UnityEngine;

public class GasDrift : MonoBehaviour
{
    PlayerBubble playerBubble;
    [SerializeField] float speedMultiplier = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBubble = GetComponent<PlayerBubble>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = playerBubble.upgas - playerBubble.downgas;

        transform.position += new Vector3(0, moveY * speedMultiplier * Time.deltaTime, 0);
    }
}
