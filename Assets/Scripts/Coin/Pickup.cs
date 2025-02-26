using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log($"asdasdasd{collision.transform.name}");
    //    if (collision.transform.GetComponent<Cart>() != null)
    //    {
    //        Debug.Log("Trigger");
    //        Destroy(this.gameObject);
    //    }
    //}

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"asdasdasd{collision.transform.root.GetComponent<Cart>()}");
        if (collision.transform.root.GetComponent<Cart>() != null)
        {
            //Debug.Log("Trigger");
            Destroy(this.gameObject);
        }
    }
}
