using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject _boomFx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        TowerBuilder.Instance.StartBuild(transform);
    }

    public void Boom()
    {
        // just for fun xD
        var go = Instantiate(_boomFx, transform.position, Quaternion.identity);
        Destroy(go, 5f);
    }
}
