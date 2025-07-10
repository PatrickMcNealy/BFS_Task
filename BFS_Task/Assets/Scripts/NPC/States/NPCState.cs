using UnityEngine;

public abstract class NPCState : MonoBehaviour
{
    abstract public void EnterState();
    abstract public void Tick();
}
