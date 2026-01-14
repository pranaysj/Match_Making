using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool picked;
    bool isGameOver;
    List<Card> pickedCard = new List<Card>();
    private int pairs;
    private int pairCounter;
    public int scorePerMatch = 20;

    private void Awake()
    {
        instance = this;
    }

    public void AddCardToPickedList(Card card)
    {
        pickedCard.Add(card);
        if(pickedCard.Count == 2)
        {
            picked = true;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1.0f);
        if (pickedCard[0].GetCardID() == pickedCard[1].GetCardID())
        {
            //pickedCard[0].gameObject.SetActive(false);
            //pickedCard[1].gameObject.SetActive(false);
            pickedCard[0].GetComponent<BoxCollider>().enabled = false;
            pickedCard[1].GetComponent<BoxCollider>().enabled = false;

            pairCounter++;
            CheckForWin();

            ScoreManager.instance.AddScore(scorePerMatch);
        }
        else
        {
            pickedCard[0].FlipOpen(false);
            pickedCard[1].FlipOpen(false);
            yield return new WaitForSeconds(1.0f);
        }

        picked = false;
        pickedCard.Clear();

        ScoreManager.instance.AddTurn();
    }

    private void CheckForWin()
    {
        if(pairs == pairCounter)
        {
            Debug.Log("WIN");
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
    }

    public bool GameIsOver()
    {
        return isGameOver;
    }

    public bool HasPicked()
    {
        return picked;
    }

    public void SetPairs(int pairAmount)
    {
        pairs = pairAmount;
    }
}
