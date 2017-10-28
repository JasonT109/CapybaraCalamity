// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33478,y:32989,varname:node_4013,prsc:2|diff-4892-OUT,normal-8147-OUT,emission-9432-OUT;n:type:ShaderForge.SFN_Tex2d,id:8713,x:32444,y:33216,ptovrint:False,ptlb:Snow Diffuse,ptin:_SnowDiffuse,varname:node_8713,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:129240abd50f6804bb1ede2bb084d25a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9286,x:32444,y:32999,ptovrint:False,ptlb:Rock Diffuse,ptin:_RockDiffuse,varname:node_9286,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3c90807ca57d9914b8a0e9b524616576,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7544,x:32444,y:32744,ptovrint:False,ptlb:Forest Diffuse,ptin:_ForestDiffuse,varname:node_7544,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9db591f21a5ae514194fd09c7300c5ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:1315,x:32685,y:33109,varname:node_1315,prsc:2|A-9286-RGB,B-8713-RGB,T-176-OUT;n:type:ShaderForge.SFN_Lerp,id:4892,x:32772,y:32813,varname:node_4892,prsc:2|A-7544-RGB,B-1315-OUT,T-3098-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3164,x:31840,y:33275,varname:node_3164,prsc:2|IN-9970-Y,IMIN-1969-OUT,IMAX-18-OUT,OMIN-8331-OUT,OMAX-1052-OUT;n:type:ShaderForge.SFN_Vector1,id:8331,x:31634,y:33275,varname:node_8331,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1052,x:31634,y:33354,varname:node_1052,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:6674,x:31618,y:33797,ptovrint:False,ptlb:Rock Height,ptin:_RockHeight,varname:node_6674,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:995,x:31825,y:33666,varname:node_995,prsc:2|IN-9970-Y,IMIN-6674-OUT,IMAX-18-OUT,OMIN-8331-OUT,OMAX-1052-OUT;n:type:ShaderForge.SFN_ValueProperty,id:18,x:31618,y:33700,ptovrint:False,ptlb:Snow Height,ptin:_SnowHeight,varname:node_18,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:7;n:type:ShaderForge.SFN_FragmentPosition,id:9970,x:31405,y:33463,varname:node_9970,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:5657,x:31592,y:32894,varname:node_5657,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:5143,x:32285,y:33327,ptovrint:False,ptlb:Forest Normal,ptin:_ForestNormal,varname:node_5143,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ff798018777c17d49a720506fd6c9df6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:299,x:32285,y:33607,ptovrint:False,ptlb:Rock Normal,ptin:_RockNormal,varname:node_299,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:11cb714188e71be4aa0b424b374a40aa,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:7481,x:32285,y:33898,ptovrint:False,ptlb:Snow Normal,ptin:_SnowNormal,varname:node_7481,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4e817727ad23ad74795b82d50a6553e3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Lerp,id:2011,x:32660,y:33687,varname:node_2011,prsc:2|A-299-RGB,B-7481-RGB,T-176-OUT;n:type:ShaderForge.SFN_Lerp,id:8147,x:32749,y:33441,varname:node_8147,prsc:2|A-5143-RGB,B-2011-OUT,T-3098-OUT;n:type:ShaderForge.SFN_Fresnel,id:4388,x:33285,y:32720,varname:node_4388,prsc:2|NRM-8960-OUT,EXP-601-OUT;n:type:ShaderForge.SFN_NormalVector,id:8960,x:33000,y:32559,prsc:2,pt:False;n:type:ShaderForge.SFN_ValueProperty,id:601,x:33000,y:32740,ptovrint:False,ptlb:Fresnel Exponent,ptin:_FresnelExponent,varname:node_601,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_ValueProperty,id:1969,x:31592,y:33179,ptovrint:False,ptlb:ForestHeight,ptin:_ForestHeight,varname:node_1969,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Smoothstep,id:3098,x:32116,y:32998,varname:node_3098,prsc:2|A-6140-OUT,B-1845-OUT,V-3164-OUT;n:type:ShaderForge.SFN_Smoothstep,id:176,x:32039,y:33463,varname:node_176,prsc:2|A-6140-OUT,B-1845-OUT,V-995-OUT;n:type:ShaderForge.SFN_Multiply,id:1277,x:33566,y:32704,varname:node_1277,prsc:2|A-3213-RGB,B-4388-OUT;n:type:ShaderForge.SFN_Multiply,id:9432,x:33095,y:32983,varname:node_9432,prsc:2|A-1277-OUT,B-6992-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6992,x:32894,y:33003,ptovrint:False,ptlb:Fresnel Power,ptin:_FresnelPower,varname:node_6992,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Color,id:3213,x:33285,y:32508,ptovrint:False,ptlb:Fresnel Color,ptin:_FresnelColor,varname:node_3213,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8235294,c2:0.8235294,c3:0.8235294,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:6140,x:31734,y:32765,ptovrint:False,ptlb:BlendStart,ptin:_BlendStart,varname:node_6140,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.4;n:type:ShaderForge.SFN_ValueProperty,id:1845,x:31734,y:32858,ptovrint:False,ptlb:BlendEnd,ptin:_BlendEnd,varname:node_1845,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.6;proporder:1969-6674-18-6140-1845-601-6992-3213-8713-9286-7544-5143-299-7481;pass:END;sub:END;*/

Shader "Shader Forge/env_mountain" {
    Properties {
        _ForestHeight ("ForestHeight", Float ) = 0
        _RockHeight ("Rock Height", Float ) = 2
        _SnowHeight ("Snow Height", Float ) = 7
        _BlendStart ("BlendStart", Float ) = 0.4
        _BlendEnd ("BlendEnd", Float ) = 0.6
        _FresnelExponent ("Fresnel Exponent", Float ) = 8
        _FresnelPower ("Fresnel Power", Float ) = 0.2
        _FresnelColor ("Fresnel Color", Color) = (0.8235294,0.8235294,0.8235294,1)
        _SnowDiffuse ("Snow Diffuse", 2D) = "white" {}
        _RockDiffuse ("Rock Diffuse", 2D) = "white" {}
        _ForestDiffuse ("Forest Diffuse", 2D) = "white" {}
        _ForestNormal ("Forest Normal", 2D) = "bump" {}
        _RockNormal ("Rock Normal", 2D) = "bump" {}
        _SnowNormal ("Snow Normal", 2D) = "bump" {}
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
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
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
            uniform float _ForestHeight;
            uniform float _FresnelPower;
            uniform float4 _FresnelColor;
            uniform float _BlendStart;
            uniform float _BlendEnd;
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
                float3 _ForestNormal_var = UnpackNormal(tex2D(_ForestNormal,TRANSFORM_TEX(i.uv0, _ForestNormal)));
                float3 _RockNormal_var = UnpackNormal(tex2D(_RockNormal,TRANSFORM_TEX(i.uv0, _RockNormal)));
                float3 _SnowNormal_var = UnpackNormal(tex2D(_SnowNormal,TRANSFORM_TEX(i.uv0, _SnowNormal)));
                float node_8331 = 0.0;
                float node_1052 = 1.0;
                float node_176 = smoothstep( _BlendStart, _BlendEnd, (node_8331 + ( (i.posWorld.g - _RockHeight) * (node_1052 - node_8331) ) / (_SnowHeight - _RockHeight)) );
                float node_3098 = smoothstep( _BlendStart, _BlendEnd, (node_8331 + ( (i.posWorld.g - _ForestHeight) * (node_1052 - node_8331) ) / (_SnowHeight - _ForestHeight)) );
                float3 normalLocal = lerp(_ForestNormal_var.rgb,lerp(_RockNormal_var.rgb,_SnowNormal_var.rgb,node_176),node_3098);
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
                float3 diffuseColor = lerp(_ForestDiffuse_var.rgb,lerp(_RockDiffuse_var.rgb,_SnowDiffuse_var.rgb,node_176),node_3098);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = ((_FresnelColor.rgb*pow(1.0-max(0,dot(i.normalDir, viewDirection)),_FresnelExponent))*_FresnelPower);
/// Final Color:
                float3 finalColor = diffuse + emissive;
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
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
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
            uniform float _ForestHeight;
            uniform float _FresnelPower;
            uniform float4 _FresnelColor;
            uniform float _BlendStart;
            uniform float _BlendEnd;
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
                float3 _ForestNormal_var = UnpackNormal(tex2D(_ForestNormal,TRANSFORM_TEX(i.uv0, _ForestNormal)));
                float3 _RockNormal_var = UnpackNormal(tex2D(_RockNormal,TRANSFORM_TEX(i.uv0, _RockNormal)));
                float3 _SnowNormal_var = UnpackNormal(tex2D(_SnowNormal,TRANSFORM_TEX(i.uv0, _SnowNormal)));
                float node_8331 = 0.0;
                float node_1052 = 1.0;
                float node_176 = smoothstep( _BlendStart, _BlendEnd, (node_8331 + ( (i.posWorld.g - _RockHeight) * (node_1052 - node_8331) ) / (_SnowHeight - _RockHeight)) );
                float node_3098 = smoothstep( _BlendStart, _BlendEnd, (node_8331 + ( (i.posWorld.g - _ForestHeight) * (node_1052 - node_8331) ) / (_SnowHeight - _ForestHeight)) );
                float3 normalLocal = lerp(_ForestNormal_var.rgb,lerp(_RockNormal_var.rgb,_SnowNormal_var.rgb,node_176),node_3098);
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
                float3 diffuseColor = lerp(_ForestDiffuse_var.rgb,lerp(_RockDiffuse_var.rgb,_SnowDiffuse_var.rgb,node_176),node_3098);
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
