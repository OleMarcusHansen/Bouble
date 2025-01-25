using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BubbleConfinement : MonoBehaviour
{
    public Drift drift;
    public GameObject gameWindowConstraint;
    private Vector2 areaMin;
    private Vector2 areaMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 boxPosition = gameWindowConstraint.transform.position;
        Vector2 boxSize = gameWindowConstraint.transform.localScale;
        areaMin = new Vector2(boxPosition.x -boxSize.x / 2 ,  boxPosition.y - boxSize.y / 2);
        areaMax = new Vector2(boxPosition.x + boxSize.x / 2, boxPosition.y + boxSize.y / 2 );
    }

    // Update is called once per frame
    void Update()
    {
        
        float drifter = drift.driftHorizontalDirection;
        Vector3 newPosition = transform.position + new Vector3(drifter, 0, 0) * Time.deltaTime;

        if (newPosition.x > areaMax.x) {
            newPosition.x = areaMin.x;
        }
        else if (newPosition.x < areaMin.x){
            newPosition.x = areaMax.x;
        }
        transform.position = newPosition;
    }
}
