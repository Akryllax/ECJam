using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : ExMono {

    public PlayerEntity playerEntity;

	// Update is called once per frame
	void FixedUpdate () {
        Vector2 inputVector = Vector2.zero;

        inputVector.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        playerEntity.TickInputVector(inputVector);
    }
}
