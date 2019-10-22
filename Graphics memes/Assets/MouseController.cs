using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    public CursorLockMode wantedMode;

    public void SetCursorMode() {

        Cursor.lockState = wantedMode;

        Cursor.visible = (CursorLockMode.Locked != wantedMode);

    }

    void Start()
    {

        wantedMode = CursorLockMode.Locked;
        SetCursorMode();

    }

}
