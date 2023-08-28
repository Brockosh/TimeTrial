//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Fog : MonoBehaviour
//{
//    public ParticleSystem fogEffect;
//    void Start()
//    {
//        StopFogEffect();
//        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlane += PlayFogEffect;
//        GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += StopFogEffect;
//        //GameManager.instance.CollisionEvent.OnPlayerCollisionEnemySpawningPlaneExit += StopFogEffectLooping;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void PlayFogEffect()
//    {
//        fogEffect.Play();
//    }

//    //

//    private void StopFogEffect()
//    {
//        fogEffect.Stop();
//    }
//}
