using UnityEngine;

public class State_Idle : NPCState
{
    [SerializeField] NPCStateMachine stateMachine;
    [SerializeField] NPCController controller;
    [SerializeField] CubeSpawner cubeSpawner;

    public override void EnterState()
    {
        //stop movement.
        controller.SetMovement(0f);
    }

    public override void Tick()
    {
        //Check for available blocks
        if(cubeSpawner.activeCubePool.Count > 0)
        {
            //Get Closest Cube.
            float closestDist = float.MaxValue;
            GameObject closestCube = null;
            foreach (var item in cubeSpawner.activeCubePool)
            {
                float thisDist = Vector3.Distance(controller.transform.position, item.transform.position);
                if (thisDist < closestDist)
                {
                    closestDist = thisDist;
                    closestCube = item;
                }
            }

            //change state - no longer idle.  Get to cube.
            Debug.Log("GET TO CUBE! - " + closestCube.name);
        }
    }

    

}
