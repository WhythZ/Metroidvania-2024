using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    //���ӵ�ʵ���Animator�ڵ���Ⱦ��Component
    private SpriteRenderer sr;

    [Header("FlashFX")]
    //��¼���ڶ���Ч���ĵĲ���
    private Material originMat;
    [SerializeField] private Material flashHitMat;
    //���ʸ�����ͣ��ʱ��
    [SerializeField] private float flashHitDuration = 0.1f;

    private void Start()
    {
        //���ӵ�ʵ���Animator�ڵ���Ⱦ��Component
        sr = GetComponentInChildren<SpriteRenderer>();

        //��¼ԭʼ����
        originMat = sr.material;
    }

    private IEnumerator FlashHitFX()
    //���������Ҫʹ����fx.StartCoroutine("FlashHitFX");�����ã�������ֱ����fx.FlashHitFX()
    {
        //ʹ���ܻ�����
        sr.material = flashHitMat;
        //�ӳ�һ��ʱ��
        yield return new WaitForSeconds(flashHitDuration);
        //�ع�ԭ���Ĳ���
        sr.material = originMat;
    }

    private void RedBlink()
    //���÷���ʾ��bringer.fx.InvokeRepeating("RedBlink", 0, 0.1f);��Ϊ�ӳ��������0.1f��Ƶ�ʳ�������
    {
        //��Ч����������ʵ�屻����ѣ�κ��ڵ�״̬�н��к�ɫ����˸����ʵ���StunnedState�б�InvokeRepeating���ϵ���
        if(sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }

    private void CancelRedBlink()
    //����ʾ��bringer.fx.Invoke("CancelRedBlink", 0);��Ϊ�ӳ��������ô˺���
    {
        //�˺�������ȡ��MonoBehaviour�е�����InvokeRepeating�����������Ǹ���Invoke��RedBlink����
        CancelInvoke();
        //��ȷ��������ɫ�ָ�Ϊ��ɫ
        sr.color= Color.white;
    }
}