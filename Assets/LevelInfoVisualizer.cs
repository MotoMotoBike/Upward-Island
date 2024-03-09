using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoVisualizer : MonoBehaviour
{
    [SerializeField] private int levelID;
    [Space]
    [SerializeField] private Text levelInfoText;
    [SerializeField] private Image[] starsIndicators;
    [SerializeField] private Button button;
    [Space]
    [SerializeField] private GameObject enabledSprite;
    [SerializeField] private GameObject disabledSprite;
    [Space]
    [SerializeField] private Sprite starReached;
    private int score;
    private void Start()
    {
        score = SaveData.GetScoreByLevelID(levelID);
        FillLevelInfoText();
        UpdateAccesToButton();
        ShowLevelStars();
    }

    
    void FillLevelInfoText()
    {
        if(levelInfoText != null) levelInfoText.text = $"{levelID}";
        //if(score == 0) return;
        //levelInfoText.text += $"\n{score}";
    }

    void UpdateAccesToButton()
    {
        if(button == null) return;
        button.enabled = false;
        if (levelID == 1 || score > 0 || SaveData.GetScoreByLevelID(levelID-1) > 0)
        {
            enabledSprite.SetActive(true);
            disabledSprite.SetActive(false);
            button.enabled = true;
        }
    }
    void ShowLevelStars()
    {
        if (score > 10)
        {
            starsIndicators[0].sprite = starReached;
        }
        if (score > 100)
        {
            starsIndicators[1].sprite = starReached;
        }if (score > 200)
        {
            starsIndicators[2].sprite = starReached;
        }
    }

}