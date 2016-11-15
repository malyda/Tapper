using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tapper.Views
{
    
    public partial class TappedPage : ContentPage
    {
      
        public TappedPage()
        {
            InitializeComponent();

            TappedView.GestureRecognizers.Add(new TapGestureRecognizer
            {
               // Command = new Command(Tap)
            });

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) => show(e);
            TappedLabel.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void show(EventArgs e)
        {
            TappedLabel.Text = e.ToString();
            
        }
        private void Tap()
        {
        
            Label labelToAnimate = createLabel();
            AbsoluteLayout.SetLayoutBounds(labelToAnimate, new Rectangle(.5,.5,.1,.1));
            AbsoluteLayout.SetLayoutFlags(labelToAnimate ,AbsoluteLayoutFlags.All);
           TappedView.Children.Add(labelToAnimate);


            labelToAnimate.FadeTo(0, 1000);
           
            //Label.Frame = new RectangleF (Label.Frame.X, Label.Frame.Y + 30, Label.Frame.Width, Label.Frame.Height);
        }

        private Label createLabel()
        {
            return new Label
             {
                 Text = "tap",
                 TextColor = Color.Black,
                 IsVisible = true
             };
        }
    }
}
