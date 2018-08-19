using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour {

    public Transform target;
    public Vector3 delta;

	// Update is called once per frame
	void Update () {
        this.transform.position = target.position + delta;

    }
}
