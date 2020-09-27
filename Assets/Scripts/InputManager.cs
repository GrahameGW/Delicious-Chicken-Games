using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private Camera mainCamera;

    public UnityVector2Event OnMousePositionChange { get; private set; }
    public InteractiveObject currentlyHighlighted;
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
        if (GlobalState.isInDialog) return; //will not check for move input during dialog sequences
        if (!EventSystem.current.IsPointerOverGameObject()) {
            Vector2 currentMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            OnMousePositionChange.Invoke(currentMousePos);

            if (Input.GetButtonDown("Fire1")) {
                if (currentlyHighlighted != null) {
                    currentlyHighlighted.Execute();
                }
                else if (player != null) {
                    player.StartTravel(currentMousePos);
                }
            }
        }
    }

    private void OnDestroy()
    {
        OnMousePositionChange.RemoveAllListeners();
    }
}


