using UnityEngine;
using UnityEditor;

/// <summary>
/// An empty window with a background different from the default one.
/// </summary>
public class WindowBackground : EditorWindow
{
    #region  Attributes
    #endregion

    #region Methods
    #region Show Window
    [MenuItem("Window/Background")]
    public static void ShowWindow()
    {
        // Returns the first EditorWindow of type t which is currently on the screen.
        // If there is none, creates and shows new window and returns the instance of it.
        GetWindow(typeof(WindowBackground));
    }
    #endregion

    #region OnGUI
    /// <summary>
    /// Window code goes here.
    /// </summary>
    private void OnGUI()
    {

        if (Event.current.type == EventType.Repaint)
        {
            UnityEditor.Graphs.Styles.graphBackground.Draw(
                new Rect(0, 17, position.width, position.height - 17), false, false, false, false
            );

        }
    }
    #endregion

    #endregion


}
