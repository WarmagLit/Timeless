using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBarrier : MonoBehaviour
{
    [SerializeField] Transform bombBarrier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bombBarrier.gameObject.SetActive(true);
    }
}
