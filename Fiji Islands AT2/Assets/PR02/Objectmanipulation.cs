using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectManipulation : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject prefabToSpawn;

    void Update()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            Instantiate(prefabToSpawn, new Vector3(16, 2, -13), Quaternion.identity);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            Destroy(targetObject);
        }
    }
}