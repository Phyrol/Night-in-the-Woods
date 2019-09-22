using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNext : MonoBehaviour
{
	Scene CurrentScene = SceneManager.GetActiveScene();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider RigidBodyFPSController){
		
		SceneManager.LoadScene(CurrentScene.buildIndex + 1, LoadSceneMode.Single);
		
		}
}
