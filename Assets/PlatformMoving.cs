using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    private bool isForward;
    private Vector2 startPos;

    [SerializeField] float maxOffset;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(startPos, transform.position) > maxOffset)
        {
            isForward = !isForward;
        }

        if (isForward)
        {
            transform.position = (transform.position + (Vector3)direction);
        }
        else
        {
            transform.position = (transform.position - (Vector3)direction);
        }
    }
}
