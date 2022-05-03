// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "2DWaterFade"
{
    Properties
    {
        [Header(Splat Map)]
        _MainTex ("Main Splat Map", 2D) = "white" {}
        _MainColor("Main Color", color) = (1,1,1,1)

        [Header(Gradient Map)]
        _FadeTex ("Gradient Texture", 2D) = "white" {}
        _FadeColor("Fade Color", color) = (1,1,1,1)

        [Header(First Wave)]
        _WaveColorRed("Wave Color 1", color) = (1,1,1,1)
        _WaveColorRed1("Wave Color Fade 1", color) = (1,1,1,1)
        _WaveSpeedRed("Wave Speed 1", Range(0.0,10)) = 1
        _WaveAmplitudeRed("Wave Amplitude 1", Range(0.0,0.1)) = 0.005

        [Header(Second Wave)]
        _WaveColorGreen("Wave Color 2", color) = (1,1,1,1)
        _WaveColorGreen1("Wave Color Fade 2", color) = (1,1,1,1)
        _WaveSpeedGreen("Wave Speed 2", Range(0.0,10)) = 1
        _WaveAmplitudeGreen("Wave Amplitude 2", Range(0.0,0.1)) = 0.005

        [Header(Third Wave)]
        _WaveColorBlue("Wave Color 3", color) = (1,1,1,1)
        _WaveColorBlue1("Wave Color Fade 3", color) = (1,1,1,1)
        _WaveSpeedBlue("Wave Speed 3", Range(0.0,10)) = 1
        _WaveAmplitudeBlue("Wave Amplitude 3", Range(0.0,0.1)) = 0.005

        [Header(Camera Position)]
        _MaxCameraPos("Max Camera Position", float) = 10
        _MinCameraPos("Min Camera Position", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 posWorld : TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _FadeTex;
            float4 _FadeTex_ST;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float2 UvMovement(float2 uv, float speed, float amp)
            {
                //sine time
                float sinTime = sin(_Time.y * speed);

                //Update uvs
                float2 movedUV = uv; 
                movedUV.y += sinTime * amp * movedUV.y;
                movedUV.x -= sinTime * amp * 2 * movedUV.x;

                return movedUV;
            }


            float4 _MainColor;
            float4 _FadeColor;

            float4 _WaveColorRed;
            float4 _WaveColorRed1;
            float _WaveSpeedRed;

            float4 _WaveColorGreen;
            float4 _WaveColorGreen1;
            float _WaveSpeedGreen;

            float4 _WaveColorBlue;
            float4 _WaveColorBlue1;
            float _WaveSpeedBlue;

            float _MaxCameraPos;
            float _MinCameraPos;

            float _WaveAmplitudeRed;
            float _WaveAmplitudeGreen;
            float _WaveAmplitudeBlue;

            fixed4 frag (v2f i) : SV_Target
            {
     
                //Red channel
                float2 redUV = UvMovement(i.uv, _WaveSpeedRed, _WaveAmplitudeRed);
                fixed4 red = tex2D(_MainTex, redUV).r;
                //Fade Red
                fixed4 redFade = tex2D(_FadeTex, i.uv)*red; 

                //Scaled distance value
                float distancePixelCamera = length(i.posWorld.xyz - _WorldSpaceCameraPos.xyz);
                float scaledValue = (distancePixelCamera - _MinCameraPos) / (_MaxCameraPos - _MinCameraPos);

                if(scaledValue < 0.0f)
                    scaledValue = 0.0f;
                else if(scaledValue > 1)
                    scaledValue = 1;
                    
                fixed4 coloredRedFade = lerp(_WaveColorRed, _WaveColorRed1, redFade);
                coloredRedFade = lerp(_FadeColor, coloredRedFade, scaledValue);
            
                //mask colored fade
                coloredRedFade *= red;

                //Green channel
                float2 greenUV = UvMovement(i.uv, _WaveSpeedGreen, _WaveAmplitudeGreen);
                fixed4 green = tex2D(_MainTex, greenUV).g;
                //Fade Red
                fixed4 greenFade = tex2D(_FadeTex, i.uv)*green; 
                fixed4 coloredGreenFade = lerp(_WaveColorGreen, _WaveColorGreen1, greenFade);
                coloredGreenFade = lerp(_FadeColor, coloredGreenFade,scaledValue);
            
                //mask colored fade
                coloredGreenFade *= green;

                //Blue channel
                float2 blueUV = UvMovement(i.uv, _WaveSpeedBlue, _WaveAmplitudeBlue);
                fixed4 blue = tex2D(_MainTex, blueUV).b;
                //Fade Red
                fixed4 blueFade = tex2D(_FadeTex, i.uv)*blue; 
                fixed4 coloredBlueFade = lerp(_WaveColorBlue, _WaveColorBlue1, blueFade);
                coloredBlueFade = lerp(_FadeColor, coloredBlueFade,scaledValue);
            
                //mask colored fade
                coloredBlueFade *= blue;

                //Mix mask
                float4 mixMask = coloredRedFade + coloredGreenFade + coloredBlueFade;

                // inverse Mask
                float4 inverseMask = (( tex2D(_MainTex, i.uv).r + tex2D(_MainTex, i.uv).g + tex2D(_MainTex, i.uv).b )) ;
                //inverseMask *= _MainColor;

                float4 result = (1 - (red + green + blue)) * float4(0.31,0.32,0.39,1) + (coloredRedFade) + coloredGreenFade + coloredBlueFade;
                float4 mixLines = result * inverseMask;

                float4 reverseMask = (1 - inverseMask) * _MainColor;

                mixLines += reverseMask;
 
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, mixLines);
                return mixLines;
            }
            ENDCG
        }
    }
}
