using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCenter : MonoBehaviour {
    public List<Card> cards;
    public Vector3 center;
    public Vector3 start;
    public Vector3 end;
    // Use this for initialization
    void Start() {
        cards.Clear();
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }
    //[ContextMenu("GetCards")]
    //public void GetCardsInChilds()
    //{
    //    AddCard(GetComponentsInChildren<Card>());
    //}
    [ContextMenu("Draw")]
    public void DrawCard()
    {
        Card card = CardSet.single.GetCard();
        if (card == null)
        {
            Debug.LogError("无可抽取卡牌");
        }
        else
        {
            AddCard(card);
        }
        
    }
    public void AddCard(params Card[] card)
    {
        
       
        cards.AddRange(card);
        for (int i = 0; i < card.Length; i++)
        {
            card[i].transform.parent = transform;
            card[i].handCenter = this;
        }
    }
    public void PlayCard(Card card)
    {
        Card.choiceCard = null;
        cards.Remove(card);
        CardSet.single.Discard(card);
    }
	// Update is called once per frame
	void Update () {
        start = new Vector3(-(cards.Count+(Card.choiceCard==null?0:1)) / 2.0f*50, 0, 0);
        end= new Vector3((cards.Count+(Card.choiceCard == null ? 0 : 1)) / 2.0f*50, 0, 0);
        center = new Vector3(0, -700, 0);
        int index = 0;
        for (int i = 0; i < cards.Count; i++)
        {
           
            if (Card.choiceCard==cards[i])
            {
                index++;
            }
            cards[i].transform.localPosition = Vector3.Lerp(cards[i].transform.localPosition, Vector3.Slerp(start - center, end - center, (index + 0.5f) /( cards.Count+(Card.choiceCard == null ? 0 : 2))) + center, Time.deltaTime);
            if (Card.choiceCard == cards[i])
            {
                index++;
                cards[i].transform.rotation = Quaternion.LookRotation(-Vector3.up, Vector3.up);
            }
            else
            {
                cards[i].transform.rotation = Quaternion.LookRotation(center - cards[i].transform.localPosition, Vector3.forward);
            }
            cards[i].transform.localScale = Vector3.Lerp(cards[i].transform.localScale, new Vector3(1, 1, 1), Time.deltaTime);
            cards[i].transform.Rotate(new Vector3(-90, 0, 0));
            index++;
        }
    }
}
