using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackjack : MonoBehaviour {

    public CardStack deck;
    public CardStack dealer;
    //public CardStack player;
    //public Player player;

    List<Player> players;
    int currentPlayer;
    int waitingPlayers = 0;
    private static int MAX_PLAYERS = 3;

    public GameObject playerPrefab;

    public Button hitButton;
    public Button standButton;
    public Button playAgainButton;
    public Button addPlayerButton;


    public Text winnerText;
    public Text dealerScore;
    public Text playerScore;

	// Use this for initialization
	void Start () {
        players = new List<Player>();
        StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        GameObject playerCopy = (GameObject)Instantiate(playerPrefab);
        Player newPlayer = playerCopy.GetComponent<Player>();
        newPlayer.SetSeatPosition(0);
        players.Add(newPlayer);

        deck.CreateDeck(6);
        Deal();

    }

    int NumberOfPlayers()
    {

            if (players == null)
            {
                return 0;
            }
            else
            {
                return players.Count;
            }
        
    }

    void Deal()
    {

        foreach (Player p in players)
        {
            p.Push(deck.Pop());
        }
        
        dealer.Push(deck.Pop());
        foreach (Player p in players)
        {
            p.Push(deck.Pop());
        }

        dealerScore.text = dealer.CardValue().ToString();
        DisplayPlayerScore();
        //currentPlayer = players[0];
    }

    void DisplayPlayerScore()
    {
        string score = "";

        foreach (Player p in players)
        {
            score += p.HandValue().ToString() + " ";
        }

        playerScore.text = score;
    }

    public void NextPlayer()
    {
        if (currentPlayer < NumberOfPlayers()-1)
        {
            currentPlayer++;
        }
        else
        {

            StartCoroutine(DealersTurn());

        }
    }

    public void Hit()
    {
        players[currentPlayer].Push(deck.Pop());

        DisplayPlayerScore();

        if (players[currentPlayer].HandValue() > 21)
        {
            NextPlayer();
            //winnerText.text = "You Lose";
            //hitButton.interactable = false;
            //standButton.interactable = false;
            //playAgainButton.interactable = true;
        }

    }

    IEnumerator DealersTurn()
    {

        hitButton.interactable = false;
        standButton.interactable = false;


        while (dealer.CardValue() < 17)
        {
            yield return new WaitForSeconds(1f);
            dealer.Push(deck.Pop());
            dealerScore.text = dealer.CardValue().ToString();
        }
        GetWinner();

        playAgainButton.interactable = true;
    }

    void GetWinner()
    {
        //if (player.HandValue() > dealer.CardValue() || dealer.CardValue() > 21)
        //{
        //    winnerText.text = "You Win";
        //}
        //else if (player.HandValue() == dealer.CardValue())
        //{
        //    winnerText.text = "Draw";
        //}
        //else
        //{
        //    winnerText.text = "You Lose";
        //}
    }

    public void PlayAgain()
    {
        playAgainButton.interactable = false;
        hitButton.interactable = true;
        standButton.interactable = true;
        winnerText.text = "";
        dealerScore.text = "";
        playerScore.text = "";

        foreach (Player p in players)
        {
            p.GetComponent<Player>().Clear();
        }
        
        dealer.GetComponent<CardStackView>().Clear();

        while (waitingPlayers > 0)
        {
            GameObject playerCopy = (GameObject)Instantiate(playerPrefab);
            Player newPlayer = playerCopy.GetComponent<Player>();
            newPlayer.SetSeatPosition(NumberOfPlayers());
            players.Add(newPlayer);

            waitingPlayers--;
        }
        currentPlayer = 0;
        Deal();
    }

    public void AddPlayer()
    {
        if (waitingPlayers + NumberOfPlayers() < MAX_PLAYERS)
        {
            waitingPlayers++;
        }

        if (waitingPlayers+NumberOfPlayers() == MAX_PLAYERS)
        {
            addPlayerButton.interactable = false;
        }
        
    }
}
