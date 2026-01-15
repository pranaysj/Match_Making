using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int timeToLevelComplete;
    public Image timeImage;
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text turnText;

    Coroutine timer;
    int score;
    int turn;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        timer = StartCoroutine(Timer());
        AddScore(0);
    }

    IEnumerator Timer()
    {
        int tempTimer = timeToLevelComplete;
        timeText.text = tempTimer.ToString();
        while(tempTimer > 0)
        {
            tempTimer--;
            yield return new WaitForSeconds(1);

            timeImage.fillAmount = tempTimer / (float)timeToLevelComplete;
            timeText.text = tempTimer.ToString();
        }

        GameManager.instance.GameOver();

    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString("D8");
    }

    public void AddTurn()
    {
        turn++;
        turnText.text = turn.ToString("D2");
    }

    public void StopTimer()
    {
        StopCoroutine(timer);
    }
}
