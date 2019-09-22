using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void damage(float _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("DJKLFSJFKL");
        }
    }
}
