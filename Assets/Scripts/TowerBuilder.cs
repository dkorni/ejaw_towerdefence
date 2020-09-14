using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    private Transform _slotForBuild;

    public static TowerBuilder Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<TowerBuilder>();

            return _instance;
        }
    }

    private static TowerBuilder _instance;

    public void StartBuild(Transform slotForBuild)
    {
        _slotForBuild = slotForBuild;
        UIManager.Instance.ShowBuildMenu();
    }

    public void Build(GameObject tower, float price)
    {
        if (GameManager.Instance.Buy(price))
        {
            Instantiate(tower, _slotForBuild.position, _slotForBuild.rotation, GameManager.Instance.Towers.transform);
            UIManager.Instance.HideBuildMenu();
        }

        // todo some audio clip when can't buy
    }
}
