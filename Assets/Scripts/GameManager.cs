using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDamageSettable
{
    public float Health
    {
        get { return _health; }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }

    public Transform EnemySpawn;

    public Waypoint FirstWaypoint;

    public Transform Castle;

    public GameObject Towers;

    public int TotalEnemyCount;

    public int DiedEnemyCount
    {
        set
        {
            _diedEnemyCount = value;

            if (_diedEnemyCount == TotalEnemyCount)
            {
                // so victory
                UIManager.Instance.ShowVictoryPopup();
            }
        }

        get { return _diedEnemyCount; }
    }

    private static GameManager _instance;

    [SerializeField]
    private float _gold;

    [SerializeField]
    private float _health = 1000;

    [SerializeField] private GameObject _slots;

    private bool _isDied;

    private int _diedEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdateGoldText(_gold);
        UIManager.Instance.UpdateHealthText(Health);
    }

    public void AddGold(float gold)
    {
        _gold += gold;
        UIManager.Instance.UpdateGoldText(_gold);
    }

    public bool Buy(float price)
    {
        var canBuy = _gold > price;

        if (canBuy)
        {
            _gold -= price;
            UIManager.Instance.UpdateGoldText(_gold);
        }

        return canBuy;
    }

    public void SetDamage(float damage, object who)
    {
        if(_isDied)
            return;

        _health -= damage;

        if (_health <= 0)
        {
            _isDied = true;
            UIManager.Instance.ShowGameOverPopup();
            GameOver();
        }

        UIManager.Instance.UpdateHealthText(Health);
    }

    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private void GameOver()
    {
        // make boom :D
        foreach (var slot in _slots.GetComponentsInChildren<Slot>())
        {
            slot.Boom();
        }

        Destroy(Towers);
        Destroy(_slots);
        WaveProcessor.Instance.StopProcess();
    }
}
