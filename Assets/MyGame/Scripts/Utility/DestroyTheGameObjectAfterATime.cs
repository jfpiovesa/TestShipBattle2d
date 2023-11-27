using UnityEngine;

public class DestroyTheGameObjectAfterATime : MonoBehaviour
{
    public float TimeAfeterDestroyThisObject = 5;
    void Start()
    {
        Destroy(this.gameObject, TimeAfeterDestroyThisObject);
    }
}
