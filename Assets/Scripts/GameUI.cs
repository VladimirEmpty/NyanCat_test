using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject startGameUI;
    public TextMeshProUGUI scoreText;

    private int _score;

    public void StartGame()
    {
        startGameUI.SetActive(false);
    }

    public void AddScore()
    {
        _score += 1;

        scoreText.text = _score.ToString();
    }
}
