using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScreen : ScreenScript
{
    // ��� ������������ �� ����� ���� ������� ���� ���������� � �������� ��������� SerializeField, ����� ��� ���� ����� � ����������
    [SerializeField] private TextMeshProUGUI currentInMagazineLabel;
    [SerializeField] private TextMeshProUGUI totalAmmoLabel;

    public void SetAmmo(int current, int total)
    {
        currentInMagazineLabel.text = current.ToString();
        totalAmmoLabel.text = total.ToString();
    }
}
