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
        Debug.Log(dealer.CardValue());
        Debug.Log(player.CardValue());
    }

    void Deal()
    {
        player.Push(deck.Pop());
        dealer.Push(deck.Pop());
        player.Push(deck.Pop());
    }
}
