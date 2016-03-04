// Simplified Additive Particle shader. Differences from regular Additive Particle one:
// - no Tint color
// - no Smooth particle support
// - no AlphaTest
// - no ColorMask

Shader "Custom/Mobile/Particles/Additive (Soft)" {

	Properties {
		_MainTex ("Particle Texture", 2D) = "white" {}
	}

	Category {

		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Blend One OneMinusSrcColor
		Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
		
		BindChannels {
			Bind "Color", color
			Bind "Vertex", vertex
			Bind "TexCoord", texcoord
		}
		
		SubShader
		{
			Pass
			{
				SetTexture [_MainTex] {
					combine texture * primary
				}

				SetTexture [_MainTex] {
					constantColor (0,0,0,1)
					combine previous lerp (previous) constant
				}
			}
		}
	}
}