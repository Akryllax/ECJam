using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceRelativeToPlayer : MonoBehaviour {

    public GameObject followTarget;
    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= followTarget.transform.position * Time.deltaTime * speed;
	}
}
