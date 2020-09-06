using UnityEngine;

public class HandheldCamera : MonoBehaviour {

    public bool Active = true;
    public float PositionFrequency = 0.4f;
    public float RotationFrequency = 0.3f;
    public Vector3 PositionStrength = new Vector3(0.2f, 0.2f, 0);
    public Vector3 RotationStrength = new Vector3(0, 0, 0.2f);
    private float seed;

    private void Awake() {
        seed = Random.value;
    }

    private void LateUpdate() {
        if(!Active) return;

        transform.localPosition = new Vector3(
            PositionStrength.x * (Mathf.PerlinNoise(seed, Time.time * PositionFrequency) - 0.5f),
            PositionStrength.y * (Mathf.PerlinNoise(seed + 1, Time.time * PositionFrequency) - 0.5f),
            PositionStrength.z * (Mathf.PerlinNoise(seed + 2, Time.time * PositionFrequency) - 0.5f)
        );

        transform.localRotation = Quaternion.Euler(new Vector3(
            RotationStrength.x * (Mathf.PerlinNoise(seed + 3, Time.time * RotationFrequency) - 0.5f),
            RotationStrength.y * (Mathf.PerlinNoise(seed + 4, Time.time * RotationFrequency) - 0.5f),
            RotationStrength.z * (Mathf.PerlinNoise(seed + 5, Time.time * RotationFrequency) - 0.5f)
        ));
    }
}