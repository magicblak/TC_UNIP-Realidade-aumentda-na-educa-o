// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-6-OUT,spec-53-OUT,normal-38-OUT,emission-651-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33787,y:32556,ptlb:Lava - DIFF+SL,ptin:_LavaDIFFSL,tex:ab0a98f019a14cb418fa0c42fc6f9b6d,ntxv:0,isnm:False|UVIN-25-UVOUT;n:type:ShaderForge.SFN_VertexColor,id:4,x:34475,y:33107;n:type:ShaderForge.SFN_Lerp,id:6,x:33150,y:32714|A-7-OUT,B-9-RGB,T-4-G;n:type:ShaderForge.SFN_Lerp,id:7,x:33364,y:32531|A-8-RGB,B-2-RGB,T-4-R;n:type:ShaderForge.SFN_Tex2d,id:8,x:33776,y:32359,ptlb:Sand - DIFF+SL,ptin:_SandDIFFSL,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9,x:33469,y:32680,ptlb:Grass - DIFF+SL,ptin:_GrassDIFFSL,tex:a095673f64387af46952210209a46a9a,ntxv:0,isnm:False|UVIN-17-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:17,x:33924,y:32734,uv:0;n:type:ShaderForge.SFN_Panner,id:25,x:34169,y:32426,spu:0.01,spv:0.01;n:type:ShaderForge.SFN_Lerp,id:38,x:33094,y:33288|A-39-OUT,B-40-RGB,T-4-G;n:type:ShaderForge.SFN_Lerp,id:39,x:33577,y:33454|A-41-RGB,B-42-RGB,T-4-R;n:type:ShaderForge.SFN_Tex2d,id:40,x:33674,y:33655,ptlb:Grass- Normal,ptin:_GrassNormal,tex:4e3386d4a54363b4e80604e5087e2dc7,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:41,x:33882,y:33268,ptlb:Sand - Normal,ptin:_SandNormal,tex:ab725f1cdf0598b4097fca9e4e8e9670,ntxv:3,isnm:True|UVIN-522-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:42,x:33896,y:33474,ptlb:Lava - Normal,ptin:_LavaNormal,tex:e1532d36b0fa9904986b93d6ce5dabb3,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Lerp,id:53,x:33104,y:33037|A-54-OUT,B-9-A,T-4-G;n:type:ShaderForge.SFN_Lerp,id:54,x:33315,y:32916|A-185-OUT,B-2-A,T-4-R;n:type:ShaderForge.SFN_Multiply,id:185,x:33518,y:32913|A-8-A,B-186-OUT;n:type:ShaderForge.SFN_Vector3,id:186,x:33716,y:32913,v1:0.2279412,v2:0.2279412,v3:0.2279412;n:type:ShaderForge.SFN_TexCoord,id:522,x:34292,y:33298,uv:0;n:type:ShaderForge.SFN_Lerp,id:637,x:33219,y:32329|A-638-OUT,B-639-OUT,T-4-R;n:type:ShaderForge.SFN_Vector3,id:638,x:33409,y:32251,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Vector3,id:639,x:33409,y:32329,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Multiply,id:651,x:32891,y:32314|A-637-OUT,B-683-OUT;n:type:ShaderForge.SFN_Fresnel,id:664,x:33186,y:32464;n:type:ShaderForge.SFN_Multiply,id:683,x:32984,y:32504|A-664-OUT,B-6-OUT;proporder:2-8-9-40-41-42;pass:END;sub:END;*/

Shader "Shader Forge/vulcano" {
    Properties {
        _LavaDIFFSL ("Lava - DIFF+SL", 2D) = "white" {}
        _SandDIFFSL ("Sand - DIFF+SL", 2D) = "white" {}
        _GrassDIFFSL ("Grass - DIFF+SL", 2D) = "white" {}
        _GrassNormal ("Grass- Normal", 2D) = "bump" {}
        _SandNormal ("Sand - Normal", 2D) = "bump" {}
        _LavaNormal ("Lava - Normal", 2D) = "bump" {}
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
            uniform float4 _TimeEditor;
            uniform sampler2D _LavaDIFFSL; uniform float4 _LavaDIFFSL_ST;
            uniform sampler2D _SandDIFFSL; uniform float4 _SandDIFFSL_ST;
            uniform sampler2D _GrassDIFFSL; uniform float4 _GrassDIFFSL_ST;
            uniform sampler2D _GrassNormal; uniform float4 _GrassNormal_ST;
            uniform sampler2D _SandNormal; uniform float4 _SandNormal_ST;
            uniform sampler2D _LavaNormal; uniform float4 _LavaNormal_ST;
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
                float3 binormalDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_522 = i.uv0;
                float2 node_700 = i.uv0;
                float4 node_4 = i.vertexColor;
                float3 normalLocal = lerp(lerp(UnpackNormal(tex2D(_SandNormal,TRANSFORM_TEX(node_522.rg, _SandNormal))).rgb,UnpackNormal(tex2D(_LavaNormal,TRANSFORM_TEX(node_700.rg, _LavaNormal))).rgb,node_4.r),UnpackNormal(tex2D(_GrassNormal,TRANSFORM_TEX(node_700.rg, _GrassNormal))).rgb,node_4.g);
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
////// Emissive:
                float3 node_637 = lerp(float3(0,0,0),float3(1,1,1),node_4.r);
                float4 node_8 = tex2D(_SandDIFFSL,TRANSFORM_TEX(node_700.rg, _SandDIFFSL));
                float4 node_701 = _Time + _TimeEditor;
                float2 node_25 = (node_700.rg+node_701.g*float2(0.01,0.01));
                float4 node_2 = tex2D(_LavaDIFFSL,TRANSFORM_TEX(node_25, _LavaDIFFSL));
                float3 node_7 = lerp(node_8.rgb,node_2.rgb,node_4.r);
                float2 node_17 = i.uv0;
                float4 node_9 = tex2D(_GrassDIFFSL,TRANSFORM_TEX(node_17.rg, _GrassDIFFSL));
                float3 node_6 = lerp(node_7,node_9.rgb,node_4.g);
                float3 emissive = (node_637*((1.0-max(0,dot(normalDirection, viewDirection)))*node_6));
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = lerp(lerp((node_8.a*float3(0.2279412,0.2279412,0.2279412)),float3(node_2.a,node_2.a,node_2.a),node_4.r),float3(node_9.a,node_9.a,node_9.a),node_4.g);
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * node_6;
                finalColor += specular;
                finalColor += emissive;
/// Final Color:
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
            uniform float4 _TimeEditor;
            uniform sampler2D _LavaDIFFSL; uniform float4 _LavaDIFFSL_ST;
            uniform sampler2D _SandDIFFSL; uniform float4 _SandDIFFSL_ST;
            uniform sampler2D _GrassDIFFSL; uniform float4 _GrassDIFFSL_ST;
            uniform sampler2D _GrassNormal; uniform float4 _GrassNormal_ST;
            uniform sampler2D _SandNormal; uniform float4 _SandNormal_ST;
            uniform sampler2D _LavaNormal; uniform float4 _LavaNormal_ST;
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
                float3 binormalDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_522 = i.uv0;
                float2 node_702 = i.uv0;
                float4 node_4 = i.vertexColor;
                float3 normalLocal = lerp(lerp(UnpackNormal(tex2D(_SandNormal,TRANSFORM_TEX(node_522.rg, _SandNormal))).rgb,UnpackNormal(tex2D(_LavaNormal,TRANSFORM_TEX(node_702.rg, _LavaNormal))).rgb,node_4.r),UnpackNormal(tex2D(_GrassNormal,TRANSFORM_TEX(node_702.rg, _GrassNormal))).rgb,node_4.g);
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float4 node_8 = tex2D(_SandDIFFSL,TRANSFORM_TEX(node_702.rg, _SandDIFFSL));
                float4 node_703 = _Time + _TimeEditor;
                float2 node_25 = (node_702.rg+node_703.g*float2(0.01,0.01));
                float4 node_2 = tex2D(_LavaDIFFSL,TRANSFORM_TEX(node_25, _LavaDIFFSL));
                float2 node_17 = i.uv0;
                float4 node_9 = tex2D(_GrassDIFFSL,TRANSFORM_TEX(node_17.rg, _GrassDIFFSL));
                float3 specularColor = lerp(lerp((node_8.a*float3(0.2279412,0.2279412,0.2279412)),float3(node_2.a,node_2.a,node_2.a),node_4.r),float3(node_9.a,node_9.a,node_9.a),node_4.g);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float3 node_7 = lerp(node_8.rgb,node_2.rgb,node_4.r);
                float3 node_6 = lerp(node_7,node_9.rgb,node_4.g);
                finalColor += diffuseLight * node_6;
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
