using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClipsListItem : MonoBehaviour
{
    public string Name {
        get => name;
        set {
            name = value;
            buttonText.text = value;
        }
    }
    private new string name;

    private TextMeshProUGUI buttonText;
    [SerializeField] Color selectedColor = default;
    [SerializeField] Color defaultColor = default;
    private Image image;

    [HideInInspector]
    public ClipsList menu;
    public BroadcastClip clip;

    public void Awake()
    {
        buttonText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        image = GetComponent<Button>().image;
    }

    public void Select()
    {
        menu.Set(this);
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = defaultColor;
    }
}
