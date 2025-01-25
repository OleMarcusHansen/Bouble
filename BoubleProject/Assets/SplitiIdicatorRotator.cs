using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.iOS;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class SplitiIdicatorRotator : MonoBehaviour
{  

    public Vector3 indicatorRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        indicatorRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 IncursorPosition = Input.mousePosition;
        Vector3 IncursorWorldPosition = Camera.main.ScreenToWorldPoint(IncursorPosition);
        IncursorWorldPosition.z = transform.position.z;
        Vector3 direction = IncursorWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
