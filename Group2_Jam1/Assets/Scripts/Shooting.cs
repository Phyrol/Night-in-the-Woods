using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Gun Settings")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    [Header("Bullet Impact Physics")]
    public float impactForce = 30f;

    public Camera playerCam;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            FindObjectOfType<AudioManager>().Play("Gun Shot");
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            //spawn particle effect at raycast hit point. Angle it to perpendicular vector
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            //destroy clone after 1 second
            Destroy(impactGO, 1f);
        }
    }
}
