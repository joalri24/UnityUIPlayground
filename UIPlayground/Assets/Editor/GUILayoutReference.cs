using UnityEngine;
using UnityEditor;

public class GUILayoutReference : EditorWindow {

    #region ----------------------- Attributes -----------------------
    float sliderValue = 5f;

    string[] gridStrings = {"String 1", "String 2", "String 3", "String 4"};
    int selectedString = 1;
    #endregion ----------------------- -----------------------

    #region ----------------------- Methods -----------------------
    /// <summary>
    /// Open the window when the menu item is clicked.
    /// </summary>
    [MenuItem("Window/GUILayout Reference")]
    public static void ShowWindow()
    {
        GetWindow<GUILayoutReference>();
    }

    /// <summary>
    /// The Window code goes here.
    /// </summary>
    private void OnGUI()
    {
        // A box
        GUILayout.Box("Box");

        // A button
        GUILayout.Button("Button");

        // A button with box style
        bool clicked;
        clicked = GUILayout.Button("Button with box style", "Box");
        if (clicked)
            Debug.Log("\"Box\" clicked");

        // A Vertical area
        #region Vertical area
        GUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.Label("This ia a Vertical Area");
        GUILayout.Box(string.Format("Value: {0}", Mathf.Round(sliderValue)));
        sliderValue = GUILayout.HorizontalSlider(sliderValue, 0f, 10f);
        GUILayout.EndVertical();
        #endregion

        // A Selection Grid
        GUILayout.Label("Selection grid: ");
        selectedString = GUILayout.SelectionGrid(selectedString,gridStrings, 2);

        
        // An area with textArea style  
        #region TextArea style Area      
        GUILayout.BeginArea(new Rect(0, 205, 100, 50), EditorStyles.textArea);
        GUILayout.Label("This is an Area \nwith textArea style", EditorStyles.wordWrappedLabel);
        GUILayout.EndArea();
        #endregion

        // An area with helpbox style 
        #region Helpbox style Area      
        GUILayout.BeginArea(new Rect(105, 205, 100, 50), EditorStyles.helpBox);
        GUILayout.Label("This is an Area \nwith helpbox style", EditorStyles.wordWrappedLabel);
        GUILayout.EndArea();
        #endregion
    }

    #endregion ----------------------- -----------------------
}
