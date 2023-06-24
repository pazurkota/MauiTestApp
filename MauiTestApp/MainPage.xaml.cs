﻿namespace MauiTestApp;

public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e) {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void CheckInternetConnection(object sender, EventArgs e) {
        var hasInternet = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        var internetType = Connectivity.Current.ConnectionProfiles.FirstOrDefault();

        var content = hasInternet ? $"Status: Connected with type {internetType}" : "Status: Disconnected";

        await Application.Current.MainPage.DisplayAlert("Internet", content,
            "OK");
    }

    private async void GenerateBobux(object sender, EventArgs e) {
        await Application.Current.MainPage.DisplayAlert("Error", "No bobux for you my friend!", "Oh :(");
    }
}