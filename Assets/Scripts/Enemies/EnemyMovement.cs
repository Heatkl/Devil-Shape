using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent enemyAI;
    void Awake()
    {
        if (enemyAI == null)
        {
            enemyAI = GetComponent<NavMeshAgent>();
        }
    }

    public void Init(Vector3 destinationPoint, float speed)
    {
        //enemyAI.isStopped = false;
        //enemyAI.speed = speed; �����������������, ���� ����� ���������� ������ �������� ����
        enemyAI.enabled = true;
        enemyAI.SetDestination(destinationPoint);
    }

    public void StopMove()
    {
        enemyAI.enabled = false;
    }

}
