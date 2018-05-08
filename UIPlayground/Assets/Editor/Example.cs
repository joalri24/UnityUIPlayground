using UnityEngine;
using UnityEditor;

public class Example : EditorWindow
{

    // --------------------------------------------
    // Attributes
    // --------------------------------------------

    string myString = "Hello world";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    // --------------------------------------------
    // Methods
    // --------------------------------------------


    [MenuItem("Window/Example Window")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Example));
    }
    
    /// <summary>
    /// The window code goes here.
    /// </summary>
    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toogle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3f,3f);
        EditorGUILayout.EndToggleGroup();
    }

}
