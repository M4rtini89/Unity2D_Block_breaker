using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

    [SerializeField][Range(0.01f, 10)] float gameSpeed = 1f;
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}
}
