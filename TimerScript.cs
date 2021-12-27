using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private Text timerText;
    private float timer = 0.0f;

    public Animator victoryAnim;
    public GameObject player;
    private Move playerScript;

    void Awake()
    {
        timerText = GetComponent<Text>();
        playerScript = player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.screenAnim.GetBool("IsGameOver") == false && victoryAnim.GetBool("Victory") == false)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }
    }

    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
