using System;
using BepInEx;
using UnityEngine;
using GorillaLocomotion;

namespace GorillaTagSuperMod
{
    // تعريف المود واسمه والإصدار (يقرأه برنامج الـ BepInEx)
    [BepInPlugin("com.yourname.gorillatag.supermod", "GorillaTag Super Mod", "1.0.0")]
    public class MySuperMod : BaseUnityPlugin
    {
        void Update()
        {
            // التأكد من أن اللاعب داخل خريطة أو اللعبة تعمل بالكامل
            if (Player.Instance != null)
            {
                // 1. ميزة الطيران (Fly): تفعل عند الضغط على زر "المسافة" أو الـ Trigger في التحكم
                if (UnityInput.Current.GetKey(KeyCode.Space)) 
                {
                    // تحريك اللاعب للأمام باتجاه النظر عند الطيران
                    Player.Instance.transform.position += Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                    
                    // إلغاء الجاذبية مؤقتاً أثناء الطيران لمنع السقوط السريع
                    Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }

                // 2. ميزة السوبر قفزة (Super Jump): تفعل عند الضغط على زر الفأرة الأيمن أو القفز قفزة عالية
                if (UnityInput.Current.GetMouseButton(1)) // زر الماوس الأيمن للتجربة على الكمبيوتر
                {
                    Player.Instance.jumpMultiplier = 2.5f; // مضاعفة قوة القفزة بمقدار مرتين ونصف
                }
                else
                {
                    Player.Instance.jumpMultiplier = 1.1f; // إرجاع السرعة العادية للعبة
                }
            }
        }
    }
}