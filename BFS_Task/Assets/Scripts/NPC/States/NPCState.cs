using UnityEngine;

namespace ExampleCompany.BoxGame.NPC.StateMachine
{
    /// <summary>
    /// The base State class for the StateMachine.
    /// </summary>
    public abstract class NPCState : MonoBehaviour
    {
        /// <summary>
        /// The State Machine should call this when switching to a state.  This method should be used to reset the state, so the same state object can be used again without generating a new one.
        /// </summary>
        abstract public void EnterState();

        /// <summary>
        /// This is essentially the state's "fixedupdate" method.  But handled by the statemanager, to make sure everything happens in a correct order.
        /// </summary>
        abstract public void Tick();
    }
}