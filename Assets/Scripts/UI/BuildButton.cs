using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _tower;

    [SerializeField] private float _price;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        TowerBuilder.Instance.Build(_tower, _price);
        AudioManager.Instance.Buy();
    }
}
