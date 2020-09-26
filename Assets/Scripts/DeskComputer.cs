using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskComputer : InteractiveObject
{
    [SerializeField] InteractiveObject[] otherComponents = default;

    protected override void Execute()
    {
        SceneManager.LoadScene("CastSchedule");
    }

    protected override void OnMousePosChangeListener(Vector2 position)
    {
        bool wasHighlighted = isHighlighted;

        base.OnMousePosChangeListener(position);

        if (isHighlighted && !wasHighlighted) {
            HighlightOthers();
        }
        else if (wasHighlighted && !isHighlighted)
            DeHighlightOthers();
        }


    private void HighlightOthers()
    {
        for (int i = 0; i < otherComponents.Length; i++) {
            otherComponents[i].Highlight();
        }   
    }
    private void DeHighlightOthers()
    {
        for (int i = 0; i < otherComponents.Length; i++) {
            otherComponents[i].DeHighlight();
        }
    }
}


