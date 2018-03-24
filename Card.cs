using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler {
    public string cardName="未命名卡牌";
    public float attack=5;
    public int cost=10;
    public string info="无作用说明";
    public People people,other;
    public HandCenter handCenter;
    public static Card choiceCard;
    Action choiceCallback;
   // bool choice;

    public UnityEvent effect=new UnityEvent();
    public void SelectCallback(GameObject otherObject)
    {
        other = otherObject.GetComponent<People>();
        choiceCallback();
       
    }
    [ContextMenu("play")]
    public void Play()
    {
        effect.Invoke();
        Debug.Log("使用卡牌" + cardName);
    }

  
    public void Attack()
    {
        SelectCurve.single.Select(SelectTag.People);
        choiceCallback=delegate { people.Attack(other, attack);
            PlayCard(); };
    }
    void PlayCard()
    {
        choiceCard = null;
        handCenter.PlayCard(this);
    }
    private void Update()
    {
      
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectCurve.single.UnSelect();
        choiceCard = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // if (choiceCard == this) { if (choi) { } else { choiceCard = null; } }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Play();
    }
}
