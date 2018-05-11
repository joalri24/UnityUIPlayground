using UnityEngine;
using UnityEditor;

public class SecondExample : EditorWindow
{

    #region ----- Attributes -----
    Color color;
    string colorText;
    #endregion


    #region ----- Methods -----
    /// <summary>
    /// This method serves to open the existing window intead of creating a new one every time is called.
    /// The attribute makes that the method is called when the respective Menu Item is clicked.
    /// </summary>
    [MenuItem("Window/Second Example")]
    public static void ShowWindow()
    {
        GetWindow<SecondExample>("Colorize");
    }

    /// <summary>
    /// Window code
    /// </summary>
    void OnGUI()
    {
        GUILayout.Label("Color the selected objects!", EditorStyles.boldLabel);

        // Captures the color chosen in the color selector.
        color = EditorGUILayout.ColorField("Color", color);

        // This label displays the string representation of the selected color.
        GUILayout.Label(string.Format("Hex code: {0}", color.ToString()), EditorStyles.boldLabel);

        // If the button is pressed...
        if (GUILayout.Button("COLORIZE!"))
        {
            Colorize();
        }
    }

    /// <summary>
    /// Colorize all selected game objects.
    /// </summary>
    private void Colorize()
    {
        // Iterates over all selected game objects.
        foreach (var obj in Selection.gameObjects)
        {
            // Changes the material's color, but only if the object has a renderer. 
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
                renderer.sharedMaterial.color = color;
        }
    }
    #endregion
}
