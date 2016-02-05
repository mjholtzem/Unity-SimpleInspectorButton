using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections;

[CustomPropertyDrawer(typeof(SimpleInspectorButton))]
public class SimpleInspectorButtonDrawer : PropertyDrawer {

    Object target;
    string[] methodNames;
    int index = 0;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        target = property.serializedObject.targetObject;
        MethodInfo[] mInfos = target.GetType().GetMethods();
        methodNames = new string[mInfos.Length];
        for(int i = 0; i < mInfos.Length; i++)
        { 
            methodNames[i] = mInfos[i].Name;
        }
        EditorGUI.BeginChangeCheck();
        index = EditorGUI.Popup(
                new Rect(position.position.x, position.position.y, position.width/2, 20),
                index,
                methodNames);

        //string value = EditorGUI.TextField(new Rect(position.position, new Vector2(position.size.x / 2 - 2, position.size.y)), property.FindPropertyRelative("MethodName").stringValue);
        if (EditorGUI.EndChangeCheck())
        { 
            property.FindPropertyRelative("MethodName").stringValue = methodNames[index];
        }

        if (GUI.Button(new Rect(new Vector2(position.position.x + position.width/2 + 2,position.position.y), new Vector2(position.size.x/2, position.size.y)), property.FindPropertyRelative("ButtonText").stringValue))
        {
            MethodInfo mInfo = target.GetType().GetMethod(property.FindPropertyRelative("MethodName").stringValue);
            if(mInfo != null)
            {
                mInfo.Invoke(target, null);
            }
            else
            {
                Debug.LogError("Method with name " + property.FindPropertyRelative("MethodName").stringValue + 
                    " was not found. Chec for spelling errors and make sure the desired method is public");
            }
        }
    }
}
