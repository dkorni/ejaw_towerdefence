using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuardButton : MonoBehaviour
{
    public GuardTower GuardTower
    {
        set
        {
            _guardTower = value;
            GetComponentInChildren<TextMeshProUGUI>().text = _guardTower.GuardPrice.ToString();
        }
    }

    private GuardTower _guardTower;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (_guardTower.Guards.Count < GuardTower.MaxGuard)
        {
            if (GameManager.Instance.Buy(_guardTower.GuardPrice))
            {
                _guardTower.CreateGuard();
                AudioManager.Instance.Drum();
            }
        }

        if (_guardTower.Guards.Count == GuardTower.MaxGuard)
        {
            gameObject.SetActive(false);
        }
    }
}
