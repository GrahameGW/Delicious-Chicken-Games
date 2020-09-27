using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InterviewSlotUIButton : MonoBehaviour
{
    public InterviewSlot interview = default;
    [SerializeField] Color selectedColor = default;
    [SerializeField] Color defaultColor = default;
    private Image image;
    private TextMeshProUGUI buttonText;
    public InterviewClipsList menu;

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
        menu.SetInterview(this);
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = defaultColor;
    }

}
