using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    //If you want to hide crosshair when it crosses the palyer create culling mask in main camera and change order of rendering



    [SerializeField] Texture2D image;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;

    float lookHeight;

    public void LookHeight(float value)
    {
        lookHeight += value;

        if (lookHeight > maxAngle || lookHeight < minAngle)
        {
            lookHeight -= value;
        }
    }

    private void OnGUI()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
    }

    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
