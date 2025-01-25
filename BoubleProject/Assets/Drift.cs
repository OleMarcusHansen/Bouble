using UnityEngine;

public class Drift : MonoBehaviour
{
    public int driftBaseVel = 1;
    private Vector3 initialPosition;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
