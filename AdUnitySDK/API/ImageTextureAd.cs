using System;
using System.Collections;
using UnityEngine;
using ChimeraVirtualAds.Internal;
using ChimeraVirtualAds.Implementation;

namespace ChimeraVirtualAds.API
{
	public class ImageTextureAd:IAdListener{
		private IImageTextureAdClient adClient;
		private String adId;
		private Texture2D tex;
		private bool isTextureGenerated = false;
		private Hashtable instances = new Hashtable();

		public event EventHandler<EventArgs> OnAdLoaded = delegate {};
		public event EventHandler<EventArgs> OnAdLoadFailed = delegate {};
		//public event EventHandler<EventArgs> OnAdInstanceCreated = delegate {};

		public ImageTextureAd(String adId){
			this.adClient = AdClientFactory.getImageTextureAdClient (this, adId);
			this.adId = adId;
		}

		public void LoadAd(){
			this.adClient.LoadAd ();
		}

		public AdInstance CreateInstance(String instanceId, GameObject adObject, Camera camera){
			AdInstance instance = new AdInstance (this.adId, instanceId, adObject, camera, this.adClient.CreateInstance (instanceId));
			instances.Add (instance.GetInstanceId(), instance);
			return instance;
		}

		public Hashtable GetInstanceMap(){
			return instances;
		}

		public bool IsAdLoaded(){
			return this.adClient.IsAdLoaded ();
		}

		public String GetAdId(){
			return this.adId;
		}

		public void GenerateTexture(){
			if (!adClient.IsAdLoaded ())
				return;
			tex = new Texture2D (2, 2);
			tex.LoadImage (adClient.getImageByteStream ());
			isTextureGenerated = true;
		}

		public void DisplayTexture(){
			foreach (DictionaryEntry entry in instances) {
				AdInstance instance = (AdInstance)entry.Value;
				GameObject adObject = instance.GetAdObject();
				adObject.GetComponent<Renderer> ().material.mainTexture = tex;
				instance.SetInstanceDisplayedTrue();
			}
		}

		public bool IsTextureGenerated(){
			return isTextureGenerated;
		}

		#region IAdListener Implementation
		void IAdListener.OnAdLoaded(){
			OnAdLoaded (this, EventArgs.Empty);
		}

		void IAdListener.OnAdLoadFailed(EventArgs args){
			OnAdLoadFailed (this, args);
		}

		//void IAdListener.OnAdInstanceCreated(){
		//	OnAdInstanceCreated (this, EventArgs.Empty);
		//}
		#endregion
	}
}