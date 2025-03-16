using UnityEngine;
using UnityEngine.UI;

public class StartNextLevel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private LevelState levelState;
    [SerializeField] private Button nextLvlBttn;
    [SerializeField] private LevelNumber levelNumber;
    private void Awake()
    {
        nextLvlBttn.onClick.AddListener(StartNextLevelPressed);
        levelState.Passed.AddListener(ShowNextLevelPanel);
    }
    void ShowNextLevelPanel()
    {
        panel.SetActive(true);
        Debug.Log("ShowNextLevelPanel");
    }
    void StartNextLevelPressed()
    {
        int x = levelState.Spawner.amount++;
        Debug.Log("startNextLevel");
        
        panel.SetActive(false);
        levelState.checkPassed = false;
        levelState.Spawner.AmountSpawned = 0;
        levelNumber.onNextLevelpressed.Invoke();
        levelState.Spawner.enabled = true;

        PolygonCollider2D cartRB = levelState.Cart.cartBody.GetComponent<PolygonCollider2D>();
        cartRB.enabled = true;
        CartControl cc = levelState.Cart.GetComponent<CartControl>();
        cc.enabled = true;

        Debug.Log($"stones amount {levelState.Spawner.amount}");
    }
}
