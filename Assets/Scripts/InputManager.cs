using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private ScriptableInputData _inputData;

    private void Update()
    {
        _inputData.ProcessInput();
    }
}
