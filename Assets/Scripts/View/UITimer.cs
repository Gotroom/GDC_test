using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    private Text _text;

    public bool IsActive
    {
        get => _text.gameObject.activeSelf;
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public float Text
    {
        set => _text.text = $"{value:0.0}";
    }

    public void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }
}
