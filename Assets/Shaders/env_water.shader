// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32924,y:32689,varname:node_4013,prsc:2|diff-598-OUT,spec-1722-OUT,normal-1156-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32199,y:32473,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2390787,c2:0.4120124,c3:0.4926471,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3677,x:32243,y:32883,ptovrint:False,ptlb:Water Normal,ptin:_WaterNormal,varname:node_3677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ad4959c21e5aef24d9b5d2c759af1331,ntxv:3,isnm:True|UVIN-4647-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8828,x:32232,y:33127,ptovrint:False,ptlb:Water Normal B,ptin:_WaterNormalB,varname:node_8828,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:92d56e089a1a00444bd3b3d18e2d5aad,ntxv:3,isnm:True|UVIN-8472-UVOUT;n:type:ShaderForge.SFN_Time,id:7807,x:31625,y:32930,varname:node_7807,prsc:2;n:type:ShaderForge.SFN_Panner,id:4647,x:32060,y:32954,varname:node_4647,prsc:2,spu:0,spv:1|UVIN-6840-UVOUT,DIST-1655-OUT;n:type:ShaderForge.SFN_TexCoord,id:6840,x:31849,y:32822,varname:node_6840,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:807,x:31781,y:33188,varname:node_807,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:8472,x:32015,y:33216,varname:node_8472,prsc:2,spu:1,spv:0|UVIN-807-UVOUT,DIST-1655-OUT;n:type:ShaderForge.SFN_Lerp,id:5982,x:32569,y:32990,varname:node_5982,prsc:2|A-3677-RGB,B-8828-RGB,T-1537-OUT;n:type:ShaderForge.SFN_Vector1,id:1537,x:32393,y:33178,varname:node_1537,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:854,x:31603,y:33140,ptovrint:False,ptlb:Water Speed,ptin:_WaterSpeed,varname:node_854,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:1655,x:31834,y:33000,varname:node_1655,prsc:2|A-7807-T,B-854-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1722,x:32446,y:32810,ptovrint:False,ptlb:Specular Value,ptin:_SpecularValue,varname:node_1722,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:3665,x:32678,y:33272,ptovrint:False,ptlb:Wake Diffuse,ptin:_WakeDiffuse,varname:node_3665,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d857a291e01fbe848beacdcc4c765896,ntxv:0,isnm:False|UVIN-4647-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4158,x:32936,y:33333,varname:node_4158,prsc:2|A-3665-RGB,B-830-B;n:type:ShaderForge.SFN_Add,id:598,x:32622,y:32485,varname:node_598,prsc:2|A-1304-RGB,B-6377-OUT;n:type:ShaderForge.SFN_Lerp,id:1156,x:32755,y:33018,varname:node_1156,prsc:2|A-5982-OUT,B-6377-OUT,T-1537-OUT;n:type:ShaderForge.SFN_Tex2d,id:1740,x:32398,y:33522,ptovrint:False,ptlb:White Water,ptin:_WhiteWater,varname:node_1740,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f44bf7d16aa36fe4e89686252ffa28bf,ntxv:0,isnm:False|UVIN-4647-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1407,x:32744,y:33532,varname:node_1407,prsc:2|A-1740-RGB,B-830-R;n:type:ShaderForge.SFN_Add,id:6377,x:33197,y:33506,varname:node_6377,prsc:2|A-4158-OUT,B-1407-OUT;n:type:ShaderForge.SFN_VertexColor,id:830,x:32235,y:33727,varname:node_830,prsc:2;proporder:1304-3677-8828-854-1722-3665-1740;pass:END;sub:END;*/

Shader "Shader Forge/env_water" {
    Properties {
        _Color ("Color", Color) = (0.2390787,0.4120124,0.4926471,1)
        _WaterNormal ("Water Normal", 2D) = "bump" {}
        _WaterNormalB ("Water Normal B", 2D) = "bump" {}
        _WaterSpeed ("Water Speed", Float ) = 0.1
        _SpecularValue ("Specular Value", Float ) = 1
        _WakeDiffuse ("Wake Diffuse", 2D) = "white" {}
        _WhiteWater ("White Water", 2D) = "white" {}
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
            uniform sampler2D _WakeDiffuse; uniform float4 _WakeDiffuse_ST;
            uniform sampler2D _WhiteWater; uniform float4 _WhiteWater_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
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
                float3 _WaterNormal_var = UnpackNormal(tex2D(_WaterNormal,TRANSFORM_TEX(node_4647, _WaterNormal)));
                float2 node_8472 = (i.uv0+node_1655*float2(1,0));
                float3 _WaterNormalB_var = UnpackNormal(tex2D(_WaterNormalB,TRANSFORM_TEX(node_8472, _WaterNormalB)));
                float node_1537 = 0.5;
                float4 _WakeDiffuse_var = tex2D(_WakeDiffuse,TRANSFORM_TEX(node_4647, _WakeDiffuse));
                float4 _WhiteWater_var = tex2D(_WhiteWater,TRANSFORM_TEX(node_4647, _WhiteWater));
                float3 node_6377 = ((_WakeDiffuse_var.rgb*i.vertexColor.b)+(_WhiteWater_var.rgb*i.vertexColor.r));
                float3 normalLocal = lerp(lerp(_WaterNormal_var.rgb,_WaterNormalB_var.rgb,node_1537),node_6377,node_1537);
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
                float3 diffuseColor = (_Color.rgb+node_6377);
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
            uniform sampler2D _WakeDiffuse; uniform float4 _WakeDiffuse_ST;
            uniform sampler2D _WhiteWater; uniform float4 _WhiteWater_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
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
                float3 _WaterNormal_var = UnpackNormal(tex2D(_WaterNormal,TRANSFORM_TEX(node_4647, _WaterNormal)));
                float2 node_8472 = (i.uv0+node_1655*float2(1,0));
                float3 _WaterNormalB_var = UnpackNormal(tex2D(_WaterNormalB,TRANSFORM_TEX(node_8472, _WaterNormalB)));
                float node_1537 = 0.5;
                float4 _WakeDiffuse_var = tex2D(_WakeDiffuse,TRANSFORM_TEX(node_4647, _WakeDiffuse));
                float4 _WhiteWater_var = tex2D(_WhiteWater,TRANSFORM_TEX(node_4647, _WhiteWater));
                float3 node_6377 = ((_WakeDiffuse_var.rgb*i.vertexColor.b)+(_WhiteWater_var.rgb*i.vertexColor.r));
                float3 normalLocal = lerp(lerp(_WaterNormal_var.rgb,_WaterNormalB_var.rgb,node_1537),node_6377,node_1537);
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
                float3 diffuseColor = (_Color.rgb+node_6377);
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
