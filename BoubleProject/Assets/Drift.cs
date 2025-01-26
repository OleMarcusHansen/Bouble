using UnityEngine;

public class Drift : MonoBehaviour
{
    public float driftBaseVel = 0f;
    public float driftHorizontalDirection = 0.5f;
    public float driftVerticalDirection = 0.01f;
    public float directionflactuation = 0.5f;
    public float horizonalDirectionRange = 0.5f;
    public float verticalDirectionRange = 0.5f;
    public float HorizontalFlactuationMulti = 1;
    public float verticalFlactuationMulti = 1;
    private Vector3 initialPosition;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        driftHorizontalDirection = Mathf.Sin(Time.time * directionflactuation * HorizontalFlactuationMulti) * horizonalDirectionRange;
        driftVerticalDirection = Mathf.Sin(Time.time * directionflactuation* verticalFlactuationMulti) * verticalDirectionRange;
        float driftHorizontalMove = driftBaseVel * driftHorizontalDirection;
        float driftVerticalMove = driftBaseVel * driftVerticalDirection;
        transform.position += new Vector3(driftHorizontalMove, driftVerticalMove, 0);
    }
}
