using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class EventTrigger : MonoBehaviour
{
    public UnityEvent onTrigger;

    private void Awake()
    {
        if (onTrigger == null)
        {
            onTrigger = new UnityEvent();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PrototypeHeroDemo hero = collision.transform.GetComponent<PrototypeHeroDemo>();
        if (hero != null)
        {
            onTrigger.Invoke();
        }
    }
}
