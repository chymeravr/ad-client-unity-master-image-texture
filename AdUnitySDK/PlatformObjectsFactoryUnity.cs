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
	public class PlatformObjectsFactoryUnity:IPlatformObjectsFactory
	{
		public ITexture GetTextureObject(){
			return new TextureUnity ();
		}
		public IPlatform GetPlatformImplementations(){
			#if UNITY_STANDALONE_WIN
				return new PlatformPCWindowsImpl();
			#elif UNITY_EDITOR_WIN
				return new PlatformPCWindowsImpl();
			#else
				return new PlatformPCWindowsImpl();
			#endif
		}
	}
}


