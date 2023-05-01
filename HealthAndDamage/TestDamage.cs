//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TestDamage : MonoBehaviour
//{
//    //public BasicHealth Target;
//    public float Damage;
//    public float TimeInterval;
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(DamageCR());
//    }

//    private IEnumerator DamageCR()
//    {
//        while(true)
//        {
//            yield return new WaitForSeconds(TimeInterval);
//            Target.Damage(Damage);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
