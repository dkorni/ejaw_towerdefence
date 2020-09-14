using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSlot : MonoBehaviour
{
    public GameObject Enemy;
    
    public int Count;

    private void Start()
    {
        // add to TotalCount slot count to be able finish game with victory
        GameManager.Instance.TotalEnemyCount += Count;
    }
}
