using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [HideInInspector] public int pairAmount;
    [HideInInspector] public int width;
    [HideInInspector] public int height;

    public List<Sprite> spriteList = new List<Sprite>();
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
        List<Sprite> tempSprite = new List<Sprite>();
        tempSprite.AddRange(spriteList);

        //Card Deck     
        for (int i = 0; i < pairAmount; i++)
        {
            int randomIndex = Random.Range(0, tempSprite.Count);

            for (int j = 0; j < 2; j++)
            {
                Vector3 pos = Vector3.zero;
                GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
                newCard.GetComponent<Card>().SetCard(i, tempSprite[randomIndex]);
                cardDeck.Add(newCard);
            }

            tempSprite.RemoveAt(randomIndex);
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
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * offset, 0, z * offset);
                Gizmos.DrawWireCube(pos, new Vector3(1.0f, 0.1f, 1.0f));
            }
        }
    }
}
