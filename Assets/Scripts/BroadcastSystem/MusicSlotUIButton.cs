using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MusicSlotUIButton : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    private Image image;
    public MusicClipsList menu;
    public MusicSlot music;

    [SerializeField] Color selectedColor = default;
    [SerializeField] Color defaultColor = default;

    public string Name {
        get => name;
        set {
            name = value;
            buttonText.text = value;
        }
    }
    private new string name;

    public void Awake()
    {
        buttonText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        image = GetComponent<Button>().image;
    }

    public void Select()
    {
        menu.SetMusic(this);
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = defaultColor;
    }
}
