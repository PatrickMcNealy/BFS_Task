using UnityEngine;

namespace ExampleCompany.BoxGame.NPC
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb2d = null;
        [SerializeField] Transform faceTf = null;

        float currentVelocity { get { return _currentVelocity; } }
        float _currentVelocity = 0f;

        [SerializeField] float maxspeed = 5f;

        private void FixedUpdate()
        {
            rb2d.linearVelocityX = _currentVelocity;
        }

        readonly Vector3 faceOffsetLeft = new Vector3(-0.2f, 0f, 0f);
        readonly Vector3 faceOffsetRight = new Vector3(0.2f, 0f, 0f);
        [SerializeField] float stopRange = 0.2f;

        /// <summary>
        /// Starts moving the character in the intended direction, or stops it.
        /// </summary>
        /// <param name="speed">Horizontal speed.  positive it right, negative is left, 0 is stop..</param>
        private void SetMovement(float speed)
        {
            _currentVelocity = speed;

            if (speed < 0)
            {
                faceTf.localPosition = faceOffsetLeft;
            }
            else if (speed > 0)
            {
                faceTf.localPosition = faceOffsetRight;
            }
            else
            {
                faceTf.localPosition = Vector3.zero;
            }
        }

        public void MoveLeft()
        {
            SetMovement(maxspeed * -1f);
        }
        public void MoveRight()
        {
            SetMovement(maxspeed);
        }
        public void StopMovement()
        {
            SetMovement(0f);
        }


        /// <summary>
        /// Sends the NPC in the direction of the target.
        /// </summary>
        public void MoveTowardTarget(Vector3 target)
        {
            if (target.x < this.transform.position.x - stopRange)
            {
                MoveLeft();
            }
            else if (target.x > this.transform.position.x + stopRange)
            {
                MoveRight();
            }
            else
            {
                StopMovement();
            }
        }

        /// <summary>
        /// ensures that the NPC hasn't overshot the target.  Will reorient itself if necessary.
        /// </summary>
        public void VerifyHeading(Vector3 target)
        {
            if (currentVelocity < 0f)
            {
                if (target.x >= this.transform.position.x)
                {
                    MoveTowardTarget(target);
                }
            }
            else if (currentVelocity > 0f)
            {
                if (target.x <= this.transform.position.x)
                {
                    MoveTowardTarget(target);
                }
            }
            else
            {
                if (target.x > this.transform.position.x + stopRange || target.x < this.transform.position.x - stopRange)
                {
                    MoveTowardTarget(target);
                }
            }
        }
    }
}