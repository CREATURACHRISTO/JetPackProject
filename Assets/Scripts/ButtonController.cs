using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Button play;
    private Button settings;
    private Button exitSettings;

    private GameObject titleMenu;
    private GameObject settingMenu;

    private void Awake()
    {
        play = transform.Find("TitleOrganizer/PlayButton").GetComponent<Button>();
        settings = transform.Find("TitleOrganizer/SettingsButton").GetComponent <Button>();
        exitSettings = transform.Find("SettingsMenu/SettingsExit").GetComponent<Button>();

        play.onClick.AddListener(OnButtonPlayClicked);
        settings.onClick.AddListener(OnButtonSettingsClicked);
        exitSettings.onClick.AddListener(OnExitSettingsClicked);

        titleMenu = GameObject.Find("TitleOrganizer");
        settingMenu = GameObject.Find("SettingsMenu");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        titleMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    private void OnButtonPlayClicked()
    {
        SceneManager.LoadScene(sceneName: "Assets/Scenes/StarterScene");
    }

    private void OnButtonSettingsClicked()
    {
        titleMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    private void OnExitSettingsClicked()
    {
        settingMenu.SetActive(false);
        titleMenu.SetActive(true);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
