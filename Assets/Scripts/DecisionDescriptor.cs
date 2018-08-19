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
}
