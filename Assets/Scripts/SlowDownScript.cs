using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownScript : MonoBehaviour {

    public float SlowdownAmmount = 6;
    public bool wasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnSlowdown trigger entered");

        if (other.tag == "Player" && !wasTriggered)
        {
            PlayerSpeedController.GetInstance().RemoveGravity(SlowdownAmmount);
            wasTriggered = true;
        }
    }
}
