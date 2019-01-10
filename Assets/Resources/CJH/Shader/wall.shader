﻿Shader "Custom/NewSurfaceShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_MainTex2("Albedo(RGB)", 2D) = "white" {}
	}
		SubShader{
			Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard alpha:fade

			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _MainTex2;

			struct Input {
				float2 uv_MainTex;
				float2 uv_MainTex2;
			};

			fixed4 _Color;

			void surf(Input IN, inout SurfaceOutputStandard o) {
				// Albedo comes from a texture tinted by color
				fixed4 d = tex2D(_MainTex2, float2(IN.uv_MainTex2.x - _Time.y, IN.uv_MainTex2.y + 0.2));
				fixed4 c = tex2D(_MainTex,  float2(IN.uv_MainTex.x  + _Time.y, IN.uv_MainTex.y));

				//o.Albedo = c.rgb;
				// Metallic and smoothness come from slider variables
				o.Emission = c.rgb + d.rgb;
				o.Alpha = c.a + d.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}
