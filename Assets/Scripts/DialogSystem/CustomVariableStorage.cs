using UnityEngine;
using Yarn;

/// <summary>
/// This script will get and set values in GlobalState
/// </summary>
public class CustomVariableStorage : Yarn.Unity.VariableStorageBehaviour
{
    [SerializeField]
    private GlobalState globalState; //TO DO: create singleton instance of GlobalState

    private void Start()
    {
        globalState = ScriptableObject.CreateInstance<GlobalState>();
    }

    public override Value GetValue(string variableName)
    {
        return (Value)typeof(GlobalState).GetField(variableName).GetValue(globalState);
    }

    public override void ResetToDefaults()
    {
        /*
        for (int i = 0; i < globalState.GetType().GetProperties().Length; i++) //for each property in global variables, set to default
        {
            globalState.GetType().GetProperties()[i].SetValue(globalState, null, null);
        }*/
    }

    public override void SetValue(string variableName, Value value)
    {
        //globalState = ScriptableObject.CreateInstance("GlobalState") as GlobalState;
        globalState.GetType().GetField(variableName).SetValue(globalState,value); 
    }

}
