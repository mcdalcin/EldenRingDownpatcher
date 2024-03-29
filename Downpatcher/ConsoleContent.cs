﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

public class ConsoleContent : INotifyPropertyChanged {
    private string consoleInput = string.Empty;
    private ObservableCollection<string> consoleOutput = 
        new ObservableCollection<string>() {
            "Welcome to the Elden Ring Steam Downpatcher!\n" };

    private readonly ScrollViewer scroller;

    public ConsoleContent(ScrollViewer scroller) {
        this.scroller = scroller;
    }

    public string ConsoleInput {
        get {
            return consoleInput;
        }
        set {
            consoleInput = value;
            OnPropertyChanged("ConsoleInput");
        }
    }

    public ObservableCollection<string> ConsoleOutput {
        get {
            return consoleOutput;
        }
        set {
            consoleOutput = value;
            OnPropertyChanged("ConsoleOutput");
        }
    }

    public void Output(string msg) {
        ConsoleInput = msg;
        FlushInput();
        scroller.ScrollToBottom();
    }

    public string GetDebugString() {
        string output = "";
        foreach (string s in ConsoleOutput) {
            output += s;
            output += "\n";
        }
        return output;
    }

    private void FlushInput() {
        ConsoleOutput.Add("> " + ConsoleInput);
        ConsoleInput = string.Empty;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}