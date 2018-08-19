using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeFreefallScript : ExMono {

    public float SlowdownAmmount = 6;
    public bool wasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnResume trigger entered");

        if (other.tag == "Player" && !wasTriggered)
        {
            PlayerSpeedController.GetInstance().AddGravity(SlowdownAmmount);
            wasTriggered = true;
        }
    }
}
