using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [HideInInspector] public int pairAmount;
    [HideInInspector] public int width;
    [HideInInspector] public int height;

    public Sprite[] spriteList;
    public GameObject cardPrefab;

    private float offset = 1.2f;

    public List<GameObject> cardDeck = new List<GameObject>();

    void Start()
    {
        GameManager.instance.SetPairs(pairAmount);
        CreatePlayField();
    }

    private void CreatePlayField()
    {
        //Card Deck     
        for (int i = 0; i < pairAmount; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 pos = Vector3.zero;
                GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
                newCard.GetComponent<Card>().SetCard(i, spriteList[i]);
                cardDeck.Add(newCard);
            }
        }

        //Shuffle
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int index = Random.Range(0, cardDeck.Count);
            var temp = cardDeck[i];
            cardDeck[i] = cardDeck[index];
            cardDeck[index] = temp;
        }

        int num = 0;
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * offset, 0, z * offset);
                cardDeck[num].transform.position = pos;
                num++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(pairAmount * 2 != width * height)
        {
            Debug.LogError("Width * Height should be PairAmount * 2");
        }

        if(pairAmount > spriteList.Length)
        {
            Debug.LogError("Not enough cards");
        }
    }
}
