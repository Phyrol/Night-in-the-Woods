using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health = 100;
    private bool killed;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void damage(float _damage)
    {
        health -= _damage;
        if (health <= 0 && !killed)
        {
            Kill();
            anim.SetTrigger("Die");
            Destroy(gameObject, 5f);
        }
    }

    void Kill()
    {
        killed = true;

        if (gameObject.CompareTag("Zombie"))
        {
            gameObject.GetComponent<chase>().alive = false;
        }
        if (gameObject.CompareTag("Bat"))
        {
            gameObject.GetComponent<chaseFlying>().alive = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
