using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float Duration = 20;

    [SerializeField]
    private float _delay = 1;

    [SerializeField] private WaveSlot[] _waveSlots;

    // Start is called before the first frame update
    void Awake()
    {
        _waveSlots = GetComponentsInChildren<WaveSlot>();
    }

    public void SpawnEnemies()
    {
        StartCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
    {
        for (int i = 0; i < _waveSlots.Length; i++)
        {
            for (int j = 0; j < _waveSlots[i].Count; j++)
            {
                Instantiate(_waveSlots[i].Enemy, GameManager.Instance.EnemySpawn.position,
                    GameManager.Instance.EnemySpawn.rotation);

                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
