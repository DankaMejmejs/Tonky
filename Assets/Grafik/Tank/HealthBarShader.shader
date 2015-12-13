Shader "Sprites/HealthBar"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_Cutoff("Cutoff", Range(0, 1)) = 0
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog{ Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile DUMMY PIXELSNAP_ON
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color : COLOR;
				half2 texcoord  : TEXCOORD0;
			};

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
				#endif
				return OUT;
			}

			sampler2D _MainTex;
			float _Cutoff;

			fixed4 frag(v2f IN) : COLOR
			{
				float4 outCol = tex2D(_MainTex, IN.texcoord);
				
				float avg = (outCol.r + outCol.g + outCol.b) * 0.3;
				float a = step(avg, _Cutoff);

				outCol = lerp(float4(0, 0, 0, 0), float4(0, 1, 0, 1), 1-a);
				
				return outCol * IN.color;
			}
			ENDCG
		}
	}
	Fallback "Sprites/Default"
}