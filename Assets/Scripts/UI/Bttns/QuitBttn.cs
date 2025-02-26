using UnityEngine;
using UnityEngine.UI;

public class QuitBttn : MonoBehaviour
{
    [SerializeField] private Button quitBttn;

    private void Awake()
    {
        quitBttn.onClick.AddListener(() => { Debug.Log("quit"); Application.Quit(); });
    }
}
