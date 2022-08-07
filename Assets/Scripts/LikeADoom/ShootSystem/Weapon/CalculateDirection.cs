using UnityEngine;

public class CalculateDirection
{
    private readonly Transform _weapon;
    private readonly Transform _spawnBullet;

    public CalculateDirection(Transform weapon, Transform spawnBullet)
    {
        _weapon = weapon;
        _spawnBullet = spawnBullet;
    }

    public Vector3 GetDirection()
    {
        Vector3 b = _spawnBullet.position;
        Vector3 a = _weapon.TransformPoint(new Vector3(0, _spawnBullet.localPosition.y, 0));
        return b - a;
    }
}
