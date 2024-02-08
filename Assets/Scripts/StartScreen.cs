using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        Button.interactable = false;
    }

    public override void Open()
    {
        WindowGroup.alpha = 1f;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
