using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image hitPointsImage;
    public Image teleportCooldownImg;

    [SerializeField]
    private GameObject generalPanel;
    [SerializeField]
    private GameObject instructionsPanel;

    private void Start()
    {
        if(SceneController._instance.getCurrentScene() == "MainMenu")
        {
            generalPanel.SetActive(true);
            instructionsPanel.SetActive(false);
        }
    }
    public void ReduceHpBar(float fillAmount)
    {
        hitPointsImage.fillAmount = fillAmount;
    }

    public void PlayBtn()
    {
        SceneController._instance.LoadPlayScene();
    }

    public void InstructionsBtn()
    {
        instructionsPanel.SetActive(true);
        generalPanel.SetActive(false);
    }

    public void BackBtn()
    {
        generalPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void PauseBtn()
    {

    }
}
