using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogMovements
{
    [System.Serializable]
    public enum MovementTypes
    {
        Normal = 0,
        Hopping = 1,
    }


    public class EnemyLog : MonoBehaviour
    {
        public LogMovements.MovementTypes MovementType;
        public GameObject player;
        Vector2 playerPos;
        Vector2 enemyPos;
        public float enemySpeed = 1;
        EnemyLogBase move;
        Rigidbody rb;
        
        void Start()
        {
            switch (MovementType)
            {
                case MovementTypes.Normal:
                    move = new EnemyLogType1();
                    break;
                // case MovementTypes.Hopping:
                //     move = new EnemyLogType2();
                //     break;
                default:
                    break;
            }
    
            rb = GetComponent<Rigidbody>();
        }

        
        void FixedUpdate()
        {
            playerPos = player.transform.position;
            enemyPos = transform.position;
            Vector2 v = move.moveEnemy(playerPos, enemyPos, enemySpeed);
            rb.AddForce(new Vector3(v.x, 0, v.y));
        }
    }

    public abstract class EnemyLogBase
    {
        public abstract Vector2 moveEnemy(Vector2 posP, Vector2 posE, float speed);
    }

    public sealed class EnemyLogType1 : EnemyLogBase
    {
        public override Vector2 moveEnemy(Vector2 posP, Vector2 posE, float speed)
        {
        Vector2 V;
        V = (posP - posE)*speed;

        return V;
        }
    }

    // public sealed class EnemyLogType1 : EnemyLogBase
    // {
    //     public override Vector2 moveEnemy(Vector2 posP, Vector2 posE, float speed)
    //     {

    //     Vector2 pointMove;

    //     pointMove = new Vector2((posP.x - posE.x)*speed, (posP.y - posE.y)*speed );

    //     return pointMove;
    //     }
    // }

}
