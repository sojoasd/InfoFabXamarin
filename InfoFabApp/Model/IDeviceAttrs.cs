using System;
namespace InfoFabApp
{
	public class DeviceAttrs
	{
		public int Height { get; set; }
		public int Width { get; set; }
	}

	public interface IDeviceAttrs
	{
		DeviceAttrs GetDeviceAttrs();
	}
}
