using UnityEngine;

namespace ExampleCompany.BoxGame.NPC.StateMachine
{
    /// <summary>
    /// This state directs the NPC towards a box to pick up.
    /// </summary>
    public class State_GetCube : NPCState
    {
        Box.Box target = null;
        [SerializeField] NPCController controller = null;
        [SerializeField] NPCStateMachine stateMachine = null;
        [SerializeField] State_Idle state_Idle = null;
        [SerializeField] State_CarryCube state_carryCube = null;

        /// <summary>
        /// Set the target.  Must be called before this state can be entered.
        /// </summary>
        /// <param name="newTarget"></param>
        public void SetTarget(Box.Box newTarget)
        {
            target = newTarget;
        }

        public override void EnterState()
        {
            //Entering this state without a target can ONLY happen by error.  This is a safeguard check.
            if (target == null)
            {
                stateMachine.ChangeState(state_Idle);
                return;
            }

            controller.MoveTowardTarget(target.transform.position);
        }




        public override void Tick()
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) < 0.3f)
            {
                PickUpTarget();
            }
            else
            {
                //Only call MoveTowardTarget if NOT heading the correct direction.
                controller.VerifyHeading(target.transform.position);
            }
        }



        private void PickUpTarget()
        {
            target.HoldBox();
            target.transform.parent = controller.transform;
            target.transform.localPosition = Vector3.up * 1f;

            state_carryCube.HoldBox(target);
            target = null;
            stateMachine.ChangeState(state_carryCube);

        }
    }
}