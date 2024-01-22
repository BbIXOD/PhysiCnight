using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

public class ComboActivator : Activator
{
    [SerializeField]private ActionsContainer[] container;
    [SerializeField]private int[] cooldowns;
    [SerializeField]private int comboStopCooldown;

    private bool _ready = true;
    private Timer _timer;

    private int _step = 0;
    private int Step { 
        get => _step;
        set {
            _step = value;
            usables = container[_step].actions;
        }
    }

    private void Awake() {
        usables = container[0].actions;
    }

    public override async void Recharge()
    {
        if (Step < container.Length - 1) Step++;
        else Step = 0;
        _ready = false;
        _timer.Stop();
        _timer = new Timer(comboStopCooldown);
        _timer.Elapsed += ResetCombo;
        await Task.Delay(cooldowns[Step]);
        _ready = true;
    }

    private void ResetCombo(object sender, ElapsedEventArgs e)
    {
        _ready = true;
        Step = 0;
    }

    protected override bool CheckIsReady()
    {
        return _ready;
    }
}
