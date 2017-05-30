using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
[CreateAssetMenu(menuName = "Calculator",fileName = "Calculator",order = 0)]
public class Calculator : ScriptableObject
{
#if UNITY_EDITOR
    [CustomEditor(typeof(Calculator))]
    public class CalculatorEditor : Editor
    {
        private int a = 0;
        private int b = 0;

        private int _firstToOperate = 0;
        private int _secondToOperate = 0;
        private bool _operating = false;
        private int _result = 0;
        List<bool> button = new List<bool>();
        
        public override void OnInspectorGUI()
        {
            
            
            button.Clear();
            for (int i = 1; i < 10; i++)
            {
                button.Add(GUILayout.Button(i.ToString(),GUILayout.Width(40)));
            }
                base.OnInspectorGUI();
            for (int i = 0; i < button.Count; i++)
            {
                if (button[i] && a == 0)
                {
                    a = i + 1;
                }
                else if (button[i])
                {
                    b = i + 1;
                    if (_operating)
                        _secondToOperate = b;
                }
            }
            if (GUILayout.Button("Clear"))
            {
                a = 0;
                b = 0;
                _result = 0;
                _firstToOperate = 0;
                _secondToOperate = 0;
            }
            if (GUILayout.Button("+"))
            {
                _firstToOperate = a;
                _operating = true;
            }
            if (GUILayout.Button("=") && _firstToOperate != 0 && _secondToOperate != 0)
                _result = _firstToOperate + _secondToOperate;
            EditorGUILayout.TextField("Input", a.ToString() + "," + b.ToString());
            EditorGUILayout.TextField("Result", _result.ToString());

        }

    }
#endif
}
