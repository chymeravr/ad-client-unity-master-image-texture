//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using co.chimeralabs.ads.managed;

namespace ChimeraVirtualAds
{
	public class TextureUnity:ITexture
	{
		private Texture2D tex;
		private byte[] data;
		public TextureUnity ()
		{
			//tex = new Texture2D (2, 2);
		}
		
		public Boolean CreateTextureObject(byte[] texdata){
			//tex.LoadImage (texdata);
			this.data = texdata;
			return true;
		}
		
		public Texture2D GetTextureObject(){
			if (tex == null) {
				tex = new Texture2D(2, 2);
				tex.LoadImage(data);
				data = null;
			}
			return tex;
		}
	}
}

