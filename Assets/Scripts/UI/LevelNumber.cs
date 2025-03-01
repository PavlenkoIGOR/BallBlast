using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text textNumLevel;
    [SerializeField] private StoneSpawner spawner;
    [HideInInspector] public UnityEvent onNextLevelpressed;

    private void Awake()
    {
        textNumLevel.text = "Количество камней на старте: " + spawner.amount.ToString();
        onNextLevelpressed.AddListener(ChangeStartStonesText);
    }

    private void ChangeStartStonesText()
    {
        textNumLevel.text = "Количество камней на старте: " + spawner.amount.ToString();
        //Debug.Log("LevelNumber");
    }


}
