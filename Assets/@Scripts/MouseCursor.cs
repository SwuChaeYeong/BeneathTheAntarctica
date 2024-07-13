using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorImg;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorImg, new Vector2(cursorImg.width/2, cursorImg.height/2), CursorMode.ForceSoftware);
    }

    private void Update()
    {
        
    }
}
