using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    public TowerBase Tower
    {
        set
        {
            _tower = value;
            GetComponentInChildren<TextMeshProUGUI>().text = (_tower.Price/2).ToString();
        }
    }

    private TowerBase _tower;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        GameManager.Instance.AddGold(_tower.Price/2);
        AudioManager.Instance.AddGold();
        _tower.Destroy();
        UIManager.Instance.ClearAll();
    }
}
