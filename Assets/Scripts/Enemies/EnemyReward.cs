[System.Serializable]
public class EnemyReward 
{
    public EnemyReward(EnemyReward rewardSettings)
    {
        magicEssence = rewardSettings.magicEssence;
        chromite = rewardSettings.chromite;
        uvarovite = rewardSettings.uvarovite;
    }
    public int magicEssence;
    public int chromite;
    public int uvarovite;
}