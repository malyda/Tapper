using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;

namespace Tapper.Views
{

    public partial class TappedPage : ContentPage
    {
        Random cords = new Random();

        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        public TappedPage()
        {
            InitializeComponent();
            /*
            TappedView.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(Tap)
            });
            */

            TapGestureRecognizer viewTap = new TapGestureRecognizer();
            viewTap.Tapped += (s, e) => {
                _tappedScore--;
                show();
                Tap(true);
            };
            TappedView.GestureRecognizers.Add(viewTap);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Tap(false);
                return true; //not continue
            });

            //SetTappedGestureRecognizer();
        }

        private void show()
        {
            TappedLabel.Text = _tappedScore+"";
            
        }
        private async void Tap(bool mistake)
        {
        
            Label labelToAnimate = createTapZone(mistake);

            TappedView.Children.Add(labelToAnimate);


            await labelToAnimate.FadeTo(1, 1000);
            await labelToAnimate.FadeTo(0, 1000);
            TappedView.Children.Remove(labelToAnimate);
        }

        private Label createTapZone(bool mistake)
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
            if (mistake) label.BackgroundColor = Color.Red;
            SetCords(label);
            SetClickedMethod(label);
            return label;
        }

        private void SetCords(View view)
        {
            
            AbsoluteLayout.SetLayoutBounds(view, new Rectangle(cords.NextDouble(), cords.NextDouble(), 45, 45));
            AbsoluteLayout.SetLayoutFlags(view, AbsoluteLayoutFlags.PositionProportional);
        }

        private void SetClickedMethod(View view)
        {
            SetGestureRecognizer(view);
            view.GestureRecognizers.Add(tapGestureRecognizer);
        }
        int _tappedScore = 0;
        private void TappedView1(View view)
        {
            if (view.BackgroundColor == Color.Red) _tappedScore--;
            else _tappedScore++;
            TappedView.Children.Remove(view);
            show();
        }

        private void SetGestureRecognizer(View view)
        {
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                TappedView1(view);
            };
        }
    }
}
