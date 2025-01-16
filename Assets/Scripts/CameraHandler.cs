using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private InputAction movementInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomDamp = 5f;
    [SerializeField] private float minZoomDistance = 10f;
    [SerializeField] private float maxZoomDistance = 30f;
    [SerializeField] private CinemachineCamera cinemachineCamera;

    private float orthographicSize;
    private float targetOrthographicSize;

    private void Start()
    {
        orthographicSize = cinemachineCamera.Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

    private void OnEnable()
    {
        movementInput.Enable();
    }

    void Update()
    {
        Movement();
        ZoomCamera();
    }

    private void Movement()
    {
        Vector2 moveDir = movementInput.ReadValue<Vector2>().normalized;
        transform.position += new Vector3(moveDir.x, moveDir.y) * moveSpeed * Time.deltaTime;
    }

    private void ZoomCamera()
    {
        float scrollY = Mouse.current.scroll.ReadValue().y;
        float normalizedScrollY = Mathf.Clamp(scrollY, -1f, 1f);

        targetOrthographicSize += -normalizedScrollY * zoomSpeed;

        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minZoomDistance, maxZoomDistance);
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomDamp);
        cinemachineCamera.Lens.OrthographicSize = orthographicSize;
    }
}
