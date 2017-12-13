using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackjack : MonoBehaviour {

    public CardStack deck;
    public CardStack dealer;
    //public CardStack player;
    public Player player;

    public GameObject playerPrefab;

    public Button hitButton;
    public Button standButton;
    public Button playAgainButton;


    public Text winnerText;
    public Text dealerScore;
    public Text playerScore;

	// Use this for initialization
	void Start () {
        StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        GameObject playerCopy = (GameObject)Instantiate(playerPrefab);
        player = playerCopy.GetComponent<Player>();
        //newPlayer.SetSeatPosition(0);

        deck.CreateDeck(6);
        Deal();


    }

    void Deal()
    {
        player.Push(deck.Pop());
        dealer.Push(deck.Pop());
        player.Push(deck.Pop());

        dealerScore.text = dealer.CardValue().ToString();
        playerScore.text = player.HandValue().ToString();
    }

    public void Hit()
    {
        player.Push(deck.Pop());

        playerScore.text = player.HandValue().ToString();

        if (player.HandValue() > 21)
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

        hitButton.interactable = false;
        standButton.interactable = false;
        playAgainButton.interactable = true;
    }

    IEnumerator DealersTurn()
    {
        while (dealer.CardValue() < 17)
        {
            dealer.Push(deck.Pop());
            dealerScore.text = dealer.CardValue().ToString();
            yield return new WaitForSeconds(1f);
        }
        GetWinner();

    }

    void GetWinner()
    {
        if (player.HandValue() > dealer.CardValue() || dealer.CardValue() > 21)
        {
            winnerText.text = "You Win";
        }
        else if (player.HandValue() == dealer.CardValue())
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
        dealerScore.text = "";
        playerScore.text = "";

        player.GetComponent<Player>().Clear();
        dealer.GetComponent<CardStackView>().Clear();
        Deal();
    }
}
