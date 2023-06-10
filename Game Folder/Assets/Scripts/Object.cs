using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] float objectSpeed = 1;
    [SerializeField] float resetPosition = -26.24f;
    [SerializeField] float startPosition = 14.8f;

    Vector3 respawnPosition;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    protected virtual void Update()
    {
        if(!GameManager.instance.GameOver)
        {
            transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);
            if(transform.localPosition.x <= resetPosition)
            {
                transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
            }
        }
    }
}
