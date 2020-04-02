using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touitteur.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Touitteur
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public Detail(Touitte touitte)
        {
            InitializeComponent();
            TouitteInfo.Text = touitte.TouitteInfo;
            Text.Text = touitte.Text;
        }
    }
}