using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CardStack cards;

    //public int currentHandScore;
    public int wins = 0;
    public int losses = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Push(Card card)
    {
        cards.Push(card);
    }

    public int HandValue()
    {
        return cards.CardValue();
    }

    public void Clear()
    {
        cards.GetComponent<CardStackView>().Clear();
    }
}
