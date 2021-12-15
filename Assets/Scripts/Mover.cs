using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    void Update()
    {
        MoveHero();
    }

    private void MoveHero()
    {
        float xValue = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float yValue = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue, 0, yValue);
    }

}
