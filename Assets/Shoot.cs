using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform shootpoint;
    [SerializeField] PoolManager poolManager;
    [SerializeField] float projectileSpeed;

    private GameObject projectile;

    private void Start()
    {
        poolManager = PoolManager.poolManager;
    }

    public void Fire()
    {
        projectile = poolManager.AccesList();
        Debug.Log(projectile.name);
        projectile.tag = gameObject.tag;
        projectile.GetComponent<Projectile>().targetTag = gameObject.tag;
        projectile.transform.position = shootpoint.position;
        projectile.transform.rotation = shootpoint.rotation;
        projectile.SetActive(true);
    }
}
