using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionBox : ExMono {

    public enum DecisionType { NO, YES }

    public DecisionType decisionType;

    public Vector3 startingSpeed = new Vector3(0, 9.8f, 0);
    private DecisionEntity decisionEntity;

	// Use this for initialization
	void Start () {
        decisionEntity = transform.parent.gameObject.GetComponent<DecisionEntity>();
        this.GetComponent<Rigidbody>().velocity = startingSpeed;
    }
	
    private void OnCollisionEnter(Collision collision)
    {
        decisionEntity.TriggerDecision(decisionType == DecisionType.YES);
    }
}
