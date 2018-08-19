using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ExMono {

    public class DecisionPair
    {
        public enum DecisionPairState { NONE, NO, YES }

        int ID;
        DecisionPairState state;

        public DecisionPair(int ID)
        {
            this.ID = ID;
        }
    }

    private static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }


}
