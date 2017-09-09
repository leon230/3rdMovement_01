using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

    [System.Serializable]
    public class MouseImput
    {
        public Vector2 damping;
        public Vector2 sensitivity;
    }

    [SerializeField] float speed;
    [SerializeField] MouseImput mouseControl;

    private MoveController mMoveController;
    public MoveController moveController
    {
        get
        {
            if (mMoveController == null)
            {
                mMoveController = GetComponent<MoveController>();
            }
            return mMoveController;
        }
    }


    InputController playerInput;

	// Use this for initialization
	void Awake () {
        playerInput = GameManager.instance.inputController;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        moveController.Move(direction);
    }
}
