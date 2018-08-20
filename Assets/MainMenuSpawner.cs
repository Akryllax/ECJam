using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour {

    public float Delay = 5;

    private float timeStamp;

    [SerializeField]
    private GameObject prefab;

    private void Start()
    {
        StartCoroutine(StartSpawning());
        timeStamp = Time.time;
    }
    
    IEnumerator StartSpawning()
    {
        while(true)
        {
            if(timeStamp + Delay < Time.time)
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.position += Vector3.up * 1.5f + new Vector3(Random.Range(-0.5f,0.5f), 0, Random.Range(-0.5f, 0.5f));
                obj.transform.rotation = Random.rotation;
                obj.GetComponent<Rigidbody>().velocity = Vector3.up * 50f;

                Destroy(obj, 10);

                timeStamp = Time.time;
            }

            yield return null;
        }
    }
}
