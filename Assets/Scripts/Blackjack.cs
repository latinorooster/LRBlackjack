using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackjack : MonoBehaviour {

    public CardStack deck;
    public CardStack dealer;
    public CardStack player;

    public Button hitButton;
    public Button standButton;
    public Button playAgainButton;


    public Text winnerText;

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
            winnerText.text = "You Lose";
            hitButton.interactable = false;
            standButton.interactable = false;
            playAgainButton.interactable = true;
        }
    }

    public void Stand()
    {
        StartCoroutine(DealersTurn());
        GetWinner();

        hitButton.interactable = false;
        standButton.interactable = false;
        playAgainButton.interactable = true;
    }

    IEnumerator DealersTurn()
    {
        while (dealer.CardValue() < 17)
        {
            dealer.Push(deck.Pop());
            yield return new WaitForSeconds(1f);
        }

    }

    void GetWinner()
    {
        if (player.CardValue() > dealer.CardValue() || dealer.CardValue() > 21)
        {
            winnerText.text = "You Win";
        }
        else if (player.CardValue() == dealer.CardValue())
        {
            winnerText.text = "Draw";
        }
        else
        {
            winnerText.text = "You Lose";
        }
    }

    public void PlayAgain()
    {
        playAgainButton.interactable = false;
        hitButton.interactable = true;
        standButton.interactable = true;
        winnerText.text = "";

        player.GetComponent<CardStackView>().Clear();
        dealer.GetComponent<CardStackView>().Clear();
        Deal();
    }
}
