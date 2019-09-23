using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Gun Settings")]
    public float damage = 10f;
    public float range = 100f;

    [Header("Bullet Impact Physics")]
    public float impactForce = 30f;

    public Camera playerCam;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    private float bulletSpeed = 2000f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            //spawn particle effect at raycast hit point. Angle it to perpendicular vector
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            if(hit.collider.tag.Equals("Bat"))
            {
                hit.transform.SendMessage("damage", 50f);
            }
            if (hit.collider.tag.Equals("Zombie"))
            {
                hit.transform.SendMessage("damage", 34f);
            }

            //destroy clone after 1 second
            Destroy(impactGO, 1f);
        }
    }
}
