using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNext : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag.Equals("Player"))
        {
            if (SceneManager.GetActiveScene().name.Equals("Level01"))
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
		
	}
}
