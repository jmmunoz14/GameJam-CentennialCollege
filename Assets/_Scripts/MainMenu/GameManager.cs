using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Score").GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        scoreText.text = "Score: " + score.ToString();
        //BeginGame();
    }

    void Update()
    {

        //GameObject.Find("Score").GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        scoreText.text = "Score: " + score.ToString();
        //BeginGame();

    }

    public void BeginGame()
    {
        //TimerController.instance.BeginTimer();
    }
}
