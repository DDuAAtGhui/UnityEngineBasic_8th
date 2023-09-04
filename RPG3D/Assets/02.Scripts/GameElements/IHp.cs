using RPG.FSM;
using System;
using UnityEngine;

namespace RPG.GameElements
{
    public interface IHp
    {
        float hp { get; set; }
        float hpMax { get; }
        float hpMin { get; }

        event Action<float> onHpChanged; // ����� ��
        event Action<float> onHpRecovered; // ȸ���� ��
        event Action<float> onHpDepleted; // ���ҵ� ��
        event Action onHpMax;
        event Action onHpMin;


        void RecoverHp(MachineManager characterMachine, float amount);
        void DepleteHp(MachineManager characterMachine, float amount);
    }
}