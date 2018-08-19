using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRealy : MonoBehaviour {

    public delegate void OnCollisionEnterEvent(Collision col);
    public delegate void OnCollisionExitEvent(Collision col);
}
