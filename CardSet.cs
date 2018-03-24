using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSet : MonoBehaviour {
    public static CardSet single;
    public Transform[] cardPos;
    public List<Card> nextCard;
    public List<Card> discard;
    public List<Card> deleteCard;
    // Use this for initialization
    void Awake () {
        single = this;

    }
    
	public Card GetCard()
    {
        if (nextCard.Count == 0) { Debug.Log("进行洗牌"); Shuffle(); }
        if (nextCard.Count == 0) return null;
        Card newCard = nextCard[0];
        nextCard.RemoveAt(0);
        return newCard;
    }
 
    public void Shuffle()
    {
        for (int i = discard.Count-1; i>=0; i--)
        {
            int index = Random.Range(0, i);
            nextCard.Add(discard[index]);
            discard[index].transform.parent = cardPos[0].transform;
            discard.Remove(discard[index]);
            
        }
        UpdateCardsPos();
    }
    public void Discard(params Card[] card)
    {
        discard.AddRange(card);
    }
    public void UpdateCardsPos()
    {
        foreach (var card in nextCard)
        {
            card.transform.position = cardPos[0].position;
        }
        foreach (var card in discard)
        {
            card.transform.position = cardPos[1].position;
        }
        foreach (var card in deleteCard)
        {
            card.transform.position = cardPos[2].position;
        }
    }
	// Update is called once per frame
	void Update () {
        UpdateCardsPos();

    }
}
