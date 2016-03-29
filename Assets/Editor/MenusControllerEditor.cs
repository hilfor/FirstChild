using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(MenusController))]
public class MenusControllerEditor : Editor {

    ReorderableList reordableList;
    SerializedProperty serializedProperty; 
    private void OnEnable()
    {
        serializedProperty = serializedObject.FindProperty("_defaultMenu");
        reordableList = new ReorderableList(serializedObject, serializedObject.FindProperty("_Menus"), true, true, true, true);
        reordableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            var element = reordableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width-30, EditorGUIUtility.singleLineHeight),element,GUIContent.none);
            //EditorGUI.PropertyField(new Rect(rect.x + rect.width - 30, rect.y, 30, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("_menuType"), GUIContent.none);
            //EditorGUI.PropertyField(
            //    new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
            //    element.FindPropertyRelative("_menuType"), GUIContent.none);


        };

    }

    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedProperty);
        reordableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
        //base.OnInspectorGUI();

    }
}
