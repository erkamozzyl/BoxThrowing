using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private float timeRemaining = 120;
   
    public Text timeText;
    public Text scoreText;
    public ScoreCounter getScore;
    public GameObject gameOverPanel;
    public GameObject player;
   
 
 private void Start()
 {
     getScore = FindObjectOfType<ScoreCounter>();
     gameOverPanel.SetActive(false);
     Application.targetFrameRate = 60;

 }
void Update()
    {
       
        if (timeRemaining > 0 && player.transform.position.y > 0  )
        {
            timeRemaining -= Time.deltaTime;
        }else
        {
            if (PlayerPrefs.GetInt("highScore") < getScore.score)
            {
                PlayerPrefs.SetInt("highScore",getScore.score);
            }
            PlayerPrefs.SetInt("currentScore",getScore.score);
            gameOverPanel.SetActive(true);
        }
   
            
        timeText.text =  Mathf.Floor(timeRemaining / 60 ).ToString("00")  + ":" + Mathf.FloorToInt(timeRemaining %60).ToString("00");
        scoreText.text = getScore.score.ToString();
    }
}
