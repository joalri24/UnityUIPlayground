using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(HpAttribute))]
public class HpDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // First get the attribute since it contains the range for the slider
        HpAttribute range = (HpAttribute)attribute;

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var intRect = new Rect(position.x, position.y, 175, position.height);
        var colorRect = new Rect(position.x + 195, position.y, 35, position.height);

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            EditorGUI.IntSlider(intRect, property, range.min, range.max, GUIContent.none);

            float blue = (property.intValue - range.min) / (float)(range.max - range.min);
            EditorGUI.DrawRect(colorRect, new Color(0, 0.77f, 1-blue));
        }
        else
            EditorGUI.LabelField(position, label.text, "Use MyRange with float or int.");

        
    }
}

