using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Transform faceTf;

    float currentVelocity = 0f;
    [SerializeField] float maxspeed;


    public bool debugInputs = false;
    private void Update()
    {
        if (debugInputs)
        {
            //DEBUG: simple inputs to test movement.
            if (Input.GetKeyDown(KeyCode.A))
            {
                SetMovement(maxspeed * -1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                SetMovement(maxspeed);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                SetMovement(0);
            }
        }
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocityX = currentVelocity;
    }


    readonly Vector3 faceOffsetLeft = new Vector3(-0.2f, 0f, 0f);
    readonly Vector3 faceOffsetRight = new Vector3(0.2f, 0f, 0f);
    /// <summary>
    /// Starts moving the character in the intended direction, or stops it.
    /// </summary>
    /// <param name="speed">Horizontal speed.  positive it right, negative is left, 0 is stop..</param>
    public void SetMovement(float speed)
    {
        currentVelocity = speed;

        if(speed < 0)
        {
            faceTf.localPosition = faceOffsetLeft;
        }
        else if(speed > 0)
        {
            faceTf.localPosition = faceOffsetRight;
        }
        else
        {
            faceTf.localPosition = Vector3.zero;
        }

    }
}
