using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDashImagePool : MonoBehaviour
{
    [SerializeField] private GameObject afterDashImagePrefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    private int growingStepSize = 10;

    public static AfterDashImagePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    private void GrowPool()
    {
        for (int i = 0; i < growingStepSize; i++)
        {
            var instanceToAdd = Instantiate(afterDashImagePrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }

    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            GrowPool();
        }

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);

        return instance;
    }
}
