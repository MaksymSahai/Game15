using System;
using Game15;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text _textMoves;

    private const int SIZE = 4;
    private Game _game;
    private SoundController _soundController;

    // Use this for initialization
    void Start()
    {
        _game = new Game(SIZE);
        _soundController = GetComponent<SoundController>();
        HideButtons();
    }

    public void OnStart()
    {
        _game.Start(1000 + DateTime.Now.DayOfYear);
        ShowButtons();
        _soundController.PlayStart();
    }

    public void OnClick()
    {
        if (_game.Solved())
            return;
        string name = EventSystem.current.currentSelectedGameObject.name;
        int x = int.Parse(name.Substring(0,1));
        int y = int.Parse(name.Substring(1,1));
        if(_game.PressAt(x, y)>0)
            _soundController.PlayMove();
        ShowButtons();
        if (_game.Solved())
        {
            _textMoves.text = "Game finished in " + _game.Moves + " moves.";
            _soundController.PlaySolved();
        }
    }

    private void ShowDigitAt(int digit, int x, int y)
    {
        string name = x + "" + y;
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        text.text = DecToHex(digit);
        button.GetComponentInChildren<Image>().color =
            (digit > 0) ? Color.white : Color.clear;
    }

    private string DecToHex(int digit)
    {
        if (digit == 0)
            return "";
        return digit.ToString();
    }

    private void HideButtons()
    {
        for (int x = 0; x < SIZE; x++)
            for (int y = 0; y < SIZE; y++)
                ShowDigitAt(0, x, y);
        _textMoves.text = "Welcome to Game 15";
    }

    private void ShowButtons()
    {
        for (int x = 0; x < SIZE; x++)
            for (int y = 0; y < SIZE; y++)
                ShowDigitAt(_game.GetDigitAt(x,y), x, y);
        _textMoves.text = "Moves:" + _game.Moves;
    }
}
