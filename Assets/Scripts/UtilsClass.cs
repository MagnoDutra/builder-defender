using UnityEngine;
using UnityEngine.InputSystem;

public static class UtilsClass
{
    public static Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePosInPx = Mouse.current.position.ReadValue();
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosInPx);
        mousePosWorld.z = 0;

        return mousePosWorld;
    }
}
