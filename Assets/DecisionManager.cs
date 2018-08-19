using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionManager : MonoBehaviour {

    public static DecisionManager instance;

    public DecisionDescriptor[] decisionList;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        decisionList = this.gameObject.GetComponentsInChildren<DecisionDescriptor>();
    }

    DecisionDescriptor GetDecisionByID(int ID)
    {
        DecisionDescriptor result = null;

        for(int i = 0; i < decisionList.Length; i++)
        {
            if(decisionList[i].ID == ID)
            {
                result = decisionList[i];
                break;
            }
        }

        return result;
    }
}
