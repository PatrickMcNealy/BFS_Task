using UnityEngine;

public class NPCStateMachine : MonoBehaviour
{

    [SerializeField] State_Idle state_Idle;


    private NPCState currentState;

    private void Start()
    {
        state_Idle.EnterState();
        currentState = state_Idle;
        
    }

    private void FixedUpdate()
    {
        currentState.Tick();
    }

}
