using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionSpawner : MonoBehaviour {

    public float Rate;

    public DecisionDescriptor nextItem;
    public GameObject decisionPrefab;
    public Transform targetRoot;

    public float MinimumDelay = 10;

    public int StartingID;

    private float tsmp_lastSpawned;

    public static DecisionSpawner instance;

    private void Start()
    {
        instance = this;

        tsmp_lastSpawned = 0;

        StartCoroutine(DelaySpawn());
    }

    IEnumerator StartDelayed()
    {
        yield return new WaitForSeconds(2f);

        StartCoroutine(DelaySpawn());
    }

    // Update is called once per frame
    void Update () {
		/*if(tsmp_lastSpawned + (1f/Rate) < Time.time)
        {
            SpawnObject();
            tsmp_lastSpawned = Time.time;
        }*/
	}

    IEnumerator DelaySpawn(DecisionDescriptor descriptor = null)
    {
        if(tsmp_lastSpawned + MinimumDelay > Time.time)
        {
            float delay = MinimumDelay - (Time.time - tsmp_lastSpawned);
            yield return new WaitForSeconds(delay);
        }

        if(descriptor)
        {
            GameObject gameObject = Instantiate(decisionPrefab);
            gameObject.transform.position = GeneratePosition();
            var decision = gameObject.GetComponent<DecisionEntity>();
            decision.descriptor = descriptor;

            tsmp_lastSpawned = Time.time;

            Destroy(gameObject, 10);
        } else
        {
            GameObject gameObject = Instantiate(decisionPrefab);
            gameObject.transform.position = GeneratePosition();
            gameObject.transform.parent = targetRoot;

            tsmp_lastSpawned = Time.time;

            Destroy(gameObject, 10);
        }
    }

    public void SpawnDecision(DecisionDescriptor descriptor)
    {
        StartCoroutine(DelaySpawn(descriptor));
        /*tsmp_lastSpawned = Time.time;

        GameObject gameObject = Instantiate(decisionPrefab);
        var decision = gameObject.GetComponent<DecisionEntity>();
        decision.descriptor = descriptor;

        Destroy(gameObject, 10);*/
    }

    public void SpawnObject()
    {
        StartCoroutine(DelaySpawn());
        /*GameObject gameObject = Instantiate(decisionPrefab);
        gameObject.transform.position = GeneratePosition();
        gameObject.transform.parent = targetRoot;

        tsmp_lastSpawned = Time.time;

        Destroy(gameObject, 10);*/
    }

    Vector3 GeneratePosition()
    {
        Vector3 result = targetRoot.position;

        return result;
    }

    Vector3 GetRandomPointInsideCollider()
    {
        BoxCollider collider = this.GetComponent<BoxCollider>();

        Vector3 result = new Vector3();

        Vector3 center = collider.center + collider.transform.position;
        Vector3 dimensions = collider.size;

        result = center + 
            new Vector3(
                Random.Range(
                    -dimensions.x, dimensions.x
                    ),
                Random.Range(
                    dimensions.y, -dimensions.y
                    ),
                Random.Range(
                    dimensions.z, -dimensions.z
                    )
        );

        return result;
    }
}
