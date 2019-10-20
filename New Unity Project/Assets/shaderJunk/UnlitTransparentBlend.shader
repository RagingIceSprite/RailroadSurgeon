// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/UnlitTransparentBlend"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"RenderType" = "Opaque"
		}

		Stencil
		{
			Ref 2
			Comp NotEqual
			Pass Replace
		}

		Cull off
		Blend SrcAlpha OneMinusSrcAlpha
		zWrite on

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma multi_compile_fog
			#pragma target 3.0

			#include "UnityCG.cginc"

			float4 _Color;

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2  uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
			};

			float4 _MainTex_ST;

			v2f vert ( appdata_base v )
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
			    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			float4 frag ( v2f i ) : COLOR
			{
				float4 col = _Color;
				UNITY_APPLY_FOG(i.fogCoord,col);
				//UNITY_OPAQUE_ALPHA(col.a);
				return col;
			}
			ENDCG
		}
	}
}
