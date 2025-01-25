using UnityEngine;

public class Drift : MonoBehaviour
{
    public float driftBaseVel = 0.05f;
    public float driftBaseDirection = 0.5f;
    private Vector3 initialPosition;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float driftHorizontalMove = driftBaseVel * driftBaseDirection;
        transform.position += new Vector3(driftHorizontalMove, 0, 0);
    }
}
