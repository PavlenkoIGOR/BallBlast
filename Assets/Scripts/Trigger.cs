using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent Enter;
    public UnityEvent Exit;
    public void OnTriggerEnter(Collider other)
    {
        Cart fpc = other.GetComponent<Cart>();
        if (fpc != null) 
        {
            Enter?.Invoke();
            Debug.Log("Trigger");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Cart fpc = other.GetComponent<Cart>();
        if (fpc != null)
        {
            Exit?.Invoke();
        }
    }
}
