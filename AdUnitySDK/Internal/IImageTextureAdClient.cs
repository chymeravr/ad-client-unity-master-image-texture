using System;
namespace ChimeraVirtualAds.Internal
{
	public interface IImageTextureAdClient
	{
		void LoadAd();
		IAdInstanceClient CreateInstance(String instanceId);
		bool IsAdLoaded();
		byte[] getImageByteStream();
	}
}

