using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject Key;

    // Update is called once per frame
    void Update()
    {
        if(!Key.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
