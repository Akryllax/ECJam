using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : ExMono {

    public float StartingGravity = 9.8f;

    private static PlayerSpeedController instance;

    private float targetGravity;
    
    public static PlayerSpeedController GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, 1, 0) * StartingGravity;
        targetGravity = Physics.gravity.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.gravity.magnitude != targetGravity)
        {
            Debug.Log("Change in gravity detected");

            Physics.gravity = Vector3.Lerp(Physics.gravity, new Vector3(0, 1, 0) * targetGravity, 0.5f);
            if(Mathf.Abs(Physics.gravity.magnitude) > Mathf.Abs(targetGravity * 0.95f))
            {
                Physics.gravity = new Vector3(0, 1, 0) * targetGravity;
            }
        }
	}

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 200, 20), "Gravity: " + Physics.gravity);
    }

    public void AddGravity(float value)
    {
        targetGravity += value;
    }

    public void RemoveGravity(float value)
    {
        targetGravity -= value;
    }
}
