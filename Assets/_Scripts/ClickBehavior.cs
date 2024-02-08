using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class ClickBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _pointsPerSecText;

    public static float score;
    public static float pointsPerSecond;
    public static int hitPower;

    private void Start()
    {
        LoadData();
        StartCoroutine(EndlessTimer());
    }

    private void LoadData()
    {
        score = PlayerPrefs.GetFloat("score", 0);
        pointsPerSecond = PlayerPrefs.GetFloat("perSec", 0.5f);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        try
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("Last", ""));
            float timeDifference = ((float)ts.TotalSeconds);
            float backgroundPoints = timeDifference * pointsPerSecond;
            score += backgroundPoints;
        }
        catch (FormatException) { }
    }

    public void ClickOnPLane()
    {
        score += hitPower;
        /////DELETE!!!!!////////
        score += 100000;
        ///////////////
    }

    private IEnumerator EndlessTimer()
    {
        while(true)
        {
            score += pointsPerSecond;
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {
        _scoreText.text = ((int)score).ToString();
        _pointsPerSecText.text = $"{pointsPerSecond} per second";
        
    }

    private void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("score", score);
        PlayerPrefs.SetFloat("perSec", pointsPerSecond);
        PlayerPrefs.SetInt("hitPower", hitPower);
        PlayerPrefs.SetString("Last", DateTime.Now.ToString());
    }
}