Shader "Sprites/Outline"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_Mask("Mask texture", 2D) = "white" {}
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
				float2 masktexcoord : TEXCOORD2;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color : COLOR;
				half2 texcoord  : TEXCOORD0;
				float2 masktexcoord  : TEXCOORD2;
			};

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.masktexcoord = (IN.vertex + float2(0.323, 0.37)) * 1.55;

				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap(OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _Mask;
			float4 _Color;

			fixed4 frag(v2f IN) : COLOR
			{
				float4 outCol = tex2D(_MainTex, IN.texcoord);
				float4 maskCol = tex2D(_Mask, IN.masktexcoord);

				//outCol = lerp(outCol, _Color, maskCol.a);

				//outCol = lerp(outCol, maskCol, _asd);

				outCol = lerp(outCol, _Color, (maskCol.a - outCol.a));

				return outCol;
			}
			ENDCG
		}
	}
	Fallback "Sprites/Default"
}