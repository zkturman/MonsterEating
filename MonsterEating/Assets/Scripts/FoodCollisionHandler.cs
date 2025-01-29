using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private FoodData _foodInfo;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out MainController monster))
        {
            MonsterController controller = monster.GetComponentInChildren<MonsterController>();
            if (controller != null) 
            {
                controller.EatFood(_foodInfo);
            }
        }
        else if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
