using System;
using co.chimeralabs.ads.managed;
using ChimeraVirtualAds.Internal;

namespace ChimeraVirtualAds.Implementation.Managed
{
	public class ImageTextureAdClient:IImageTextureAdClient, AdListener
	{
		private ImageTextureAd ad;
		private IAdListener unityListener;
		private bool isAdLoaded = false;
		public ImageTextureAdClient(IAdListener adListener, String adId){
			this.unityListener = adListener;
			ad = new ImageTextureAd (this, adId);
		}
		public IAdInstanceClient CreateInstance(String instanceId){
			AdInstance instance = ad.CreateInstance(instanceId);
			return new AdInstanceClient (instance);
		}
		public void LoadAd(){
			ad.LoadAd ();
		}
		public bool IsAdLoaded(){
			return isAdLoaded;
		}
		public byte[] getImageByteStream(){
			return ad.getImageData ();
		}
		public void OnAdLoadFailed(AdLoadFailedArgs args){
			unityListener.OnAdLoadFailed (args);
		}
		public void OnAdLoaded(System.Object context){
			this.isAdLoaded = true;
			unityListener.OnAdLoaded ();
		}
	}
}
