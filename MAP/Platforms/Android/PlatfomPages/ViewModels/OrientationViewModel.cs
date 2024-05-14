using Android.Content.Res;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Android.Locations;
using Java.Awt.Font;

namespace MAP.Platforms.Android.PlatfomPages.ViewModels
{
	public partial class OrientationViewModel: ObservableObject
	{

		Timer _timer;

		int speed = 0;

		int a = 0;

		[ObservableProperty]
		float _x = 0;

		[ObservableProperty]
		float _y = 0;

		[ObservableProperty]
		float _z = 0;
		public OrientationViewModel()
		{
			if(OrientationSensor.Default.IsSupported)
			{
				OrientationSensor.Default.ReadingChanged += Default_ReadingChanged;
				_timer = new Timer(Tick, null, 100, 1000/60);
				if(!OrientationSensor.Default.IsMonitoring)
					OrientationSensor.Default.Start(SensorSpeed.UI);
			}
		}

		void Tick(object? state)
		{
			Value = Math.Clamp(_value + speed + a, 0, 32767);
			if (Value != 0 && Value != 32767)
			{
				speed = Math.Clamp(speed + a, -3000, 3000);
			}
			else
			{
				speed = 0;
				a = 0;
			}
		}

		public static Vector3 ToEulerAngles(Quaternion q)
		{
			Vector3 angles = new();

			// roll / x
			double sinr_cosp = 2 * (q.W * q.X + q.Y * q.Z);
			double cosr_cosp = 1 - 2 * (q.X * q.X + q.Y * q.Y);
			angles.X = (float)Math.Atan2(sinr_cosp, cosr_cosp);

			// pitch / y
			double sinp = 2 * (q.W * q.Y - q.Z * q.X);
			if (Math.Abs(sinp) >= 1)
			{
				angles.Y = (float)Math.CopySign(Math.PI / 2, sinp);
			}
			else
			{
				angles.Y = (float)Math.Asin(sinp);
			}

			// yaw / z
			double siny_cosp = 2 * (q.W * q.Z + q.X * q.Y);
			double cosy_cosp = 1 - 2 * (q.Y * q.Y + q.Z * q.Z);
			angles.Z = (float)Math.Atan2(siny_cosp, cosy_cosp);

			return angles;
		}

		private void Default_ReadingChanged(object? sender, OrientationSensorChangedEventArgs e)
		{
			Quaternion or =  e.Reading.Orientation;
			var angle = ToEulerAngles(or);
			X = angle.X;
			Y = angle.Y;
			Z = angle.Z;

			int delta = 0;
			if(Application.Current.MainPage.Width > Application.Current.MainPage.Height) 
			{
				delta = (int)(angle.X * 7);
			}
			else
			{
				delta = (int)(angle.Y * 30);
			}

			a = delta;
		}



		[ObservableProperty]
		int _value;

		[RelayCommand]
		public void Button()
		{
			ArgsHelper.Invoke(_value);

			ClearThings();

			Application.Current.MainPage.Navigation.PopModalAsync();
		}
		

		public void ClearThings()
		{
			_timer.Dispose();
			OrientationSensor.Default.Stop();
			OrientationSensor.Default.ReadingChanged -= Default_ReadingChanged;
		}
	}
}
