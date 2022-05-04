using Assets.CodeBase;
using Assets.CodeBase.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Button Button;

    public Sprite ButtonImage;
    public Sprite PressButtonImage;

    public bool isPlay = true;

    private IInputService _input;

    private void Start()
    {
        _input = Game.InputService;
        Button.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        if (isPlay)
        {
            Game.InputService = null;
            Time.timeScale = 0;
            Button.image.sprite = PressButtonImage;
            isPlay = false;
        }
        else
        {
            Game.InputService = _input;
            Time.timeScale = 1;
            Button.image.sprite = ButtonImage;
            isPlay = true;
        }
    }
}
