using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class ClickBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public static float score;
    public static float pointsPerSecond = 0.5f;
    public static int hitPower = 1;

    private void Start()
    {
        score = PlayerPrefs.GetFloat("score", 0);
        try
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("Last", ""));
            float timeDifference = ((float)ts.TotalSeconds);
            float backgroundPoints = timeDifference * pointsPerSecond;
            score += backgroundPoints;
        }
        catch (FormatException) { }

        
        StartCoroutine(EndlessTimer());

        
    }

    public void ClickOnPLane()
    {
        score += hitPower;
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
    }

    private void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("score", score);
        PlayerPrefs.SetString("Last", DateTime.Now.ToString());
    }
}