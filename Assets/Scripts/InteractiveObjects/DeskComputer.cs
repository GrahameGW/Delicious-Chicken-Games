using UnityEngine.SceneManagement;

public class DeskComputer : InteractiveObject
{
    public override void Execute()
    {
        SceneManager.LoadScene("SelectBroadcast");
    }
}


