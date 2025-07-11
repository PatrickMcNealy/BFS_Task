using Unity.VisualScripting;
using UnityEngine;

namespace ExampleCompany.BoxGame.GameLogic
{
    //This class is for high-level systems that must be kept track of by the Game Manager.  Important game-wide systems should extend this class.
    public abstract class LogicSystem : MonoBehaviour
    {
        public abstract void Init();
        public abstract void FixedTick();
    }
}