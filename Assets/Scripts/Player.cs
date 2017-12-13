using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CardStack cards;

    Vector3[] seatPositions = new[] { new Vector3(5.296f, -.441274f, 0.548f) };

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        
    }

    public void SetSeatPosition(int seat)
    {
        cards.GetComponent<CardStackView>().startPosition = seatPositions[0];
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
