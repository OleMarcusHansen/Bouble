using UnityEngine;

public class Drift : MonoBehaviour
{
    public float driftBaseVel = 0.05f;
    public float driftHorizontalDirection = 0.5f;
    public float driftVerticalDirection = 0.5f;
    private Vector3 initialPosition;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float driftHorizontalMove = driftBaseVel * driftHorizontalDirection;
        float driftVerticalMove = driftBaseVel * driftVerticalDirection;
        transform.position += new Vector3(driftHorizontalMove, driftVerticalDirection, 0);
    }
}
