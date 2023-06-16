using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] Shoot shootScript;
    [SerializeField] float ShootFrequency = 0.1f;
    bool canShoot = true;

    private void Start()
    {
        shootScript = GetComponent<Shoot>();
    }

    void Update()
    {
        transform.Translate(new Vector3(speed, 0) * Time.deltaTime);
        if(canShoot == true)
        {
            StartCoroutine(ShootingCoroutine());
        }
    }

    IEnumerator ShootingCoroutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(ShootFrequency);
        shootScript.Fire();
        canShoot = true;
    }
}
