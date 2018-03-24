using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardShow : MonoBehaviour {
    public Card card;
    public Text[] text;
	// Use this for initialization
	void Start () {
        text[0].text = card.cost.ToString();
        text[1].text = card.cardName;
        text[2].text = card.info;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
