using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager {

    #region Singleton
    private GameObject gameObject;

    private static GameManager mInstance;
    public static GameManager instance
    {
        get
        {
            if(mInstance == null)
            {
                mInstance = new GameManager();
                mInstance.gameObject = new GameObject("_gameManager");
                mInstance.gameObject.AddComponent<InputController>();
            }
            else
            {
                Debug.Log("GameManager already defined");
            }
            
            return mInstance;
        }

    }
    #endregion

    private InputController mInputController;
    public InputController inputController
    {
        get
        {
            if(mInputController == null)
            {
                mInputController = gameObject.GetComponent<InputController>();              
            }
            return mInputController;
        }
    }
}
