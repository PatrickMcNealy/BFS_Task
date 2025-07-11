using ExampleCompany.BoxGame.Box;
using ExampleCompany.BoxGame.Dropoff;
using UnityEngine;

namespace ExampleCompany.BoxGame.NPC.StateMachine
{
    /// <summary>
    /// This state holds a box and directs the NPC to a dropoff point.
    /// </summary>
    public class State_CarryCube : NPCState
    {
        [SerializeField] NPCStateMachine stateMachine;
        [SerializeField] State_Idle state_idle;
        [SerializeField] NPCController controller;
        [SerializeField] CubeSpawner cubeSpawner;


        [SerializeField] DropoffPoint targetDropoffRed;
        [SerializeField] DropoffPoint targetDropoffBlue;
        DropoffPoint target;
        Box.Box box;

        public void HoldBox(Box.Box newBox)
        {
            box = newBox;
        }

        public override void EnterState()
        {
            //Entering this state without a box can ONLY happen by error.  This is a safeguard check.
            if (box == null)
            {
                stateMachine.ChangeState(state_idle);
                return;
            }

            // Select the correct dropoff point, and direct the NPC there.
            if (box.color == Box.Box.BOXCOLOR.RED)
            {
                target = targetDropoffRed;
            }
            else
            {
                target = targetDropoffBlue;
            }
            controller.MoveTowardTarget(target.transform.position);
        }


        public override void Tick()
        {
            //If the dropoff point is close enough, drop off the box.  If not, verify heading and continue.
            if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
            {
                DropOffBox();
            }
            else
            {
                controller.VerifyHeading(target.transform.position);
            }
        }

        private void DropOffBox()
        {
            target.AddItem();
            cubeSpawner.DespawnBox(box);
            box = null;
            stateMachine.ChangeState(state_idle);
        }
    }
}