using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {
    Player player;
    SceneLoader sceneLoader;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
        sceneLoader = FindObjectOfType<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player==null)
        {
            sceneLoader.GameOver();
        }
	}
}
