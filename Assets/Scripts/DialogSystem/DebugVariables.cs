using TMPro;
using UnityEngine;

public class DebugVariables : MonoBehaviour
{
    [SerializeField] private GlobalState globalState = default;
    [SerializeField] private TMP_Text debugTextBox = default;

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
