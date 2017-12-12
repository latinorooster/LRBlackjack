using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : MonoBehaviour {

    public CardStack deck;
    public CardStack dealer;
    public CardStack player;

	// Use this for initialization
	void Start () {
        StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        deck.CreateDeck(6);
        Deal();
    }

    void Deal()
    {
        player.Push(deck.Pop());
        dealer.Push(deck.Pop());
        player.Push(deck.Pop());
    }

    public void Hit()
    {
        player.Push(deck.Pop());
        if (player.IsBusted())
        {
            //Do Something
        }
    }

    public void Stand()
    {
        StartCoroutine(DealersTurn());
    }

    IEnumerator DealersTurn()
    {
        while (dealer.CardValue() < 17)
        {
            dealer.Push(deck.Pop());
            yield return new WaitForSeconds(1f);
        }

        if (dealer.IsBusted())
        {
            //Do Something
        }

        yield return new WaitForSeconds(1f);
    }
}
