using UnityEngine;
using System.Collections;

[System.Serializable]
public class SimpleInspectorButton {

    public string MethodName;
    public string ButtonText;

    public SimpleInspectorButton(string methodName, string buttonText = "Execute")
    {
        MethodName = methodName;
        ButtonText = buttonText;
    }
}
