using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputField : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMesh;

    private string Text { get => textMesh.text; set => textMesh.text = value; }

    private void Awake()
    {
        Text = "";

        if (InputAdapter.IsInstanced)
        {
            OnInstantiateInputAdapter();
        }
        else
        {
            InputAdapter.OnInstantiate += OnInstantiateInputAdapter;
        }
    }

    private void OnInstantiateInputAdapter()
    {
        InputAdapter.Instance.OnLetterPressed += OnLetterPressed;
        InputAdapter.Instance.OnBackspace += OnBackspace;
        InputAdapter.Instance.OnSubmit += OnSubmit;

        InputAdapter.OnInstantiate -= OnInstantiateInputAdapter;
    }

    private void OnBackspace()
    {
        if (Text.Length > 0)
        {
            Text = Text[..^1];
        }
    }

    private void OnLetterPressed(char letter)
    {
        Text += letter;
    }

    private void OnSubmit()
    {
        GameManager.Instance.SubmitInput(Text);
        Text = "";
    }
}
