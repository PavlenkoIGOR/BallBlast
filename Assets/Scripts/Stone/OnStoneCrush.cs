using UnityEngine;
using UnityEngine.Events;

public class OnStoneCrush : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.Play();
        Destroy(gameObject, 1.5f);
        //playSoundOnDestroy.AddListener(PlaySound);
    }
}
