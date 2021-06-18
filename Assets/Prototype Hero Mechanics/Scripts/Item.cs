using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public float duration = 7;
    [SerializeField] protected Sprite itemIcon;

    abstract public void Use();

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        PrototypeHeroDemo hero = collision.transform.GetComponent<PrototypeHeroDemo>();
        if (hero != null && !hero.HasItem())
        {
            hero.TakeItem(this);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            foreach (var col in gameObject.GetComponents<BoxCollider2D>())
            {
                col.enabled = false;
            }

            yield return new WaitForSeconds(duration);

            Destroy(gameObject);
        }
    }
}
