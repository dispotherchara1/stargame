using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nabili : MonoBehaviour {

    public GameObject UnityChan;
    

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time,UnityChan.transform.lossyScale.y/10), transform.position.z);
    }
}