using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] int projectileBuffer = 10;
    List<GameObject> projectileList;
    public static PoolManager poolManager; 

    private void Awake()
    {
        poolManager = this;
    }

    private void Start()
    {
        projectileList = new List<GameObject>();
        for (int i = 0; i < projectileBuffer; i++)
        {
            GameObject tempProjectile = Instantiate(projectile, this.transform);
            tempProjectile.SetActive(false);
            projectileList.Add(tempProjectile);
        }
    }

    public GameObject AccesList()
    {
        if(projectileList.Count == 0)
        {
            GameObject tempProjectile = Instantiate(projectile, this.transform);
            tempProjectile.SetActive(false);
            return tempProjectile;
        }
        GameObject projectileToReturn = projectileList[projectileList.Count - 1];
        projectileList.Remove(projectileToReturn);
        return projectileToReturn;
    }

    public void ReturnToPool(GameObject fProjetile)
    {
        fProjetile.SetActive(false);
        projectileList.Add(fProjetile);
    }
}
