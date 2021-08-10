using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carros_xamarin_clean.Features.Car.Presentation.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarListView : ContentPage
    {
        public CarListView()
        {
            InitializeComponent();
        }
    }
}