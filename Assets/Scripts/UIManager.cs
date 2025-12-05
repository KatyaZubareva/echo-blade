using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;
    private VisualElement root;
    private Button startButton;
    private Button exitButton;
    private Button continueButton;
    private Button goBackButton;

    void Start()
    {
        root = uiDocument.rootVisualElement;
        startButton = root.Q<Button>("startButton");
        continueButton = root.Q<Button>("continueButton");
        exitButton = root.Q<Button>("exitButton");
        goBackButton = root.Q<Button>("goBackButton");

        startButton.RegisterCallback<ClickEvent>(onStartButtonClick);
        continueButton.RegisterCallback<ClickEvent>(onContinueButtonClick);
        exitButton.RegisterCallback<ClickEvent>(onExitButtonClick);
        goBackButton.RegisterCallback<ClickEvent>(onGoBackButtonClick);
    }

    private void onStartButtonClick(ClickEvent evt) {
        LoadScene("PlayerSetup");
    }

    private void onContinueButtonClick(ClickEvent evt) {
        LoadScene("GameScreen");
    }

    private void onExitButtonClick(ClickEvent evt) {
        Application.Quit();
    }

    private void onGoBackButtonClick(ClickEvent evt) {
        LoadScene("MainMenu");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
