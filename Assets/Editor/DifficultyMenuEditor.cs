using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(DifficultySelectMenu))]
public class DifficultyMenuEditor : Editor
{
    ReorderableList difficultiesList;
    //SerializedProperty m_MenuObjectProperty;
    //SerializedProperty m_DifficultyButtonsAncorProperty;
    //SerializedProperty m_DifficultyButtonPrefabProperty;
    //SerializedProperty m_DefaultBoardSizeXProperty;
    //SerializedProperty m_DefaultBoardSizeYProperty;
    //SerializedProperty _menuTypeProperty;
    //SerializedProperty _MenusControllerProperty;

    public void OnEnable()
    {
        difficultiesList = new ReorderableList(serializedObject, serializedObject.FindProperty("m_difficulties"), true, true, true, true);
        difficultiesList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = difficultiesList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, 50, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("difficultyName"),
                GUIContent.none
            );
            EditorGUI.LabelField(
                new Rect(rect.x + 51, rect.y, 15, EditorGUIUtility.singleLineHeight),
                "X:"
                );
            EditorGUI.PropertyField(
                new Rect(rect.x + 67
                , rect.y, 20, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("boardSizeX"),
                GUIContent.none
                );
            EditorGUI.LabelField(
                new Rect(rect.x + 88, rect.y, 15, EditorGUIUtility.singleLineHeight),
                "Y:"
                );
            EditorGUI.PropertyField(
                new Rect(rect.x + 110
                , rect.y, 20, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("boardSizeY"),
                GUIContent.none
                );
            EditorGUI.LabelField(
                new Rect(rect.x + 131, rect.y, 80, EditorGUIUtility.singleLineHeight),
                "Spawn Timer"
                );
            EditorGUI.PropertyField(
                new Rect(rect.x + 210
                , rect.y, 90, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("spawnTimer"),
                GUIContent.none
                );
        };
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        difficultiesList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
