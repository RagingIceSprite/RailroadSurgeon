// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SimpleGradientShader"
{
	Properties
	{
		_Color("color",color) = (1,1,1,1)
		
		_HeightMin("height min",float) = -1
	    _HeightMax("height max",float) = 1
	    _ColorMin("tint color min",color) = (0,0,0,1)
	    _ColorMax("tint color max",color) = (1,1,1,1)
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}
		
		Cull off
		Blend SrcAlpha OneMinusSrcAlpha
		zWrite on
		Lighting off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma target 3.0

			#include "UnityCG.cginc"

			float4 _Color;
			
			float4 _ColorMin;
		    float4 _ColorMax;
		    float _HeightMin;
		    float _HeightMax;
     
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 localPos : TEXCOORD0;
				float4 screenPos : TEXCOORD1;
			};
			
			v2f vert ( appdata_base v )
			{
				v2f o;
				UNITY_INITIALIZE_OUTPUT(v2f,o);
			    
				o.vertex = UnityObjectToClipPos(v.vertex);
			    o.localPos = v.vertex.xyz;
			    o.screenPos = ComputeScreenPos(o.vertex);
			    
				return o;
			}

			float4 frag ( v2f i ) : COLOR
			{
				// Get base color
				float4 col = _Color;

				// Local vertex height
				float h = (_HeightMax - i.localPos.y) / (_HeightMax - _HeightMin);
				//float hDivider = 6;
				//h = ceil(h * hDivider) / hDivider;
				
				float4 tintCol = lerp(_ColorMax.rgba,_ColorMin.rgba,h);
				
				// Apply gradient
				float4 gradientCol = col * tintCol;

				// Define final color
				float4 finalCol = gradientCol;
				
				return finalCol;
			}
			ENDCG
		}
	}
}
