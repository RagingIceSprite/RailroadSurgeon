Shader "Custom/SimpleUnlitFogStatic"
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
			"RenderType" = "Transparent"
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
            #pragma multi_compile_instancing
            #pragma instancing_options force_same_maxcount_for_gl
			#pragma target 3.0

			#include "UnityCG.cginc"
			
			//fixed4 _Color;
            
			struct v2f
			{
				fixed4 vertex : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
            UNITY_INSTANCING_BUFFER_END(Props)
            
			v2f vert ( appdata_base v )
			{
                v2f o = (v2f)0;
                UNITY_SETUP_INSTANCE_ID(v);
                
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                return o;
			}

			fixed4 frag ( v2f i ) : COLOR
			{     
                UNITY_SETUP_INSTANCE_ID(i);
                float4 c = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
				return c;
			}
			ENDCG
		}
	}
}
