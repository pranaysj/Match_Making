using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int cardID;
    public SpriteRenderer cardFrontSprite;
    public Animator animator;
    public GameObject fxConfitte;

    public void SetCard(int id, Sprite sprite)
    {
        cardID = id;
        cardFrontSprite.sprite = sprite;
    }

    public void FlipOpen(bool value)
    {
        animator.SetBool("isCardOpen", value);
    }

    public int GetCardID()
    {
        return cardID;
    }

    public void ActivateConfitte()
    {
        fxConfitte.SetActive(true);
    }
}
