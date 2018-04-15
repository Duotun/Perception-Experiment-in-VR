// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "InnuendoGameLabs/Standard/Ceramic Tile and Grout" {
    Properties {
        _TileDiffuse ("Tile Diffuse", 2D) = "white" {}
        _SpecularTexture2D ("Specular (Texture2D)", 2D) = "gray" {}
        _SpecularMultiplierClamped010 ("Specular Multiplier [Clamped 0-10]", Float ) = 1.72
        _Glossiness01 ("Glossiness [0-1]", Range(0, 1)) = 0.2735043
        _GroutMask ("Grout Mask", 2D) = "white" {}
        _GroutColor ("Grout Color", Color) = (0.1500006,0.003448308,1,1)
        _NormalTexture2D ("Normal (Texture2D)", 2D) = "black" {}
        _NormalStrengthClamped02 ("Normal Strength [Clamped 0-2]", Float ) = 0.28
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _TileDiffuse; uniform float4 _TileDiffuse_ST;
            uniform sampler2D _SpecularTexture2D; uniform float4 _SpecularTexture2D_ST;
            uniform sampler2D _NormalTexture2D; uniform float4 _NormalTexture2D_ST;
            uniform float _Glossiness01;
            uniform float _SpecularMultiplierClamped010;
            uniform float _NormalStrengthClamped02;
            uniform sampler2D _GroutMask; uniform float4 _GroutMask_ST;
            uniform float4 _GroutColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _NormalTexture2D_var = tex2D(_NormalTexture2D,TRANSFORM_TEX(i.uv0, _NormalTexture2D));
                float3 normalLocal = lerp(float3(0,0,1),_NormalTexture2D_var.rgb,clamp(_NormalStrengthClamped02,0.0,2.0));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Glossiness01;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _GroutMask_var = tex2D(_GroutMask,TRANSFORM_TEX(i.uv0, _GroutMask));
                float4 _SpecularTexture2D_var = tex2D(_SpecularTexture2D,TRANSFORM_TEX(i.uv0, _SpecularTexture2D));
                float3 specularColor = lerp(_GroutMask_var.rgb,(_SpecularTexture2D_var.rgb*clamp(_SpecularMultiplierClamped010,0.0,10.0)),0.5);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Diffuse Ambient Light
                float3 node_5025 = (_GroutMask_var.rgb*-1.0+1.0);
                float3 node_5876 = (_GroutColor.rgb*node_5025);
                float4 _TileDiffuse_var = tex2D(_TileDiffuse,TRANSFORM_TEX(i.uv0, _TileDiffuse));
                float3 diffuse = (directDiffuse + indirectDiffuse) * (node_5876+((node_5876+(lerp( lerp( lerp( _TileDiffuse_var.rgb.r, _GroutMask_var.r, node_5025.r ), _GroutMask_var.g, node_5025.g ), _GroutMask_var.b, node_5025.b )))+_TileDiffuse_var.rgb));
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _TileDiffuse; uniform float4 _TileDiffuse_ST;
            uniform sampler2D _SpecularTexture2D; uniform float4 _SpecularTexture2D_ST;
            uniform sampler2D _NormalTexture2D; uniform float4 _NormalTexture2D_ST;
            uniform float _Glossiness01;
            uniform float _SpecularMultiplierClamped010;
            uniform float _NormalStrengthClamped02;
            uniform sampler2D _GroutMask; uniform float4 _GroutMask_ST;
            uniform float4 _GroutColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _NormalTexture2D_var = tex2D(_NormalTexture2D,TRANSFORM_TEX(i.uv0, _NormalTexture2D));
                float3 normalLocal = lerp(float3(0,0,1),_NormalTexture2D_var.rgb,clamp(_NormalStrengthClamped02,0.0,2.0));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Glossiness01;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _GroutMask_var = tex2D(_GroutMask,TRANSFORM_TEX(i.uv0, _GroutMask));
                float4 _SpecularTexture2D_var = tex2D(_SpecularTexture2D,TRANSFORM_TEX(i.uv0, _SpecularTexture2D));
                float3 specularColor = lerp(_GroutMask_var.rgb,(_SpecularTexture2D_var.rgb*clamp(_SpecularMultiplierClamped010,0.0,10.0)),0.5);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 node_5025 = (_GroutMask_var.rgb*-1.0+1.0);
                float3 node_5876 = (_GroutColor.rgb*node_5025);
                float4 _TileDiffuse_var = tex2D(_TileDiffuse,TRANSFORM_TEX(i.uv0, _TileDiffuse));
                float3 diffuse = directDiffuse * (node_5876+((node_5876+(lerp( lerp( lerp( _TileDiffuse_var.rgb.r, _GroutMask_var.r, node_5025.r ), _GroutMask_var.g, node_5025.g ), _GroutMask_var.b, node_5025.b )))+_TileDiffuse_var.rgb));
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
