using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Keys : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private Text _textKeys;

    [SerializeField] private UnityEvent _onKeyPickup;

    public void Start()
    {

    }
    public void ChangeKeyUI()
    {
        if (_bag != null)
        {
            Debug.Log(_bag.GetAmount().ToString());
            _textKeys.text = string.Format(_bag.GetAmount().ToString() + "/3");
        }
    }
}
