using UnityEngine;
using System.Collections;

public static class StaticUtility {

    public static GameObject SpawnRandomlyInCircle(GameObject obj, Vector2 center, float radius)
    {
        Vector3 position = (Random.insideUnitCircle * radius) + center;
        var rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(-90.0f, 90.0f));
        return GameObject.Instantiate(obj, position, rotation) as GameObject;
    }

}
