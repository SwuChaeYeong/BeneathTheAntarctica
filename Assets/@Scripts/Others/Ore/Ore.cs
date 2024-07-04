using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Ore : MonoBehaviour
{
    [Header("HP_Slider")]
    public Slider hpSlider;

    [Header("Basic_Info")]
    public int parts; // 전리품 번호
    public string name;
    public Sprite img;
    public float hp = 50f;
    public float maxHp = 50f;
    public float displayTime = 5f; // HP 슬라이더를 보여줄 시간
    public float respawnTime = 5f;
    
    private bool isPlayerAttacking = false;
    
    private Coroutine countdownCoroutine;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    
    [Header("피격 파티클")]
    public ParticleSystem attackedVFX;
    
    [Header("WhiteFlash 이펙트")]
    [SerializeField] private float flashDuration;
    public Color flashColor;
    private Material mat;
    private IEnumerator flashCoroutine;
    
    private void Start()
    {
        hpSlider.gameObject.SetActive(false);
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackedVFX = attackedVFX.GetComponent<ParticleSystem>();
        mat.SetColor("_FlashColor", flashColor);
    }
    
    private void Awake() {
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Flash(){
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);
		
        flashCoroutine = DoFlash();
        StartCoroutine(flashCoroutine);
    }

    private IEnumerator DoFlash()
    {
        float lerpTime = 0;

        while (lerpTime < flashDuration)
        {
            lerpTime += Time.deltaTime;
            float perc = lerpTime / flashDuration;

            if (lerpTime <= flashDuration / 2)
            {
                SetFlashAmount(perc * 2);
            }

            SetFlashAmount(1f - perc);
            yield return null;
        }
        SetFlashAmount(0);
    }
	
    private void SetFlashAmount(float flashAmount)
    {
        mat.SetFloat("_FlashAmount", flashAmount);
    }
    
    public void Damaged(int damage)
    {
        attackedVFX.Play();
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            LevelManager.Instance.AddExp(5);
            InventoryManager.Instance.AddPart(name, Random.Range(1, 3), img);
            FadeOutAndDisable();
            //StartCoroutine(RespawnAfterDelay(respawnTime));
            return;
        }
        
        CameraController.Instance.OnShakeCamera(0.1f, 0.1f);
        
        hpSlider.value = hp / maxHp;
        hpSlider.gameObject.SetActive(true);
        isPlayerAttacking = true;

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = StartCoroutine(HideHpSliderAfterDelay(displayTime));

        Flash();
    }
    
    // HP 게이지 딜레이
    IEnumerator HideHpSliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 시간이 다 되었으므로 HP 슬라이더를 다시 숨김
        hpSlider.gameObject.SetActive(false);
        isPlayerAttacking = false;
    }

    // 딜레이 후, 리스폰
    IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.SetActive(true);
        spriteRenderer.color = Color.white; // 알파값 리셋
        boxCollider.enabled = true;
        hp = maxHp;
        hpSlider.value = maxHp;
    }

    // 광물, HP슬라이더 숨김처리
    void FadeOutAndDisable()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0f);
        boxCollider.enabled = false;
        hpSlider.gameObject.SetActive(false);
    }
}
