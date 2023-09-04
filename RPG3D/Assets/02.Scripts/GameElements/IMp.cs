using RPG.FSM;
using System;
using UnityEngine;

namespace RPG.GameElements
{
    public interface IMp
    {
        float mp { get; set; }
        float mpMax { get; }
        float mpMin { get; }

        event Action<float> onMpChanged; // ����� ��
        event Action<float> onMpRecovered; // ȸ���� ��
        event Action<float> onMpDepleted; // ���ҵ� ��
        event Action onMpMax;
        event Action onMpMin;


        void RecoverMp(MachineManager characterMachine, float amount);
        void DepleteMp(MachineManager characterMachine, float amount);
    }
}