using UnityEngine;


namespace ExampleCompany.BoxGame.Dropoff
{
    public class DropoffPoint : MonoBehaviour
    {
        int items = 0;

        public void AddItem()
        {
            items++;
            this.transform.localScale = new Vector3(1f, items * 0.1f, 1f);
        }
    }
}