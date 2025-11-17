using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    
    private TouchControls _touchControls;

    private void Awake()
    {
       _touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }

    private void Start()
    {
        _touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        _touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("StartTouch " + ScreenToWorld(Camera.main, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()));
        if (OnStartTouch != null) OnStartTouch(ScreenToWorld(Camera.main, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
    
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("EndTouch " + ScreenToWorld(Camera.main, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()));
        if (OnEndTouch != null) OnEndTouch(ScreenToWorld(Camera.main, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.time);
    }

    private static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
    
    public Vector2 TouchPosition => _touchControls.Touch.TouchPosition.ReadValue<Vector2>();

    
}
