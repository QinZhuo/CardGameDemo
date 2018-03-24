using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour {
    public List<Transform> posList = new List<Transform>();
    Lerp lerp;
    // Use this for initialization
    void Awake() {
        lerp = Init(posList);
    }
    public Vector3 GetPos(float t)
    {
        return lerp.GetPos(t);   
    }
	public Lerp Init(List<Transform> pos)
    {
        List<Lerp> lerps=new List<Lerp>();
        if (pos.Count <= 2)
        {
            Debug.LogError("多阶贝塞尔曲线需要2个以上初始位置");
        }
        
        for (int i =1; i < pos.Count; i++)
        {
            lerps.Add(new Lerp(pos[i - 1], pos[i]));
        }
        return Init(lerps);
    }
    Lerp Init(List<Lerp> lerps)
    {
        List<Lerp> newLerps = new List<Lerp>();
        if (lerps.Count <= 1) Debug.LogError("递归曲线出错");
        for (int i = 1; i < lerps.Count; i++)
        {
            newLerps.Add(new Lerp(lerps[i - 1], lerps[i]));
        }
        if (newLerps.Count == 1) return newLerps[0];
        else return Init(newLerps);
    }
        // Update is called once per frame
    void Update () {
       
	}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        if (lerp != null)
        {
            for (int i = 1; i <= 10; i++)
            {
                Gizmos.DrawLine(lerp.GetPos((i-1f) / 10.0f), lerp.GetPos(i / 10.0f));
            }
        }
    }
}
public class Lerp
{
    Lerp start, end;
    Vector3 startPos, endPos;
    Transform startTrans, endTrans;
    public Lerp(Lerp start,Lerp end)
    {
        this.start = start;
        this.end = end;
    }
    public Lerp(Transform startTrans, Transform endTrans)
    {
        start = null;
        end = null;
        this.startTrans = startTrans;
        this.endTrans = endTrans;
       
        
    }
    public Vector3 GetPos(float t)
    {

        if (start != null)
        {
            startPos = start.GetPos(t);
        }
        else
        {
            startPos = startTrans.position;
        }
        if (end != null)
        {
            endPos = end.GetPos(t);
        }
        else
        {
            endPos = endTrans.position;
        }
       // Debug.Log(startPos+","+endPos);
        return Vector3.Lerp(startPos, endPos, t);
    }
}