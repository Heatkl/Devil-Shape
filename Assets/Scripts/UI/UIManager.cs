using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BuildingUI buildingPanel;
    [Header("Top Panel")]
    [SerializeField] TMP_Text enemiesText;
    [SerializeField] TMP_Text wavesText;
    [SerializeField] TMP_Text chromiteText;
    [SerializeField] TMP_Text uvaroviteText;
    [SerializeField] TMP_Text essenseText;
    [Header("Finish Panels")]
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    public void OpenTowerUpdate()
    {

    }

    public void OpenTowerBuilding(Transform targetBuilding)
    {
        buildingPanel.SetBuildingUI(targetBuilding);
    }

    public void UpdateTopPanel(int enemies, int waves, ResourcesSet set)
    {
        enemiesText.text = "Enemies " + enemies;
        wavesText.text = "Waves " + waves;
        chromiteText.text = "x" + set.chromite;
        uvaroviteText.text = "x" + set.uvarovite;
        essenseText.text = "x" + set.magicEssence;
    }

    public void UpdateResources(ResourcesSet set)
    {
        chromiteText.text = "x" + set.chromite;
        uvaroviteText.text = "x" + set.uvarovite;
        essenseText.text = "x" + set.magicEssence;
    }

    public void UpdateEnemies(int enemies)
    {
        enemiesText.text = "Enemies " + enemies;
    }

    public void UpdateWaves(int waves)
    {
        wavesText.text = "Waves " + waves;
    }

    public void WinUI()
    {
        winPanel.SetActive(true);
    }

    public void LoseUI()
    {
        losePanel.SetActive(true);
    }


}
