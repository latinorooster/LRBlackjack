using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour {

    CardStack deck;
    Dictionary<int, CardView> fetchedCards;
    public Vector3 startPosition;
    public float offsetPosition;
    public GameObject cardPrefab;
    public bool isDeck;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ShowCards();
	}

    void Awake()
    {
        fetchedCards = new Dictionary<int, CardView>();
        deck = GetComponent<CardStack>();
        ShowCards();
        
        //deck.Car
    }

    public void ShowCards()
    {
        if (isDeck)
        {
            return;
        }

        int cardCount = 0;
        
        if (deck.HasCards)
        {
            Debug.Log("Yes");
            foreach (Card c in deck.GetCards())
            {
                float co = offsetPosition * cardCount;
                Vector3 temp = startPosition + new Vector3(co, 0f);
                AddCard(temp, c.CardIndex, cardCount);
                cardCount++;
            }
        }
    }

    void AddCard(Vector3 position, int cardIndex, int positionalIndex)
    {
        
        if (fetchedCards.ContainsKey(cardIndex))
        {
            CardView cardViewExisting = fetchedCards[cardIndex].Card.GetComponent<CardView>();
            cardViewExisting.ShowCard();

            return;
        }

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.transform.position = position;

        CardView cardView = cardCopy.GetComponent<CardView>();
        cardView.cardIndex=cardIndex;
        cardView.ShowCard();
        
        //SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();

        fetchedCards.Add(cardIndex, new CardView(cardCopy));

    }
}
