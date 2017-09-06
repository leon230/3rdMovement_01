using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public InputController inputController;

	// Use this for initialization
	void Start () {
        inputController = GameManager.instance.inputController;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Horizontal: " + inputController.MouseInput.x);
        Debug.Log("Vertical: " + inputController.MouseInput.y);
    }
}
