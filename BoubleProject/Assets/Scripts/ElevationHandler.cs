using UnityEngine;
using TMPro;

public class ElevationHandler : MonoBehaviour
{
    Transform player;

    TMP_Text elevationText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        elevationText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        elevationText.text = Mathf.Floor(player.position.y).ToString() + " m";
    }
}
