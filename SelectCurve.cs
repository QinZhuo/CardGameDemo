using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCurve : MonoBehaviour {
    public static SelectCurve single;
    public Curve curve;
    public Transform[] trans;
    public Vector3 lookAtUp;
    public bool select;
    RaycastHit hit;
    public string selectTag;
    // Use this for initialization
    void Awake () {
        single = this;
       
    }
	public void Select(SelectTag selectTag)
    {
        select = true;
        
        this.selectTag = selectTag.ToString();
    }
    public void UnSelect()
    {
        select = false;
    }
	// Update is called once per frame
	void Update () {
        if (select)
        {
            curve.posList[curve.posList.Count - 1].position = Input.mousePosition;
            transform.position = Card.choiceCard.transform.position;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {

                if (hit.collider.tag == "People")
                {
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        Card.choiceCard.SelectCallback(hit.collider.gameObject);
                        UnSelect();
                        return;
                    }
                }
            }

            for (int i = 0; i < trans.Length; i++)
            {
                trans[i].position = curve.GetPos((i + 0.0f) / trans.Length);

                trans[i].rotation = Quaternion.LookRotation(curve.GetPos((i + 0.5f) / trans.Length) - trans[i].position, Vector3.forward);
                trans[i].Rotate(new Vector3(-90, 0, 0));

            }
        }
        else
        {
            for (int i = 0; i < trans.Length; i++)
            {
                trans[i].position = new Vector3(1000, -200, 0);
            }
        }

    }
}
public enum SelectTag
{
    People,
}
