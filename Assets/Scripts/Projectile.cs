using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float waitTime = 0.5f;
    [SerializeField] float damage = 10;
    private bool collisionIgnore = true;
    public string targetTag;


    private void Update()
    {
        transform.Translate(new Vector3(speed, 0) * Time.deltaTime);
    }

    private void OnEnable()
    {
        collisionIgnore = true;
        StartCoroutine(ColisionIgnoreTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && collisionIgnore == true)
        {
            return;
        }
        if (collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().Damage(damage);
        }

        PoolManager.poolManager.ReturnToPool(gameObject);
    }

    IEnumerator ColisionIgnoreTimer()
    {
        yield return new WaitForSeconds(waitTime);
        collisionIgnore = false;
    }
}
