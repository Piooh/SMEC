shader "ShaderLecture/BaseDiffuse"
{
//	Properties
//	{
//		_DiffuseColor ( "Diffuse Color", Color) = (1, 1, 1, 1)
//		_EmissiveColor ("Emissive Color", Color) = (1, 1, 1, 1)
//		_AmbientColor ("Ambient Color", Color) = (1, 1, 1, 1)
//		_SliderValue ("This is Slider", Range(0, 10)) = 2.5
//	}

//	SubShader
//	{
//		Tags { "RenderType"="Opaque" }
//		LOD 200
//
//		CGPROGRAM
//		#pragma surface surf Lambert
//
//		float4 _EmissiveColor;
//		float4 _AmbientColor;
//		float _SliderValue;
//
//		struct Input
//		{
//			float2 uv_MainTex;
//		};
//
//		void surf( Input IN, inout SurfaceOutput o )
//		{
//			float4 c;
//			c = pow((_EmissiveColor + _AmbientColor), _SliderValue);
//			o.Albedo = c.rgb;
//			o.Alpha = c.a;
//		}
//		ENDCG
//	}

//	SubShader
//	{
//		Tags{ "RenderType"="Opaque" }
//
//		CGPROGRAM
//		#pragma surface surf DiffLight vertex:vert finalcolor:finalCol
//
//		struct Input
//		{
//			float4 color : COLOR;
//		};
//
//		void vert( inout appdata_full v )
//		{
//		}
//
//		void surf( Input In, inout SurfaceOutput o )
//		{
//		}
//
//		half4 LightingDiffLight( SurfaceOutput s, half3 lightDir, half atten )
//		{
//			half4 c = half4(1, 1, 1, 1);
//			return c;
//		}
//
//		void finalCol( Input In, SurfaceOutput o, inout fixed4 color )
//		{
//			color *= In.color * float4( 1, 0, 0, 1 );
//		}
//
//		ENDCG
//	}

	Properties
	{
		_DiffuseTexture ("MainTexture", 2D) = "White" {}
		_DiffuseLightColor ("DiffuseLightColor", COLOR) = (1, 1, 1, 1)
	}

	SubShader
	{
		Tags{ "RenderType"="Opaque" }

		CGPROGRAM
//		#pragma surface surf DiffLightSpecular
		#pragma surface surf DiffLight
//		#pragma surface surf Lambert
//		#pragma surface surf BlinnPhong

		struct Input
		{
			float2 uv_MainTex;
		};

		sampler2D 	_DiffuseTexture;
		float4		_DiffuseLightColor;

		void surf( Input In, inout SurfaceOutput o )
		{
			o.Albedo = tex2D( _DiffuseTexture, In.uv_MainTex );
		}

//		half4 LightingDiffLightSpecular( SurfaceOutput s, half3 lightDir, half3 viewDir,  half atten )
//		{
//			half4 c;
//			half nDotL = dot( lightDir, s.Normal );
//			c.rgb = s.Albedo * ((nDotL) * atten);
//			c.a	 = s.Alpha;
//
//			return c;
//		}

//		half4 LightingDiffLight( SurfaceOutput s, half3 lightDir, half3 viewDir, half atten )
//		{
//			half4 c;
//			float diff = saturate(dot(s.Normal, lightDir));
//			float3 highLight = normalize(lightDir + viewDir);
//
//			float refl = 0;
//			if( diff > 0 )
//			{
//				refl = saturate(dot(s.Normal, highLight));
//				refl = pow(refl, 40.0);
//			}
//
//
//			c.rgb = ((s.Albedo * _DiffuseLightColor.rgb * diff) + refl ) * atten;
//
//			return c;
//		}

		half4 LightingDiffLight( SurfaceOutput s, half3 lightDir, half3 viewDir, half atten )
		{
			half4 c;
			float diff = saturate(dot(s.Normal, lightDir));
			float3 toonDiff = ceil((s.Albedo * diff) * 5.0) / 5.0;

			float3 highLight = normalize(lightDir + viewDir);
			float refl = 0;
			if( toonDiff.x > 0 )
			{
				refl = saturate(dot(s.Normal, highLight));
				refl = pow(refl, 40.0);
			}


			c.rgb = toonDiff + refl;


			return c;
		}

		ENDCG
	}

	Fallback "Diffuse"
}