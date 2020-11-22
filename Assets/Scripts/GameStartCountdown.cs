using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartCountdown : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;
    private float StartTimer = 5f;
    public Vector2 CurrentPosition;
    public float GameStart = 0;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CurrentPosition;
        Debug.Log(Mathf.Round(StartTimer));
        StartTimer -= Time.deltaTime;
        DisplayText = GameObject.FindGameObjectWithTag("GameStartText").GetComponent<TextMeshProUGUI>();
        this.GetComponent<DeathCountDown>().increaseTime();

        if (Mathf.Round(StartTimer) == 5)
        {
            DisplayText.text = "3";
        }

        if (Mathf.Round(StartTimer) == 4)
        {
            DisplayText.text = "2";
        }

        if (Mathf.Round(StartTimer) == 3)
        {
            DisplayText.text = "1";
        }

        if (Mathf.Round(StartTimer) == 2)
        {
            DisplayText.text = "GO";
        }

        if (Mathf.Round(StartTimer) == 1)
        {
            DisplayText.text = "";
            GameStart = 1;
            PlayerPrefs.SetFloat("start", GameStart);
            Destroy(this.GetComponent<GameStartCountdown>());
        }
    }
}
