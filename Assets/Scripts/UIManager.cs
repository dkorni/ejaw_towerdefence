using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _buildMenu;

    [SerializeField]
    private GameObject _recrutButton;

    [SerializeField]
    private GameObject _sellButton;

    [SerializeField]
    private GameObject _buildMenuPrefab;

    [SerializeField]
    private Transform _canvas;

    [SerializeField]
    private TextMeshProUGUI _goldText;

    [SerializeField]
    private TextMeshProUGUI _healthText;

    [SerializeField]
    private TextMeshProUGUI _wavesText;

    [SerializeField]
    private GameObject _victoryPopup;

    [SerializeField]
    private GameObject _gameOverPopup;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<UIManager>();

            return _instance;
        }
    }

    private static UIManager _instance;

    public void ShowRecrutButton(GuardTower guardTower)
    {
        HideRecrutButton();
        _recrutButton.SetActive(true);
        _recrutButton.GetComponent<GuardButton>().GuardTower = guardTower;
    }

    public void ShowBuildMenu()
    {
        ClearAll();

        _buildMenu = Instantiate(_buildMenuPrefab, Input.mousePosition, Quaternion.identity, _canvas);
    }

    public void ShowSellButton(TowerBase tower)
    {
       ClearAll();

       _sellButton.GetComponent<SellButton>().Tower = tower;
       _sellButton.SetActive(true);
    }

    public void HideBuildMenu()
    {
       Destroy(_buildMenu);
    }

    public void HideRecrutButton()
    {
        _recrutButton.SetActive(false);
    }

    public void HideSellButton()
    {
        _sellButton.SetActive(false);
    }

    public void UpdateGoldText(float gold)
    {
        _goldText.text = gold.ToString();
    }

    public void UpdateHealthText(float health)
    {
        _healthText.text = health.ToString();
    }

    public void UpdateWavesText(int currentWave, int maxWaves)
    {
        _wavesText.text = $"{currentWave}/{maxWaves}";
    }

    public void ShowVictoryPopup()
    {
        _victoryPopup.SetActive(true);
    }

    public void ShowGameOverPopup()
    {
        _gameOverPopup.SetActive(true);
    }

    public void ClearAll()
    {
        if (_buildMenu != null)
            HideBuildMenu();

        if (_recrutButton != null)
            HideRecrutButton();

        if (_sellButton != null)
            HideSellButton();
    }
}
