using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _cooldown;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        WaitForSecondsRealtime waitingTime = new WaitForSecondsRealtime(_cooldown);

        while (enabled)
        {
            yield return waitingTime;

            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            bullet.Init(direction);
        }
    }
}