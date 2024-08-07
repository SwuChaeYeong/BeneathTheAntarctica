using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : Manager<TrapManager>
{
    [SerializeField] private GameObject prfWaterBomb;
    [SerializeField] private GameObject prfGas;

    public Vector3 mapSize = new Vector3(-9, 5, 0);

    //플레이어 맵 이동시 맵 X,Y 위치값 변경
    public void SwitchMapMinTransform(float x, float y)
    {
        StopAllCoroutines();
        mapSize = new Vector3(x, y, 0);
        StartCoroutine(StartGas());
        StartCoroutine(StartWaterBomb());
    }

    //private void Start()
    //{
    //    StartCoroutine(StartGas());
    //    StartCoroutine(StartWaterBomb());
    //}

    public void RestartTrap()
    {

        StopAllCoroutines();
        StartCoroutine(StartGas());
        StartCoroutine(StartWaterBomb());
    }

    IEnumerator StartGas()
    {
        //나중에 true를 광산 진입 여부로 체크
        while (PortalManager.Instance.isInMine)
        {
            //재생 시간 포함 총 10초 대기 후 생성
            yield return new WaitForSeconds(10.0f);

            //맵 내에서도 범위 설정
            Vector3 gasRange = new Vector3(3, -4, -2);

            //범위 내 랜덤
            Vector3 randomRange = new Vector3(Random.Range(0, 12), Random.Range(0, 5), 0);

            //프리팹 생성
            GameObject gas = Instantiate(prfGas, mapSize + randomRange + gasRange, Quaternion.identity);

            //삭제
            yield return new WaitForSeconds(5.0f);
        }

        yield return null;
    }

    //-6~6, 4(고정)/-5 + -9(고정)/9,2~-2
    IEnumerator StartWaterBomb()
    {
        while (PortalManager.Instance.isInMine)
        {
            Debug.Log(PortalManager.Instance.isInMine);

            //5초 대기
            yield return new WaitForSeconds(5.0f);

            //회전 설정
            Vector3 rot = new Vector3(90 * Random.Range(0, 3), 90, 0);

            //위치 설정
            Vector3 waterTransform = new Vector3(0, 0, 0);
            switch (rot.x)
            {
                case 0:
                    waterTransform = new Vector3(0, -3 + Random.Range(0, -5), -1);
                    break;
                case 90:
                    waterTransform = new Vector3(3 + Random.Range(0, 12), -1, -1);
                    break;
                case 180:
                    waterTransform = new Vector3(18, -3 + Random.Range(0, -5), -1);
                    break;
                case 270:
                    waterTransform = new Vector3(3 + Random.Range(0, 12), -1, -1);
                    break;
            }

            //프리팹 생성
            GameObject waterBomb = Instantiate(prfWaterBomb, mapSize + waterTransform, Quaternion.identity);
            waterBomb.transform.GetChild(0).transform.eulerAngles = rot;

            //2초 대기
            yield return new WaitForSeconds(2.0f);
        }

        yield return null;
    }
}
