Shader "ImageEffects/PlayerArmsOverlay"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OverlayTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _OverlayTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 overlay = tex2D(_OverlayTex, i.uv);
                fixed4 col = tex2D(_MainTex, i.uv);
                
                // Overlaying arms over an empty texture
                fixed3 result = lerp(col, overlay.rgb, overlay.a);
                
                return fixed4(result.r, result.g, result.b, 255);
            }
            ENDCG
        }
    }
}
