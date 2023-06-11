using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovemnt : Object
{
    [SerializeField] float speed;
    [SerializeField] Vector3 topPosition, bottomPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(bottomPosition));
    }

    protected override void Update()
    {
        if(GameManager.instance.PlayerActive) { base.Update(); }
    }

    IEnumerator Move(Vector3 target)
    {
        while(Mathf.Abs((target - transform.localPosition).y) > 0.2f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * speed;

            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }
}
