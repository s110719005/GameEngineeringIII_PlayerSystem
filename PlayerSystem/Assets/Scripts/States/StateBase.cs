using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    virtual public void OnEnter() {}
    virtual public void OnUpdate() {}
    virtual public void OnExit() {}
}
