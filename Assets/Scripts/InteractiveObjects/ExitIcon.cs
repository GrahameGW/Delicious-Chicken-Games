using UnityEngine.SceneManagement;

public class ExitIcon : InteractiveObject
{
    public override void Execute()
    {
        SceneManager.LoadScene("DeskCloseup");
    }
}
