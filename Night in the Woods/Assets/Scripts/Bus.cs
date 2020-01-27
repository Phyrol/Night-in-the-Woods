using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public GameObject moveTarget;
    public GameObject wallToRemove;
    public GameObject busCam;
    public GameObject canvas;
    public GameObject endMusic;
    public GameObject credits;
    private Vector3 target;
    private float speed = 5f;
    private bool canMove = false;
    private float waitToMove = 1.5f;
    private float timer = 0f;

    private void Start()
    {
        target = new Vector3(moveTarget.transform.position.x - 200, moveTarget.transform.position.y, moveTarget.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            if (timer > waitToMove)
            {
                moveTarget.transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
            busCam.SetActive(true);
            endMusic.SetActive(true);
            credits.SetActive(true);
            Destroy(canvas);
            Destroy(wallToRemove);

            canMove = true;
        }
    }
}
