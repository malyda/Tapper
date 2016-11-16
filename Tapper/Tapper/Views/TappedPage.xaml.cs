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
                Command = new Command(Tap)
            });

            SetTappedGestureRecognizer();
        }

        private void show(EventArgs e)
        {
            TappedLabel.Text = e.ToString();
            
        }
        private async void Tap()
        {
        
            Label labelToAnimate = createTapZone();

            TappedView.Children.Add(labelToAnimate);


            await labelToAnimate.FadeTo(1, 1000);
            await labelToAnimate.FadeTo(0, 1000);
            TappedView.Children.Remove(labelToAnimate);
        }

        private Label createTapZone()
        {
            Label label = new Label
            {
                Text = "tap",
                TextColor = Color.Black,
                Opacity = 0,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Blue
            };
            SetCords(label);
            SetClickedMethod(label);
            return label;
        }

        private void SetCords(View view)
        {
            AbsoluteLayout.SetLayoutBounds(view, new Rectangle(.5, .5, .2, .2));
            AbsoluteLayout.SetLayoutFlags(view, AbsoluteLayoutFlags.All);
        }

        private void SetClickedMethod(View view)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                TappedView1(view); 
            };
            view.GestureRecognizers.Add(tapGestureRecognizer);
        }
        int _tappedScore = 0;
        private void TappedView1(View view)
        {
            _tappedScore++;
            TappedView.Children.Remove(view);
            TappedLabel.Text = _tappedScore+"";
        }

        private SetGestureRecognizer()
        {

        }
    }
}
