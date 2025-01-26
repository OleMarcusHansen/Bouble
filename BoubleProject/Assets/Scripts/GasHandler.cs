using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GasHandler : MonoBehaviour
{
    PlayerBubble player;

    [SerializeField] TMP_Text oxygenText;
    [SerializeField] TMP_Text upgasText;
    [SerializeField] TMP_Text downgasText;

    [SerializeField] GameObject loseScreen;
    [SerializeField] TMP_Text loseText;

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

        if (player.oxygen < 0 || player.gasTotal < 10)
        {
            loseText.text = "You died :(\nYour final score was: " + Mathf.Floor(player.transform.position.y).ToString() + " m";
            loseScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
