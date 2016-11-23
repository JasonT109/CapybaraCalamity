// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33478,y:32989,varname:node_4013,prsc:2|diff-5672-OUT,normal-8147-OUT;n:type:ShaderForge.SFN_Tex2d,id:8713,x:32444,y:33216,ptovrint:False,ptlb:Snow Diffuse,ptin:_SnowDiffuse,varname:node_8713,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:129240abd50f6804bb1ede2bb084d25a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9286,x:32444,y:32999,ptovrint:False,ptlb:Rock Diffuse,ptin:_RockDiffuse,varname:node_9286,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3c90807ca57d9914b8a0e9b524616576,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7544,x:32444,y:32775,ptovrint:False,ptlb:Forest Diffuse,ptin:_ForestDiffuse,varname:node_7544,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9db591f21a5ae514194fd09c7300c5ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:1315,x:32685,y:33109,varname:node_1315,prsc:2|A-9286-RGB,B-8713-RGB,T-995-OUT;n:type:ShaderForge.SFN_Lerp,id:4892,x:32755,y:32889,varname:node_4892,prsc:2|A-7544-RGB,B-1315-OUT,T-3164-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3164,x:32232,y:32979,varname:node_3164,prsc:2|IN-9970-Y,IMIN-5657-Y,IMAX-18-OUT,OMIN-8331-OUT,OMAX-1052-OUT;n:type:ShaderForge.SFN_Vector1,id:8331,x:32026,y:32979,varname:node_8331,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1052,x:32026,y:33058,varname:node_1052,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:6674,x:32026,y:32885,ptovrint:False,ptlb:Rock Height,ptin:_RockHeight,varname:node_6674,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:995,x:32232,y:32792,varname:node_995,prsc:2|IN-9970-Y,IMIN-6674-OUT,IMAX-18-OUT,OMIN-8331-OUT,OMAX-1052-OUT;n:type:ShaderForge.SFN_ValueProperty,id:18,x:32026,y:32788,ptovrint:False,ptlb:Snow Height,ptin:_SnowHeight,varname:node_18,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:7;n:type:ShaderForge.SFN_FragmentPosition,id:9970,x:31881,y:32788,varname:node_9970,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:5657,x:31881,y:32957,varname:node_5657,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:5143,x:32444,y:33412,ptovrint:False,ptlb:Forest Normal,ptin:_ForestNormal,varname:node_5143,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:299,x:32444,y:33609,ptovrint:False,ptlb:Rock Normal,ptin:_RockNormal,varname:node_299,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:11cb714188e71be4aa0b424b374a40aa,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7481,x:32444,y:33812,ptovrint:False,ptlb:Snow Normal,ptin:_SnowNormal,varname:node_7481,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4e817727ad23ad74795b82d50a6553e3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:2011,x:32657,y:33687,varname:node_2011,prsc:2|A-299-RGB,B-7481-RGB,T-995-OUT;n:type:ShaderForge.SFN_Lerp,id:8147,x:32749,y:33441,varname:node_8147,prsc:2|A-5143-RGB,B-2011-OUT,T-3164-OUT;n:type:ShaderForge.SFN_Fresnel,id:4388,x:33239,y:32692,varname:node_4388,prsc:2|NRM-8960-OUT,EXP-601-OUT;n:type:ShaderForge.SFN_NormalVector,id:8960,x:32902,y:32606,prsc:2,pt:False;n:type:ShaderForge.SFN_ValueProperty,id:601,x:33000,y:32800,ptovrint:False,ptlb:Fresnel Exponent,ptin:_FresnelExponent,varname:node_601,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Lerp,id:5672,x:33168,y:33033,varname:node_5672,prsc:2|A-4892-OUT,B-4388-OUT,T-4016-OUT;n:type:ShaderForge.SFN_Vector1,id:4016,x:32960,y:33136,varname:node_4016,prsc:2,v1:0.2;proporder:6674-18-601-8713-9286-7544-5143-299-7481;pass:END;sub:END;*/

Shader "Shader Forge/env_mountain" {
    Properties {
        _RockHeight ("Rock Height", Float ) = 2
        _SnowHeight ("Snow Height", Float ) = 7
        _FresnelExponent ("Fresnel Exponent", Float ) = 8
        _SnowDiffuse ("Snow Diffuse", 2D) = "white" {}
        _RockDiffuse ("Rock Diffuse", 2D) = "white" {}
        _ForestDiffuse ("Forest Diffuse", 2D) = "white" {}
        _ForestNormal ("Forest Normal", 2D) = "white" {}
        _RockNormal ("Rock Normal", 2D) = "white" {}
        _SnowNormal ("Snow Normal", 2D) = "white" {}
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
            uniform sampler2D _SnowDiffuse; uniform float4 _SnowDiffuse_ST;
            uniform sampler2D _RockDiffuse; uniform float4 _RockDiffuse_ST;
            uniform sampler2D _ForestDiffuse; uniform float4 _ForestDiffuse_ST;
            uniform float _RockHeight;
            uniform float _SnowHeight;
            uniform sampler2D _ForestNormal; uniform float4 _ForestNormal_ST;
            uniform sampler2D _RockNormal; uniform float4 _RockNormal_ST;
            uniform sampler2D _SnowNormal; uniform float4 _SnowNormal_ST;
            uniform float _FresnelExponent;
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
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _ForestNormal_var = tex2D(_ForestNormal,TRANSFORM_TEX(i.uv0, _ForestNormal));
                float4 _RockNormal_var = tex2D(_RockNormal,TRANSFORM_TEX(i.uv0, _RockNormal));
                float4 _SnowNormal_var = tex2D(_SnowNormal,TRANSFORM_TEX(i.uv0, _SnowNormal));
                float node_8331 = 0.0;
                float node_1052 = 1.0;
                float node_995 = (node_8331 + ( (i.posWorld.g - _RockHeight) * (node_1052 - node_8331) ) / (_SnowHeight - _RockHeight));
                float node_3164 = (node_8331 + ( (i.posWorld.g - objPos.g) * (node_1052 - node_8331) ) / (_SnowHeight - objPos.g));
                float3 normalLocal = lerp(_ForestNormal_var.rgb,lerp(_RockNormal_var.rgb,_SnowNormal_var.rgb,node_995),node_3164);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _ForestDiffuse_var = tex2D(_ForestDiffuse,TRANSFORM_TEX(i.uv0, _ForestDiffuse));
                float4 _RockDiffuse_var = tex2D(_RockDiffuse,TRANSFORM_TEX(i.uv0, _RockDiffuse));
                float4 _SnowDiffuse_var = tex2D(_SnowDiffuse,TRANSFORM_TEX(i.uv0, _SnowDiffuse));
                float node_4388 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_FresnelExponent);
                float3 diffuseColor = lerp(lerp(_ForestDiffuse_var.rgb,lerp(_RockDiffuse_var.rgb,_SnowDiffuse_var.rgb,node_995),node_3164),float3(node_4388,node_4388,node_4388),0.2);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
            uniform sampler2D _SnowDiffuse; uniform float4 _SnowDiffuse_ST;
            uniform sampler2D _RockDiffuse; uniform float4 _RockDiffuse_ST;
            uniform sampler2D _ForestDiffuse; uniform float4 _ForestDiffuse_ST;
            uniform float _RockHeight;
            uniform float _SnowHeight;
            uniform sampler2D _ForestNormal; uniform float4 _ForestNormal_ST;
            uniform sampler2D _RockNormal; uniform float4 _RockNormal_ST;
            uniform sampler2D _SnowNormal; uniform float4 _SnowNormal_ST;
            uniform float _FresnelExponent;
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
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _ForestNormal_var = tex2D(_ForestNormal,TRANSFORM_TEX(i.uv0, _ForestNormal));
                float4 _RockNormal_var = tex2D(_RockNormal,TRANSFORM_TEX(i.uv0, _RockNormal));
                float4 _SnowNormal_var = tex2D(_SnowNormal,TRANSFORM_TEX(i.uv0, _SnowNormal));
                float node_8331 = 0.0;
                float node_1052 = 1.0;
                float node_995 = (node_8331 + ( (i.posWorld.g - _RockHeight) * (node_1052 - node_8331) ) / (_SnowHeight - _RockHeight));
                float node_3164 = (node_8331 + ( (i.posWorld.g - objPos.g) * (node_1052 - node_8331) ) / (_SnowHeight - objPos.g));
                float3 normalLocal = lerp(_ForestNormal_var.rgb,lerp(_RockNormal_var.rgb,_SnowNormal_var.rgb,node_995),node_3164);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _ForestDiffuse_var = tex2D(_ForestDiffuse,TRANSFORM_TEX(i.uv0, _ForestDiffuse));
                float4 _RockDiffuse_var = tex2D(_RockDiffuse,TRANSFORM_TEX(i.uv0, _RockDiffuse));
                float4 _SnowDiffuse_var = tex2D(_SnowDiffuse,TRANSFORM_TEX(i.uv0, _SnowDiffuse));
                float node_4388 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_FresnelExponent);
                float3 diffuseColor = lerp(lerp(_ForestDiffuse_var.rgb,lerp(_RockDiffuse_var.rgb,_SnowDiffuse_var.rgb,node_995),node_3164),float3(node_4388,node_4388,node_4388),0.2);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
