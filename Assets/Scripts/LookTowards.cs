using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour {

    public Transform target;

	// Update is called once per frame
	void Update () {
        this.transform.up = (target.transform.position - this.transform.position).normalized;

    }
}
