using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CardStack cards;
    public int seat;

    Vector3[] seatPositions = new[] { new Vector3(5.296f, -.441274f, 0.548f), new Vector3(4.64f, -0.4312742f, 0.245f), new Vector3(3.958f, -0.4412742f, 0.601f) };

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
        cards.GetComponent<CardStackView>().startPosition = seatPositions[seat];
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
