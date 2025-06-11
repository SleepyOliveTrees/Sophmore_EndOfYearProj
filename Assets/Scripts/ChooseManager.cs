using UnityEngine;

public class ChooseManager : MonoBehaviour
{
    public GameObject FirstPanel;
    public GameObject Panel; //Instruction Panel
    public GameObject InfoPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FirstPanel.SetActive(true);
        Panel.SetActive(false);
        InfoPanel.SetActive(false);

    }

    public void ShowPanel()
    {
        FirstPanel.SetActive(false);
        Panel.SetActive(true);
        InfoPanel.SetActive(false);
    }
    public void ShowInfoPanel()
    {
        FirstPanel.SetActive(false);
        Panel.SetActive(false);
        InfoPanel.SetActive(true);
    }

    public void BackToFirstPanel()
    {
        FirstPanel.SetActive(true);
        Panel.SetActive(false);
        InfoPanel.SetActive(false);
    }


}
