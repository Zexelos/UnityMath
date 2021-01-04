using UnityEngine;

public class Guard : MonoBehaviour
{
    [SerializeField] Transform playerTransform = default;

    Vector3 playerDirection;
    Vector3 guardDirection;

    void Update()
    {
        LeftRightChecker();
    }

    void LeftRightChecker()
    {
        playerDirection = playerTransform.position - transform.position;
        playerDirection = MyNormalize(playerDirection);
        guardDirection = MyNormalize(transform.right);

        float lrDot = MyDotProduct(guardDirection, playerDirection);

        guardDirection = MyNormalize(transform.forward);
        float fbDot = MyDotProduct(guardDirection, playerDirection);

        if (lrDot > 0 && fbDot > 0)
            Debug.Log($"Player is on the front-right side of the {gameObject.name}");
        else if (lrDot > 0 && fbDot < 0)
            Debug.Log($"Player is on the back-right side of the {gameObject.name}");
        else if (lrDot < 0 && fbDot < 0)
            Debug.Log($"Player is on the back-left side of the {gameObject.name}");
        else if (lrDot < 0 && fbDot > 0)
            Debug.Log($"Player is on the front-left side of the {gameObject.name}");
    }

    Vector3 MyNormalize(Vector3 toNormalize)
    {
        Vector3 tmp = toNormalize / Mathf.Sqrt(toNormalize.x * toNormalize.x + toNormalize.y * toNormalize.y + toNormalize.z * toNormalize.z);
        return tmp;
    }

    float MyDotProduct(Vector3 direction1, Vector3 direction2)
    {
        return direction1.x * direction2.x + direction1.y * direction2.y + direction1.z * direction2.z;
    }
}
