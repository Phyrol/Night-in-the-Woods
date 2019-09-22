using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseFlying : MonoBehaviour
{
    private Transform player;
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            Vector3 direction = player.position - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 1.6)
            {
                this.transform.Translate(0, 0, 0.04f);
                anim.SetBool("isFlying", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isFlying", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isFlying", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
