﻿using System;
using System.Timers;
namespace CarAppControlPanel.Services;

public class DateAndTimeService
{
    private readonly Timer _timer;

    public event Action? TimeUpdated;
    public string? CurrentDate { get; private set; }
    public string? CurrentTime { get; private set; }

    public DateAndTimeService()
    {
        _timer = new Timer(1000);
        _timer.Elapsed += (s, e) => SetCurrentDateAndTime();
        _timer.Start();
    }

    private void SetCurrentDateAndTime()
    {
        CurrentTime = DateTime.Now.ToString("HH:mm");
        CurrentDate = DateTime.Now.ToString("dddd, d MMMM yyyy");

        TimeUpdated?.Invoke();
    }
}
