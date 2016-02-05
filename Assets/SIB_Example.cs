using UnityEngine;
using System.Collections;

public class SIB_Example : MonoBehaviour {

    [SerializeField]
    private SimpleInspectorButton testButton = new SimpleInspectorButton("TestMethod", "Do Test Method");
	public void TestMethod()
    {
        Debug.Log("Yay it works!!! :D");
    }
}
