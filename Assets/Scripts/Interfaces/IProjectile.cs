using UnityEngine;

public interface IProjectile
{
    public void Init(Transform enemy, int damage);
    public void Activate();
    public void SelfDestruction();
}
