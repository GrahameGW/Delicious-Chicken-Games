using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private Camera mainCamera;

    public UnityVector2Event OnMousePositionChange { get; private set; }
    public GameObject currentlyHighlighted;
    public PlayerController player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else {
            Destroy(Instance);
            Instance = this;
        }
        OnMousePositionChange = new UnityVector2Event();
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            var currentMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            OnMousePositionChange.Invoke(currentMousePos);
        }

    }
    private void OnDestroy()
    {
        OnMousePositionChange.RemoveAllListeners();
    }
}


