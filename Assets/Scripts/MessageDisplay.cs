using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageDisplay : ExMono {

    public float initialDelay = 3;

    public TextMeshPro textMesh;
    public static MessageDisplay instance;
    public bool IsCoroutineRunning;

    private void Start()
    {
        instance = this;
    }

    public void DisplayTitle(string Title)
    {
        textMesh.text = Title;

        Vector3 temp = textMesh.transform.position;
        temp.y = -100;

        if (!IsCoroutineRunning)
        {
            StartCoroutine(DisplayAnimation());
        }
        else
        {
            IsCoroutineRunning = false;
            StartCoroutine(DisplayAnimation());
        }

        textMesh.transform.position = temp;
    }

    IEnumerator DisplayAnimation()
    {
        IsCoroutineRunning = true;

        Vector3 target = textMesh.transform.position;
        target.y = 0;

        while (IsCoroutineRunning && textMesh.transform.position.y != target.y)
        {
            textMesh.transform.position = Vector3.Lerp(textMesh.transform.position, target, 0.1f);
            if (Mathf.Abs(target.y - textMesh.transform.position.y) < 0.01f)
            {
                textMesh.transform.position = target;
            }

            yield return new WaitForFixedUpdate();
        }

        float timestamp2 = Time.time;
        while(IsCoroutineRunning && timestamp2 + initialDelay > Time.time)
        {
            yield return null;
        }

        target.y = 100;

        while (IsCoroutineRunning && textMesh.transform.position.y != target.y)
        {
            textMesh.transform.position = Vector3.Lerp(textMesh.transform.position, target, 0.1f);
            if (Mathf.Abs(target.y - textMesh.transform.position.y) < 0.01f)
            {
                textMesh.transform.position = target;
            }
            yield return new WaitForFixedUpdate();
        }

        IsCoroutineRunning = false;
    }
}
