using ExampleCompany.BoxGame.Box;
using UnityEngine;

namespace ExampleCompany.BoxGame.NPC.StateMachine
{
    /// <summary>
    /// This is the initial state that is kept when there are no boxes to interact with.  Changes state when a new box is noticed.
    /// </summary>
    public class State_Idle : NPCState
    {
        [SerializeField] NPCStateMachine stateMachine = null;
        [SerializeField] NPCController controller = null;
        [SerializeField] CubeSpawner cubeSpawner = null;
        [SerializeField] State_GetCube state_getCube = null;

        public override void EnterState()
        {
            //stop movement.
            controller.StopMovement();
        }

        public override void Tick()
        {
            //Check if there are available blocks
            if (cubeSpawner.activeBoxPool.Count > 0)
            {
                //Get Closest Cube.
                float closestDist = float.MaxValue;
                Box.Box closestCube = null;
                foreach (var item in cubeSpawner.activeBoxPool)
                {
                    float thisDist = Vector3.Distance(controller.transform.position, item.transform.position);
                    if (thisDist < closestDist)
                    {
                        closestDist = thisDist;
                        closestCube = item;
                    }
                }

                //change state - no longer idle.  Get to cube.
                state_getCube.SetTarget(closestCube);
                stateMachine.ChangeState(state_getCube);
            }
        }
    }
}