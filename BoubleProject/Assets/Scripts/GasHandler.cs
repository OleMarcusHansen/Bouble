using UnityEngine;
using TMPro;

public class GasHandler : MonoBehaviour
{
    PlayerBubble player;

    [SerializeField] TMP_Text oxygenText;
    [SerializeField] TMP_Text upgasText;
    [SerializeField] TMP_Text downgasText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBubble>();
    }

    // Update is called once per frame
    void Update()
    {
        oxygenText.text = "Oxygen: \n" + Mathf.Round(player.oxygen * 10f) / 10f;
        upgasText.text = "Upgas: \n" + Mathf.Round(player.upgas * 10f) / 10f;
        downgasText.text = "Downgas: \n" + Mathf.Round(player.downgas * 10f) / 10f;
    }
}
