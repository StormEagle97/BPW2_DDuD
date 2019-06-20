using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    public bool paused = false;
    public bool inMenu = false;
    public bool inMainOptions = false;

    public Dropdown resolutionDropdown;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject graphicOptionsMenuUI;

    Resolution[] resolutions;

    void Start () {
        resolutions= Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inMainOptions)
            {
                Resume();
            }

            else if (!paused)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        graphicOptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        inMenu = false;
        inMainOptions = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        graphicOptionsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
        inMainOptions = true;
        inMenu = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        graphicOptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        inMenu = false;
        inMainOptions = false;
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        graphicOptionsMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        inMenu = true;
        inMainOptions = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void OptionsBack()
    {
        pauseMenuUI.SetActive(true);
        graphicOptionsMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        inMenu = true;
        inMainOptions = false;

        if (Input.GetKeyDown(KeyCode.Escape) && !inMainOptions)
        {
            Pause();
        }
    }

    public void OptionsBackGraphics()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        graphicOptionsMenuUI.SetActive(false);
        inMenu = true;
    }

    public void GraphicOptions()
    {
        pauseMenuUI.SetActive(false);
        graphicOptionsMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        inMenu = true;
        inMainOptions = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionsBackGraphics();
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
