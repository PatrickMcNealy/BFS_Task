using UnityEngine;

namespace ExampleCompany.BoxGame.Box
{
    public class Box : MonoBehaviour
    {
        public enum BOXCOLOR
        {
            RED = 0,
            BLUE = 1
        }

        public BOXCOLOR color { get { return _color; } }
        [SerializeField] BOXCOLOR _color = BOXCOLOR.RED;

        [SerializeField] Rigidbody2D rb2d = null;
        [SerializeField] BoxCollider2D collider2d = null;

        public void ResetBox()
        {
            rb2d.simulated = true;
            collider2d.enabled = true;
        }

        public void HoldBox()
        {
            rb2d.simulated = false;
            collider2d.enabled = false;
        }

    }
}