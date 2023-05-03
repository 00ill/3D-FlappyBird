using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tubes;
    private ObjectPool objectPool;
    private float randomNum;

    public void SetRandomPosition()
    {
        randomNum = Random.Range(9f, 20f);
        objectPool.GetObject().transform.position = new Vector3(transform.position.x, randomNum, transform.position.z);
        //transform.position = new Vector3(transform.position.x, randomNum, transform.position.z);
        //Instantiate(tubes, transform);
    }

    private void Start()
    {
        SetRandomPosition();
    }
}
