using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    public string targetTag;


    private void Update()
    {
        transform.Translate(new Vector3(speed, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            return;
        }
        PoolManager.poolManager.ReturnToPool(gameObject);
    }
}
