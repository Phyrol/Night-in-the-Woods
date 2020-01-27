using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotator : MonoBehaviour
{
    public float spinSpeed = 2f;
    private float counter;

    private void Start()
    {
        counter = 2f;
        spinSpeed = Random.Range(1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0));
        if(Time.time >= counter)
        {
            spinSpeed = Random.Range(1f, 4f);
            counter = Time.time + 2f;
        }
    }
}
