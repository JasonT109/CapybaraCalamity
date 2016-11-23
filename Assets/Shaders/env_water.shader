// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32836,y:32695,varname:node_4013,prsc:2|diff-1304-RGB,spec-1722-OUT,normal-5982-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32238,y:32543,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2390787,c2:0.4120124,c3:0.4926471,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3677,x:32243,y:32883,ptovrint:False,ptlb:Water Normal,ptin:_WaterNormal,varname:node_3677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ad4959c21e5aef24d9b5d2c759af1331,ntxv:0,isnm:False|UVIN-4647-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8828,x:32232,y:33127,ptovrint:False,ptlb:Water Normal B,ptin:_WaterNormalB,varname:node_8828,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:92d56e089a1a00444bd3b3d18e2d5aad,ntxv:0,isnm:False|UVIN-8472-UVOUT;n:type:ShaderForge.SFN_Time,id:7807,x:31625,y:32930,varname:node_7807,prsc:2;n:type:ShaderForge.SFN_Panner,id:4647,x:32060,y:32954,varname:node_4647,prsc:2,spu:0,spv:1|UVIN-6840-UVOUT,DIST-1655-OUT;n:type:ShaderForge.SFN_TexCoord,id:6840,x:31849,y:32822,varname:node_6840,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:807,x:31781,y:33188,varname:node_807,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:8472,x:32015,y:33216,varname:node_8472,prsc:2,spu:1,spv:0|UVIN-807-UVOUT,DIST-1655-OUT;n:type:ShaderForge.SFN_Lerp,id:5982,x:32569,y:32990,varname:node_5982,prsc:2|A-3677-RGB,B-8828-RGB,T-1537-OUT;n:type:ShaderForge.SFN_Vector1,id:1537,x:32393,y:33178,varname:node_1537,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:854,x:31603,y:33140,ptovrint:False,ptlb:Water Speed,ptin:_WaterSpeed,varname:node_854,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:1655,x:31834,y:33000,varname:node_1655,prsc:2|A-7807-T,B-854-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1722,x:32446,y:32810,ptovrint:False,ptlb:Specular Value,ptin:_SpecularValue,varname:node_1722,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:1304-3677-8828-854-1722;pass:END;sub:END;*/

Shader "Shader Forge/env_water" {
    Properties {
        _Color ("Color", Color) = (0.2390787,0.4120124,0.4926471,1)
        _WaterNormal ("Water Normal", 2D) = "white" {}
        _WaterNormalB ("Water Normal B", 2D) = "white" {}
        _WaterSpeed ("Water Speed", Float ) = 0.1
        _SpecularValue ("Specular Value", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
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
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _WaterNormal; uniform float4 _WaterNormal_ST;
            uniform sampler2D _WaterNormalB; uniform float4 _WaterNormalB_ST;
            uniform float _WaterSpeed;
            uniform float _SpecularValue;
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
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_7807 = _Time + _TimeEditor;
                float node_1655 = (node_7807.g*_WaterSpeed);
                float2 node_4647 = (i.uv0+node_1655*float2(0,1));
                float4 _WaterNormal_var = tex2D(_WaterNormal,TRANSFORM_TEX(node_4647, _WaterNormal));
                float2 node_8472 = (i.uv0+node_1655*float2(1,0));
                float4 _WaterNormalB_var = tex2D(_WaterNormalB,TRANSFORM_TEX(node_8472, _WaterNormalB));
                float3 normalLocal = lerp(_WaterNormal_var.rgb,_WaterNormalB_var.rgb,0.5);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_SpecularValue,_SpecularValue,_SpecularValue);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _WaterNormal; uniform float4 _WaterNormal_ST;
            uniform sampler2D _WaterNormalB; uniform float4 _WaterNormalB_ST;
            uniform float _WaterSpeed;
            uniform float _SpecularValue;
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
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_7807 = _Time + _TimeEditor;
                float node_1655 = (node_7807.g*_WaterSpeed);
                float2 node_4647 = (i.uv0+node_1655*float2(0,1));
                float4 _WaterNormal_var = tex2D(_WaterNormal,TRANSFORM_TEX(node_4647, _WaterNormal));
                float2 node_8472 = (i.uv0+node_1655*float2(1,0));
                float4 _WaterNormalB_var = tex2D(_WaterNormalB,TRANSFORM_TEX(node_8472, _WaterNormalB));
                float3 normalLocal = lerp(_WaterNormal_var.rgb,_WaterNormalB_var.rgb,0.5);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_SpecularValue,_SpecularValue,_SpecularValue);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
