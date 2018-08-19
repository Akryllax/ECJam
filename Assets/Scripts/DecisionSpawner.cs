using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionSpawner : MonoBehaviour {

    public float Rate;

    public GameObject prefab;
    public Transform targetRoot;

    public int StartingID;

    private float tsmp_lastSpawned;

	// Update is called once per frame
	void Update () {
		if(tsmp_lastSpawned + (1f/Rate) < Time.time)
        {
            SpawnObject();
            tsmp_lastSpawned = Time.time;
        }
	}

    void SpawnObject()
    {
        GameObject gameObject = Instantiate(prefab);
        gameObject.transform.position = GeneratePosition();
        gameObject.transform.parent = targetRoot;

        Destroy(gameObject, 10);

        //MessageDisplay.instance.DisplayTitle("Hello there!");
    }

    Vector3 GeneratePosition()
    {
        Vector3 result = this.transform.position;

        result += new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));

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
