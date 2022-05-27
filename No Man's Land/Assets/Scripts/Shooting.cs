using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 40;
    public float power = 1500f;
    public bool canShoot;
    public float delayInSeconds;
    public static ObjectPool<GameObject> _pool;
    [SerializeField] private bool _usePool;


    private void Start()
    {
        _pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(bulletPrefab);
        }, projectile =>
        {
            projectile.gameObject.SetActive(true);
        }, projectile =>
        {
            projectile.gameObject.SetActive(false);
        }, projectile =>
        {
            Destroy(projectile.gameObject);
        }, false, 10, 20);
        canShoot = true;
        delayInSeconds = 0.5f;
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (canShoot == true) {
                AudioManager.instance.Play("Shoot");
                var bullet = _usePool ? _pool.Get() : Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                // these two next line are for the object pooling 
                bullet.transform.position = spawnPoint.position;
                bullet.transform.rotation = spawnPoint.rotation; 
                bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
             
                canShoot = false;
                StartCoroutine(ShootDelay());
            }
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

}

