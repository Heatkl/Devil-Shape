[System.Serializable]
public class ResourcesSet 
{
    public ResourcesSet(ResourcesSet rewardSettings)
    {
        magicEssence = rewardSettings.magicEssence;
        chromite = rewardSettings.chromite;
        uvarovite = rewardSettings.uvarovite;
    }

    public void Add(ResourcesSet resources)
    {
        magicEssence += resources.magicEssence;
        chromite += resources.chromite;
        uvarovite += resources.uvarovite;
    }

    public void Remove(ResourcesSet resources)
    {
        magicEssence -= resources.magicEssence;
        chromite -= resources.chromite;
        uvarovite -= resources.uvarovite;
    }

    public bool IsAvaliable(ResourcesSet resources)
    {
        if(magicEssence >= resources.magicEssence
            && chromite >= resources.chromite
            && uvarovite >= resources.uvarovite )
        {
            return true;
        }
        return false;
    }

    public int magicEssence;
    public int chromite;
    public int uvarovite;
}