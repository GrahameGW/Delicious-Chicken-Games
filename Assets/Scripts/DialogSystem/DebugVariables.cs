using TMPro;
using UnityEngine;

public class DebugVariables : MonoBehaviour
{
    [SerializeField] private GlobalState globalState;
    [SerializeField] private TMP_Text debugTextBox;

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        debugTextBox.text = $"Money: {globalState.money}\n" +
            $"Community approval: {globalState.communityApproval}\n" +
            $"" +
            $"" +
            $"" +
            $"" +
            $"" +
            $"" +
            $"" +
            $"";
    }
}
