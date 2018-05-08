using UnityEngine;

/// <summary>
/// Hp range that goes from 1 to the maxium specified.
/// </summary>
public class HpAttribute : PropertyAttribute
{

    public readonly int min;
    public readonly int max;

    /// <summary>
    /// Used to draw a convenient UI in the editor.
    /// </summary>
    /// <param name="maxP">The maximun hp value in the game. </param>
    public HpAttribute(int maxP)
    {
        min = 1;
        max = (maxP < 1)?1:maxP; // maximum must be greater or equals to 1.
    }
}
