﻿using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using ZXing.Net.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.ApplicationModel;
using ZXing.QrCode;
using ZXing;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SzafkiSzkolne.ViewModels
{
    public class ManageLockerViewModel : INotifyPropertyChanged
    {
        private string _qrMessage;
        public string QrMessage
        {
            get => _qrMessage;
            set
            {
                if (_qrMessage != value)
                {
                    _qrMessage = value;
                    OnPropertyChanged(nameof(QrMessage));
                }
            }
        }
        private int _lockerNr;
        public int LockerNr
        {
            get => _lockerNr;
            set
            {
                if (_lockerNr != value)
                {
                    _lockerNr = value;
                    OnPropertyChanged(nameof(LockerNr));
                    SetQrMessage();
                }
            }
        }
        public ICommand GenerateQrCodeCommand { get; private set; }
        public ManageLockerViewModel(int lockerNr)
        {
            GenerateQrCodeCommand = new AsyncRelayCommand(GenerateQrCode);
        }

        private async Task GenerateQrCode()
        {
            SetQrMessage();
        }

        private void SetQrMessage()
        {
            QrMessage = $"Numer szafki to {LockerNr}";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
