using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public bool reset = false;
    public GameObject levelPanel;
    public LevelButton[] levelButtons;
    public Text totalStarsText;
    public Sprite enabledSprite;
    public AudioClip buttonLevelClickSound;

    private bool setting = false;
    private bool level = false;

    private int levelReached;
    private int totalStars = 0;
    // Use this for initialization
    void Start()
    {
        setting = false;
        level = true;
        if (reset) PlayerPrefs.DeleteAll();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = i + 1;
            levelButtons[i].thisLevel = "Level " + level;
        }

        PlayerPrefs.SetInt("isChangingScene", 0);
    }

    void ShowStars(int stars, LevelButton levelButton)
    {
        if (stars > 0) levelButton.star1.SetActive(true);
        if (stars > 1) levelButton.star2.SetActive(true);
        if (stars > 2) levelButton.star3.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        levelReached = PlayerPrefs.GetInt("levelReached", 1);

        int totalStarOutLoop = 0;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].enabled = false;
            }
                        
            if (levelButtons[i].enabled)
            {
                levelButtons[i].ClickSound = buttonLevelClickSound;

                levelButtons[i].image.sprite = enabledSprite;
                
                int levelButton = i + 1;
                string stringToLoadStars;
                stringToLoadStars = "starMaxReachedLevel" + levelButton;
                int starReached = PlayerPrefs.GetInt(stringToLoadStars, 0);
                
                totalStarOutLoop += starReached;
                ShowStars(starReached, levelButtons[i]);
            }
            if (totalStarOutLoop > totalStars) totalStars = totalStarOutLoop;
        }
        totalStarsText.text = "" + totalStars;
    }

    //Add Level to the scene



    public void SettingPanel()
    {
        level = false;
        setting = true;
        levelPanel.SetActive(false);

    }

    public void LevelPanel()
    {
        level = true;
        setting = false;
        levelPanel.SetActive(true);
    }

    public void ToTitle()
    {
        
        TKSceneManager.ChangeScene("Start Scene");
    }

}
