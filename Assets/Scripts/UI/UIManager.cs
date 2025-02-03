using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BuildingUI buildingPanel;
    public void OpenTowerUpdate()
    {

    }

    public void OpenTowerBuilding(Transform targetBuilding)
    {
        buildingPanel.SetBuildingUI(targetBuilding);
    }


}
