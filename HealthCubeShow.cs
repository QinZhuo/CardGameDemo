using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCubeShow : MonoBehaviour {
    public People people;
    public Vector3 start;
	// Use this for initialization
	void Start () {
        start = transform.localScale;
        people = GetComponentInParent<People>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(people.health.current / 100.0f, start.y, start.z);
	}
}
