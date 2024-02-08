using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _windowGroup;

    protected CanvasGroup WindowGroup => _windowGroup;
    protected Button Button => _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    public abstract void Open();

    public abstract void Close();
}                                  
    
