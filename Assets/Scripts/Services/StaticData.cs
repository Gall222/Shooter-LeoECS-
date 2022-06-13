using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StaticData : ScriptableObject
{
    public GameObject playerPrefab;
    public float playerSpeed;
    public float smoothTime; // параметр, отвечающий за плавность движения камеры
    public Vector3 followOffset; // оффсет от игрока
}
