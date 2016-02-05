# Unity-SimpleInspectorButton
A simple class + custom property drawer that allows you to easily call functions with a button from the inspector without needing to make a custom Editor.

## Example Usage
```C#
[SerializeField]
private SimpleInspectorButton testButton = new SimpleInspectorButton("TestMethod", "Do Test Method");
public void TestMethod()
{
    Debug.Log("Yay it works!!! :D");
}
```
