using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionEntity : MonoBehaviour {

    public DecisionDescriptor descriptor;
    public MessageDisplay display;

    public DecisionBox[] noBoxes;
    public DecisionBox[] yesBoxes;

    public float DestroyDelay = 0;

    private bool wasCollided = false;

	// Use this for initialization
	void Start () {
		if(descriptor)
        {
            if(descriptor.noObject)
            {
                var obj = Instantiate(descriptor.noObject);
                obj.transform.position = noBoxes[0].transform.position;
                obj.transform.parent = this.transform;

                foreach (DecisionBox db in noBoxes)
                {
                    Destroy(db.gameObject);
                }

                var comp = obj.AddComponent<DecisionBox>();
                comp.decisionType = DecisionBox.DecisionType.NO;

                noBoxes[0] = comp;
            }

            if (descriptor.yesObject)
            {
                var obj = Instantiate(descriptor.yesObject);
                obj.transform.position = yesBoxes[0].transform.position;
                obj.transform.parent = this.transform;

                foreach (DecisionBox db in yesBoxes)
                {
                    Destroy(db.gameObject);
                }

                var comp = obj.AddComponent<DecisionBox>();
                comp.decisionType = DecisionBox.DecisionType.YES;

                yesBoxes[0] = comp;
            }

            if(descriptor.Title != "")
            {
                display.gameObject.SetActive(true);
                display.DisplayTitle(descriptor.Title, descriptor.textNO, descriptor.textYES);

                display.transform.parent = null;
                Destroy(display.gameObject, 3f);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y - 1 > PlayerEntity.instance.transform.position.y)
        {
            if (!wasCollided)
            {
                wasCollided = true;
                DecisionSpawner.instance.SpawnDecision(this.descriptor);
            }
        }
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
            DecisionSpawner.instance.SpawnDecision(descriptor.yesNext);
        }
        else
        {
            DecisionSpawner.instance.SpawnDecision(descriptor.noNext);
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
