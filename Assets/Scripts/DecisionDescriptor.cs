using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDescriptor : MonoBehaviour {

    public int ID;
    public string Title;
    public string textNO;
    public GameObject noObject;
    public string textYES;
    public GameObject yesObject;

    public DecisionDescriptor noNext;
    public DecisionDescriptor yesNext;

    public void Load(DecisionDescriptor other)
    {
        ID = other.ID;
        Title = other.Title;
        textNO = other.textNO;
        noObject = other.noObject;
        textYES = other.textYES;
        yesObject = other.yesObject;

        noNext = other.noNext;
        yesNext = other.yesNext;
}
}
