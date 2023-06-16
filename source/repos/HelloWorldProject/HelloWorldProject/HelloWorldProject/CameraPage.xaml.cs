using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorldProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();
        }

        async void openGallery_Clicked(object sender, EventArgs e)
        {
            var picture = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a picture"
            });

            if (picture != null)
            {
                var imageStream = await picture.OpenReadAsync();

                selectedImage.Source = ImageSource.FromStream(() => imageStream);
            }
        }

        async void openCamera_Clicked(object sender, EventArgs e)
        {
            var picture = await MediaPicker.CapturePhotoAsync();

            if (picture != null)
            {
                var imageStream = await picture.OpenReadAsync();

                selectedImage.Source = ImageSource.FromStream(() => imageStream);
            }
        }
    }
}