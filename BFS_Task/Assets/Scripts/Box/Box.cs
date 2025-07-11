using UnityEngine;

namespace ExampleCompany.BoxGame.Box
{
    public class Box : MonoBehaviour
    {
        public enum BOXCOLOR
        {
            RED,
            BLUE
        }

        public BOXCOLOR color { get { return _color; } }
        [SerializeField] BOXCOLOR _color;

        [SerializeField] Rigidbody2D rb2d;
        [SerializeField] BoxCollider2D collider2d;

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