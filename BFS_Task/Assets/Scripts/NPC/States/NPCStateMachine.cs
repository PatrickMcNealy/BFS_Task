using UnityEngine;

namespace ExampleCompany.BoxGame.NPC.StateMachine
{
    /// <summary>
    /// The statemachine for the NPC.  This holds onto a current State and makes it tick, and updates itself and the new state appropriately when the state is changed.
    /// If so desired, this statemachine can make states tick at a slower rate than the game plays, as the NPC and it's movement will run at full speed regardless of the state machine's "thinking".
    /// </summary>
    public class NPCStateMachine : MonoBehaviour
    {

        [SerializeField] State_Idle state_Idle;


        private NPCState currentState;

        private void Start()
        {
            ChangeState(state_Idle);
        }

        private void FixedUpdate()
        {
            currentState.Tick();
        }

        public void ChangeState(NPCState newstate)
        {
            currentState = newstate;
            newstate.EnterState();
        }

    }
}