/* Copyright (c) Alex Meuer
 * http://github.com/alexmeuer
 */

using JetBrains.Annotations;
using UnityEngine;
using UnityEditor;

namespace Assets.Editor.Scripts
{
	/*
	 * @class WaveDrawer
	 * @brief What does this class do?
	 */
	[CustomPropertyDrawer(typeof(Assets.Scripts.Generic.Wave))]
	public class PairListPropertyDrawer : PropertyDrawer {

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.
			EditorGUI.BeginProperty(position, label, property);

			// Draw label
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			// Don't make child fields be indented
			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			// Calculate rects
			Rect amountRect = new Rect(position.x, position.y, 30, position.height);
			Rect unitRect = new Rect(position.x + 35, position.y, 100, position.height);
			//Rect nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

			// Draw fields - passs GUIContent.none to each so they are drawn without labels
			EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("delay"), GUIContent.none);
			EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("delay"), GUIContent.none, true);
			//EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

			// Set indent back to what it was
			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
}
