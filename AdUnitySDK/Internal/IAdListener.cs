using System;
namespace ChimeraVirtualAds.Internal
{
	public interface IAdListener
	{
		void OnAdLoaded();
		void OnAdLoadFailed(EventArgs args);
		//void OnAdInstanceCreated();
	}
}