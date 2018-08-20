using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageDisplay : ExMono {

    public float initialDelay = 3;

    public TextMeshPro textMesh;
    public TextMeshPro noText;
    public TextMeshPro yesText;
    public static MessageDisplay instance;
    public bool IsCoroutineRunning;

    private void Start()
    {
        var copyT = this.gameObject.AddComponent<CopyPosition>();

        copyT.target = Camera.main.transform;
    }

    public void DisplayTitle(string Title, string no = "", string yes = "")
    {
        textMesh.text = Title;
        noText.text = no;
        yesText.text = yes;

        Vector3 temp = textMesh.transform.localPosition;
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
    }

    IEnumerator DisplayAnimation()
    {
        IsCoroutineRunning = true;

        Vector3 target = textMesh.transform.localPosition;
        target.y = -40;

        while (IsCoroutineRunning && textMesh.transform.localPosition.y != target.y)
        {
            textMesh.transform.localPosition = Vector3.Lerp(textMesh.transform.localPosition, target, 0.1f);
            if (Mathf.Abs(target.y - textMesh.transform.localPosition.y) < 0.01f)
            {
                textMesh.transform.localPosition = target;
            }

            yield return new WaitForFixedUpdate();
        }

        float timestamp2 = Time.time;
        while(IsCoroutineRunning && timestamp2 + initialDelay > Time.time)
        {
            yield return null;
        }

        target.y = 100;

        while (IsCoroutineRunning && textMesh.transform.localPosition.y != target.y)
        {
            textMesh.transform.localPosition = Vector3.Lerp(textMesh.transform.localPosition, target, 0.1f);
            if (Mathf.Abs(target.y - textMesh.transform.localPosition.y) < 0.01f)
            {
                textMesh.transform.localPosition = target;
            }
            yield return new WaitForFixedUpdate();
        }

        IsCoroutineRunning = false;
    }
}
