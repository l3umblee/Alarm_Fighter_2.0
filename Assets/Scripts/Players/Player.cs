using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int currentX, currentY;
    void Start()
    {
        currentX = Managers.Field.GetWidth() / 2;
        currentY = Managers.Field.GetHeight() / 2;
        this.transform.position = Managers.Field.GetGrid(currentX, currentY).transform.position;
        Managers.Field.ScaleByRatio(gameObject, currentX, currentY);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 pos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if(hit.collider != null)
            {
                this.transform.position = hit.collider.transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<Stat>().CurrentHP -= 1;
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<Stat>().CurrentHP += 1;
        }
    }
}
