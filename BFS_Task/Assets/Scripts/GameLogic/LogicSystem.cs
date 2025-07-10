using Unity.VisualScripting;
using UnityEngine;

public abstract class LogicSystem : MonoBehaviour
{
    public abstract void Init();
    public abstract void FixedTick();
}
