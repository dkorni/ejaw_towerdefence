using System.Collections;
using UnityEngine;

public class WaveProcessor : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;

    public static WaveProcessor Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<WaveProcessor>();

            return _instance;
        }
    }

    public int MaxWaves
    {
        get
        {
            return _waves.Length;
        }
    }

    public int CurrentWave
    {
        get { return _currentWave; }
    }

    private static WaveProcessor _instance;

    private int _currentWave = 1;

    private Coroutine _coroutine;

    public void StopProcess()
    {
        StopCoroutine(_coroutine);
    }

    // Start is called before the first frame update
    void Start()
    {
        _waves = GetComponentsInChildren<Wave>();
        UIManager.Instance.UpdateWavesText(_currentWave, MaxWaves);
        _coroutine = StartCoroutine(StartProcessWaves());
    }

    private IEnumerator StartProcessWaves()
    {
        foreach (var wave in _waves)
        {
            wave.SpawnEnemies();

            // before start next wave, wait until current wave duration expired
            yield return new WaitForSeconds(wave.Duration);

            _currentWave++;

            UIManager.Instance.UpdateWavesText(_currentWave, MaxWaves);
        }
    }
}
