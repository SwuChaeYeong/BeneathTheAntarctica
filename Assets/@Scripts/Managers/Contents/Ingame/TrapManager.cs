using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : Manager<TrapManager>
{
    [SerializeField] private GameObject prfWaterBomb;
    [SerializeField] private GameObject prfGas;

    public Vector3 mapSize = new Vector3(-9, 5, 0);

    //�÷��̾� �� �̵��� �� X,Y ��ġ�� ����
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
        //���߿� true�� ���� ���� ���η� üũ
        while (PortalManager.Instance.isInMine)
        {
            //��� �ð� ���� �� 10�� ��� �� ����
            yield return new WaitForSeconds(10.0f);

            //�� �������� ���� ����
            Vector3 gasRange = new Vector3(3, -4, -2);

            //���� �� ����
            Vector3 randomRange = new Vector3(Random.Range(0, 12), Random.Range(0, 5), 0);

            //������ ����
            GameObject gas = Instantiate(prfGas, mapSize + randomRange + gasRange, Quaternion.identity);

            //����
            yield return new WaitForSeconds(5.0f);
        }

        yield return null;
    }

    //-6~6, 4(����)/-5 + -9(����)/9,2~-2
    IEnumerator StartWaterBomb()
    {
        while (PortalManager.Instance.isInMine)
        {
            Debug.Log(PortalManager.Instance.isInMine);

            //5�� ���
            yield return new WaitForSeconds(5.0f);

            //ȸ�� ����
            Vector3 rot = new Vector3(90 * Random.Range(0, 3), 90, 0);

            //��ġ ����
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

            //������ ����
            GameObject waterBomb = Instantiate(prfWaterBomb, mapSize + waterTransform, Quaternion.identity);
            waterBomb.transform.GetChild(0).transform.eulerAngles = rot;

            //2�� ���
            yield return new WaitForSeconds(2.0f);
        }

        yield return null;
    }
}
