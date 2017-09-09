using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 damping;
        public Vector2 sensitivity;
    }

    [SerializeField] float speed;
    [SerializeField] MouseInput mouseControl;

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
    Vector2 mouseInput;

	// Use this for initialization
	void Awake () {
        playerInput = GameManager.instance.inputController;
        GameManager.instance.localPlayer = this;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        moveController.Move(direction);

        //mouseInput.x = playerInput.MouseInput.x;
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / mouseControl.damping.x);

        transform.Rotate(Vector3.up * mouseInput.x * mouseControl.sensitivity.x);

    }
}
