using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionEntity : MonoBehaviour {

    public DecisionBox[] noBoxes;
    public DecisionBox[] yesBoxes;

    public float DestroyDelay = 0;

    private bool wasCollided = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TriggerDecision(bool IsYes)
    {
        if (wasCollided)
            return;

        wasCollided = true;

        Debug.Log("Playing grunt");
        PlayerEntity.instance.PlayHitSound();

        if(IsYes)
        {

        }
        else
        {

        }

        ClearAllBoxes(5);
    }

    public void ClearAllBoxes(float dealy = 0)
    {
        StartCoroutine(DestroyBoxes(dealy));
    }

    IEnumerator DestroyBoxes(float delay = 0)
    {
        if(delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }

        foreach (DecisionBox db in noBoxes)
        {
            Destroy(db.gameObject);
        }

        foreach (DecisionBox db in yesBoxes)
        {
            Destroy(db.gameObject);
        }

        Destroy(this.gameObject, 0.5f);

        yield return null;
    }
}
