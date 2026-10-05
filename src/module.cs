// SPDX-License-Identifier: MIT

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fahrenheit.Mods.CustomCharacter.GUI;

using FhXCall = Fahrenheit.FFX.FhCall;

namespace Fahrenheit.Mods.CustomCharacter;

[FhLoad(FhGameId.FFX)]
public unsafe class CustomCharacterModule : FhModule {
    /* [fkelava 27/6/25 00:30]
     * A module's constructor must be parameterless. Use it to initialize local fields and objects.
     * Fahrenheit initialization is performed in `init` instead. Read that method's XML documentation comment for more details.
     */
    const string game = "FFX.exe";

    public static FhMethodHandle<FhXCall.d_TkMsGetRomItem> MsGetRomItem
        => new( new FhMethodLocation("FFX.exe", 0x3909F0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint d_FUN_00659710(nint param_1, FUN_00a59710_Struct* param_2);
    private FhMethodHandle<d_FUN_00659710> FUN_00659710
        => new( new FhMethodLocation("FFX.exe", 0x659710) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint d_FUN_00a59760(short param_1, nint param_2, FUN_00a59710_Struct* param_3);
    private FhMethodHandle<d_FUN_00a59760> FUN_00659760
        => new( new FhMethodLocation("FFX.exe", 0x659760) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint d_FUN_00649440(SphereGridNode* node, FUN_00a59710_Struct* sphere);
    private FhMethodHandle<d_FUN_00649440> FUN_00649440
        => new( new FhMethodLocation("FFX.exe", 0x649440) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065a800();
    private FhMethodHandle<d_FUN_0065a800> FUN_0065a800
        => new( new FhMethodLocation("FFX.exe", 0x65a800) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_pppCreateHeap(nint param_1, nint param_2, int param_3);
    private FhMethodHandle<d_pppCreateHeap> pppCreateHeap
        => new( new FhMethodLocation("FFX.exe", 0x32C480) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065bad0(nint param_1, int param_2, float param_3, float param_4,
            float param_5, float param_6, float param_7, float param_8, float param_9,
            float param_10, float param_11);
    private FhMethodHandle<d_FUN_0065bad0> FUN_0065bad0
        => new( new FhMethodLocation("FFX.exe", 0x65BAD0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FFXVu0InterVectorXYZ(Vector4* dest, Vector4* end, Vector4* start, float progress);
    private FhMethodHandle<d_FFXVu0InterVectorXYZ> FFXVu0InterVectorXYZ
        => new( new FhMethodLocation("FFX.exe", 0x22FD70) );


    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x2)]
    public unsafe struct SaveSphereGridNode {
        [FieldOffset(0x0)] public byte node_type;
        [FieldOffset(0x1)] public byte activated_by;

    }
    [InlineArray(1024)]
    public struct SaveSphereGridNodeArray {
        private SaveSphereGridNode _data;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x1328)]
    public struct SaveSphereGrid {
        [FieldOffset(0x000)] public       SaveSphereGridNodeArray nodes;
        [FieldOffset(0xA00)] public fixed byte                    links_activated_by[1024];
        [FieldOffset(0xF00)] public fixed ushort                  party_selected_node_idx[7];
        [FieldOffset(0xF18)] public       SphereGridTilt          tilt_level;
        [FieldOffset(0xF19)] public       SphereGridZoom          zoom_level;
    }

    [InlineArray(6)]
    public struct AbilityInlineArray {
        private ushort _data;
    }

    public struct MsChrAbilityMap {
        public int  hp;
        public int  mp;
        public byte strength;
        public byte defense;
        public byte magic;
        public byte magic_defense;
        public byte agility;
        public byte luck;
        public byte evasion;
        public byte accuracy;
        public AbilityInlineArray abilities;
    }


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate SaveSphereGrid* d_MsGetSaveAbilityMap();
    private FhMethodHandle<d_MsGetSaveAbilityMap> MsGetSaveAbilityMap
        => new( new FhMethodLocation("FFX.exe", 0x384F40) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void* d_user_malloc(nint param_1);
    private FhMethodHandle<d_user_malloc> user_malloc
        => new( new FhMethodLocation("FFX.exe", 0x287020) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void* d_FUN_002428d0(int* param_1, float* param_2);
    private FhMethodHandle<d_FUN_002428d0> FUN_002428d0
        => new( new FhMethodLocation("FFX.exe", 0x2428D0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_graphicDrawUIAbmapElement(graphicDrawUIAbmapElement_param1* param_1, byte* tex_name, uint param_3);
    private FhMethodHandle<d_graphicDrawUIAbmapElement> graphicDrawUIAbmapElement
        => new( new FhMethodLocation("FFX.exe", 0x23E930) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void* d_FUN_004b7130(nint param_1, int* param_2, int* param_3);
    private FhMethodHandle<d_FUN_004b7130> FUN_004b7130
        => new( new FhMethodLocation("FFX.exe", 0x4B7130) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate nint d_FUN_004e8fb0(nint param_1, uint param_2, byte* text, int param_4, int param_5, byte param_6,
            byte param_7, byte param_8, byte param_9, byte param_10, byte param_11, int param_12);
    private FhMethodHandle<d_FUN_004e8fb0> FUN_004e8fb0
        => new( new FhMethodLocation("FFX.exe", 0x4E8FB0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void* d_user_free(nint param_1);
    private FhMethodHandle<d_user_free> user_free
        => new( new FhMethodLocation("FFX.exe", 0x2FB8B0) );



    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_cdc_FFXVu0MulMatrix(Matrix4x4* dest, Matrix4x4* l, Matrix4x4* r);
    private FhMethodHandle<d_cdc_FFXVu0MulMatrix> cdc_FFXVu0MulMatrix
        => new( new FhMethodLocation("FFX.exe", 0x3059B0) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_006657c0(int param_1, temp_FUN_00a4c8d0_struct* param_2, int param_3, uint* param_4);
    private FhMethodHandle<d_FUN_006657c0> FUN_006657c0
        => new( new FhMethodLocation("FFX.exe", 0x6657C0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_006572e0();
    private FhMethodHandle<d_FUN_006572e0> FUN_006572e0
        => new( new FhMethodLocation("FFX.exe", 0x6572E0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00657620();
    private FhMethodHandle<d_FUN_00657620> FUN_00657620
        => new( new FhMethodLocation("FFX.exe", 0x657620) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00645570();
    private FhMethodHandle<d_FUN_00645570> FUN_00645570
        => new( new FhMethodLocation("FFX.exe", 0x645570) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_TOMenuTransFacePlyTex();
    private FhMethodHandle<d_TOMenuTransFacePlyTex> TOMenuTransFacePlyTex
        => new( new FhMethodLocation("FFX.exe", 0x501100) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00657120();
    private FhMethodHandle<d_FUN_00657120> FUN_00657120
        => new( new FhMethodLocation("FFX.exe", 0x657120) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_pppInitEnv(nint param_1, int param_2, nint param_3, int param_4);
    private FhMethodHandle<d_pppInitEnv> pppInitEnv
        => new( new FhMethodLocation("FFX.exe", 0x3169D0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate uint d_MsGetSaveConfigHiragana();
    private FhMethodHandle<d_MsGetSaveConfigHiragana> MsGetSaveConfigHiragana
        => new( new FhMethodLocation("FFX.exe", 0x3851F0) );

    public enum MenuTextFile {
        btl_txt = 0,
        menu_txt = 1,
        save_txt = 3,
        btlend_txt = 4,
        arms_txt = 5,
        build_txt = 6,
        config_txt = 7,
        item_txt = 8,
        mmain_txt = 9,
        name_txt = 10,
        status_txt = 11,
        summon_txt = 12,
        _config_txt = 14,
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte* d_MsMenuGetText(MenuTextFile file_id, int in_req_text_out_ref_data_end, uint get_second_text);
    private FhMethodHandle<d_MsMenuGetText> MsMenuGetText
        => new( new FhMethodLocation("FFX.exe", 0x38FCF0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00645fd0(int param_1, int param_2);
    private FhMethodHandle<d_FUN_00645fd0> FUN_00645fd0
        => new( new FhMethodLocation("FFX.exe", 0x645FD0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_006459e0(int param_1, int param_2);
    private FhMethodHandle<d_FUN_006459e0> FUN_006459e0
        => new( new FhMethodLocation("FFX.exe", 0x6459E0) );


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_graphicAbmapCreate(void* param_1);
    private FhMethodHandle<d_graphicAbmapCreate> graphicAbmapCreate
        => new( new FhMethodLocation("FFX.exe", 0x238F90) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_graphicDeActivateLoadingScreen();
    private FhMethodHandle<d_graphicDeActivateLoadingScreen> graphicDeActivateLoadingScreen
        => new( new FhMethodLocation("FFX.exe", 0x23DE40) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_graphicSetFlipVsnc(uint param_1);
    private FhMethodHandle<d_graphicSetFlipVsnc> graphicSetFlipVsnc
        => new( new FhMethodLocation("FFX.exe", 0x2430E0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00659950();
    private FhMethodHandle<d_FUN_00659950> FUN_00659950
        => new( new FhMethodLocation("FFX.exe", 0x659950) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0065b930();
    private FhMethodHandle<d_FUN_0065b930> FUN_0065b930
        => new( new FhMethodLocation("FFX.exe", 0x65B930) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_00386ef0(uint param_1, int param_2);
    private FhMethodHandle<d_FUN_00386ef0> FUN_00386ef0
        => new( new FhMethodLocation("FFX.exe", 0x386EF0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00648d70(int node_to_select, float param_2);
    private FhMethodHandle<d_FUN_00648d70> FUN_00648d70
        => new( new FhMethodLocation("FFX.exe", 0x648D70) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_TOGetEasyMesWFontLInterModeChrName(byte* name, int param_2);
    private FhMethodHandle<d_TOGetEasyMesWFontLInterModeChrName> TOGetEasyMesWFontLInterModeChrName
        => new( new FhMethodLocation("FFX.exe", 0x4B70C0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte* d_FUN_004b7c00(byte* text, byte param_2, float* param_3, int param_4);
    private FhMethodHandle<d_FUN_004b7c00> FUN_004b7c00
        => new( new FhMethodLocation("FFX.exe", 0x4B7C00) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00647c60(SphereGridChrInfo* chr_info);
    private FhMethodHandle<d_FUN_00647c60> FUN_00647c60
        => new( new FhMethodLocation("FFX.exe", 0x647C60) );


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_004aaf10();
    private FhMethodHandle<d_FUN_004aaf10> FUN_004aaf10
        => new( new FhMethodLocation("FFX.exe", 0x4AAF10) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_004aafa0();
    private FhMethodHandle<d_FUN_004aafa0> FUN_004aafa0
        => new( new FhMethodLocation("FFX.exe", 0x4AAFA0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate byte d_TkMenuGetCurrentPlayer();
    private FhMethodHandle<d_TkMenuGetCurrentPlayer> TkMenuGetCurrentPlayer
        => new( new FhMethodLocation("FFX.exe", 0x4A9860) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00647210();
    private FhMethodHandle<d_FUN_00647210> FUN_00647210
        => new( new FhMethodLocation("FFX.exe", 0x647210) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0065aca0();
    private FhMethodHandle<d_FUN_0065aca0> FUN_0065aca0
        => new( new FhMethodLocation("FFX.exe", 0x65ACA0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00658ff0(nint param_1);
    private FhMethodHandle<d_FUN_00658ff0> FUN_00658ff0
        => new( new FhMethodLocation("FFX.exe", 0x658FF0) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00648f20(int param_1);
    private FhMethodHandle<d_FUN_00648f20> FUN_00648f20
        => new( new FhMethodLocation("FFX.exe", 0x648F20) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00648c20(int param_1);
    private FhMethodHandle<d_FUN_00648c20> FUN_00648c20
        => new( new FhMethodLocation("FFX.exe", 0x648C20) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00648e40(int param_1, float param_2);
    private FhMethodHandle<d_FUN_00648e40> FUN_00648e40
        => new( new FhMethodLocation("FFX.exe", 0x648E40) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00659860(int param_1, void* param_2);
    private FhMethodHandle<d_FUN_00659860> FUN_00659860
        => new( new FhMethodLocation("FFX.exe", 0x659860) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065a2e0(int param_1);
    private FhMethodHandle<d_FUN_0065a2e0> FUN_0065a2e0
        => new( new FhMethodLocation("FFX.exe", 0x65A2E0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_00649310(int param_1, short param_2, uint param_3);
    private FhMethodHandle<d_FUN_00649310> FUN_00649310
        => new( new FhMethodLocation("FFX.exe", 0x649310) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate short d_AbmapFindNextConnectingNode(short node_idx_a, short target_node_idx, SphereGridLink** out_link);
    private FhMethodHandle<d_AbmapFindNextConnectingNode> AbmapFindNextConnectingNode
        => new( new FhMethodLocation("FFX.exe", 0x656E00) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_restoreVf00Register();
    private FhMethodHandle<d_restoreVf00Register> restoreVf00Register
        => new( new FhMethodLocation("FFX.exe", 0x2EF00) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_006563b0(Vector4* param_1, Vector4* param_2, Vector4* param_3, Vector4* param_4, float param_5);
    private FhMethodHandle<d_FUN_006563b0> FUN_006563b0
        => new( new FhMethodLocation("FFX.exe", 0x6563B0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_006482d0(SphereGridChrInfo* param_1, Vector4* param_2);
    private FhMethodHandle<d_FUN_006482d0> FUN_006482d0
        => new( new FhMethodLocation("FFX.exe", 0x6482D0) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool d_FUN_00649270(Vector4* param_1, Vector4* param_2);
    private FhMethodHandle<d_FUN_00649270> FUN_00649270
        => new( new FhMethodLocation("FFX.exe", 0x649270) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00647440();
    private FhMethodHandle<d_FUN_00647440> FUN_00647440
        => new( new FhMethodLocation("FFX.exe", 0x647440) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte d_FUN_007853e0(byte param_1);
    private FhMethodHandle<d_FUN_007853e0> FUN_007853e0
        => new( new FhMethodLocation("FFX.exe", 0x3853E0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_006474d0(short param_1, ushort param_2, byte param_3);
    private FhMethodHandle<d_FUN_006474d0> FUN_006474d0
        => new( new FhMethodLocation("FFX.exe", 0x6474D0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_0065b400(int param_1, short param_2, uint param_3, int param_4);
    private FhMethodHandle<d_FUN_0065b400> FUN_0065b400
        => new( new FhMethodLocation("FFX.exe", 0x65B400) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SphereGridNode* d_FUN_00656a40(float* param_1, Vector4* param_2, void* param_3);
    private FhMethodHandle<d_FUN_00656a40> FUN_00656a40
        => new( new FhMethodLocation("FFX.exe", 0x656A40) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte* d_MsGetSaveInParty(int* param_1);
    private FhMethodHandle<d_MsGetSaveInParty> MsGetSaveInParty
        => new( new FhMethodLocation("FFX.exe", 0x385270) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte* d_MsGetSaveOutParty(int* param_1);
    private FhMethodHandle<d_MsGetSaveOutParty> MsGetSaveOutParty
        => new( new FhMethodLocation("FFX.exe", 0x3852D0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte d_FUN_004b9eb0(uint param_1);
    private FhMethodHandle<d_FUN_004b9eb0> FUN_004b9eb0
        => new( new FhMethodLocation("FFX.exe", 0x4B9EB0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_004b9ec0(uint param_1);
    private FhMethodHandle<d_FUN_004b9ec0> FUN_004b9ec0
        => new( new FhMethodLocation("FFX.exe", 0x4B9EC0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_004ba370(int param_1, int param_2);
    private FhMethodHandle<d_FUN_004ba370> FUN_004ba370
        => new( new FhMethodLocation("FFX.exe", 0x4BA370) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_004ba400();
    private FhMethodHandle<d_FUN_004ba400> FUN_004ba400
        => new( new FhMethodLocation("FFX.exe", 0x4BA400) );



    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065ad30(Matrix4x4* param_1, SphereGridNode* node, float param_3);
    private FhMethodHandle<d_FUN_0065ad30> FUN_0065ad30
        => new( new FhMethodLocation("FFX.exe", 0x65AD30) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065a360(Matrix4x4* param_1, SphereGridNode* node, Vec2s16* param_3, float param_4);
    private FhMethodHandle<d_FUN_0065a360> FUN_0065a360
        => new( new FhMethodLocation("FFX.exe", 0x65A360) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_002390D0(int param_1);
    private FhMethodHandle<d_FUN_002390D0> FUN_002390D0
        => new( new FhMethodLocation("FFX.exe", 0x2390D0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_MsInitChrAbilityMap();
    private FhMethodHandle<d_MsInitChrAbilityMap> MsInitChrAbilityMap
        => new( new FhMethodLocation("FFX.exe", 0x398820) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate MsChrAbilityMap* d_MsGetChrAbilityMap(uint chr_id);
    private FhMethodHandle<d_MsGetChrAbilityMap> MsGetChrAbilityMap
        => new( new FhMethodLocation("FFX.exe", 0x3987F0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_MsSetChrAbilityMapCommand(uint chr_id, uint ability_id);
    private FhMethodHandle<d_MsSetChrAbilityMapCommand> MsSetChrAbilityMapCommand
        => new( new FhMethodLocation("FFX.exe", 0x398840) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_MsSetSaveParamAll();
    private FhMethodHandle<d_MsSetSaveParamAll> MsSetSaveParamAll
        => new( new FhMethodLocation("FFX.exe", 0x386900) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00651720(uint* param_1, float* param_2, int param_3);
    private FhMethodHandle<d_FUN_00651720> FUN_00651720
        => new( new FhMethodLocation("FFX.exe", 0x651720) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_006521a0(uint* param_1, float* param_2, int param_3);
    private FhMethodHandle<d_FUN_006521a0> FUN_006521a0
        => new( new FhMethodLocation("FFX.exe", 0x6521a0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FFXVu0MulVector(Vector4* param_1, Vector4* param_2, Vector4* param_3);
    private FhMethodHandle<d_FFXVu0MulVector> FFXVu0MulVector
        => new( new FhMethodLocation("FFX.exe", 0x2ED5D0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_graphicFontGetScreenWH(int* out_width, int* out_height);
    private FhMethodHandle<d_graphicFontGetScreenWH> graphicFontGetScreenWH
        => new( new FhMethodLocation("FFX.exe", 0x240DB0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate abmapVertexInfo* d_graphicAbmapGetVertexInfo(byte* param_1, int param_2);
    private FhMethodHandle<d_graphicAbmapGetVertexInfo> graphicAbmapGetVertexInfo
        => new( new FhMethodLocation("FFX.exe", 0x238FD0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_fiosUnifyFilename(nint in_string, nint out_buffer, int buffer_size);
    private FhMethodHandle<d_fiosUnifyFilename> fiosUnifyFilename
        => new( new FhMethodLocation("FFX.exe", 0x279820) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00651340();
    private FhMethodHandle<d_FUN_00651340> FUN_00651340
        => new( new FhMethodLocation("FFX.exe", 0x651340) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00651560(int param_1);
    private FhMethodHandle<d_FUN_00651560> FUN_00651560
        => new( new FhMethodLocation("FFX.exe", 0x651560) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0064fe40();
    private FhMethodHandle<d_FUN_0064fe40> FUN_0064fe40
        => new( new FhMethodLocation("FFX.exe", 0x64FE40) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_003f49e0(int param_1, FUN_003f49e0_param_2* param_2, int param_3, uint param_4);
    private FhMethodHandle<d_FUN_003f49e0> FUN_003f49e0
        => new( new FhMethodLocation("FFX.exe", 0x3F49E0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_graphicDrawUIElement(graphicDrawUIAbmapElement_param1* param_1, byte* param_2, int param_3, int param_4, int param_5);
    private FhMethodHandle<d_graphicDrawUIElement> graphicDrawUIElement
        => new( new FhMethodLocation("FFX.exe", 0x23EEE0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_006457d0(int chr_id, int node_idx);
    private FhMethodHandle<d_FUN_006457d0> FUN_006457d0
        => new( new FhMethodLocation("FFX.exe", 0x6457D0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_00645870(int chr_id);
    private FhMethodHandle<d_FUN_00645870> FUN_00645870
        => new( new FhMethodLocation("FFX.exe", 0x645870) );


    // Hooks
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00644d30();
    public FhMethodHandle<d_FUN_00644d30> FUN_00644d30
        => new( new FhMethodLocation("FFX.exe", 0x644D30) );

    // Not defined in ffx-v2
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00645010();
    public FhMethodHandle<d_FUN_00645010> FUN_00645010
        => new( new FhMethodLocation("FFX.exe", 0x645010) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_abmap_get_chr_point(int param_1);
    public FhMethodHandle<d_abmap_get_chr_point> abmap_get_chr_point
        => new( new FhMethodLocation("FFX.exe", 0x645870) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00647d50();
    public FhMethodHandle<d_FUN_00647d50> FUN_00647d50
        => new( new FhMethodLocation("FFX.exe", 0x647d50) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00647f00();
    public FhMethodHandle<d_FUN_00647f00> FUN_00647f00
        => new( new FhMethodLocation("FFX.exe", 0x647f00) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_abmap_set_chr_posInternal_00648a80(int chr_id, short node_idx);
    public FhMethodHandle<d_abmap_set_chr_posInternal_00648a80> abmap_set_chr_posInternal_00648a80
        => new( new FhMethodLocation("FFX.exe", 0x648A80) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00648c80(int chr_id, short node_idx);
    public FhMethodHandle<d_FUN_00648c80> FUN_00648c80
        => new( new FhMethodLocation("FFX.exe", 0x648C80) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00649590();
    public FhMethodHandle<d_FUN_00649590> FUN_00649590
        => new( new FhMethodLocation("FFX.exe", 0x649590) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0064b790();
    public FhMethodHandle<d_FUN_0064b790> FUN_0064b790
        => new( new FhMethodLocation("FFX.exe", 0x64B790) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0064c8d0();
    public FhMethodHandle<d_FUN_0064c8d0> FUN_0064c8d0
        => new( new FhMethodLocation("FFX.exe", 0x64C8D0) );


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_eiAbmStart();
    public FhMethodHandle<d_eiAbmStart> eiAbmStart
        => new( new FhMethodLocation("FFX.exe", 0x654B40) );

    // Called when using (special?) sphere
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_006560d0(nint param_1, int param_2, nint param_3, int param_4);
    public FhMethodHandle<d_FUN_006560d0> FUN_006560d0
        => new( new FhMethodLocation("FFX.exe", 0x6560D0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00656160(nint param_1, int param_2, nint param_3, int param_4);
    public FhMethodHandle<d_FUN_00656160> FUN_00656160
        => new( new FhMethodLocation("FFX.exe", 0x656160) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00657f80(uint chr_id, int node_idx, uint param_3, uint param_4, uint param_5, uint param_6);
    public FhMethodHandle<d_FUN_00657f80> FUN_00657f80
        => new( new FhMethodLocation("FFX.exe", 0x657F80) );
    //private FUN_00a57f80 _FUN_00a57f80; // => fhutil.get_fptr<FUN_00a57f80>(__addr_FUN_00a57f80);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00658080(int chr_id);
    public FhMethodHandle<d_FUN_00658080> FUN_00658080
        => new( new FhMethodLocation("FFX.exe", 0x658080) );
    //private FUN_00a58080 _FUN_00a58080; // => fhutil.get_fptr<FUN_00a58080>(__addr_FUN_00a58080);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00658ec0();
    public FhMethodHandle<d_FUN_00658ec0> FUN_00658ec0
        => new( new FhMethodLocation("FFX.exe", 0x658EC0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_006598a0();
    public FhMethodHandle<d_FUN_006598a0> FUN_006598a0
        => new( new FhMethodLocation("FFX.exe", 0x6598A0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00659990();
    public FhMethodHandle<d_FUN_00659990> FUN_00659990
        => new( new FhMethodLocation("FFX.exe", 0x659990) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0065a4b0();
    public FhMethodHandle<d_FUN_0065a4b0> FUN_0065a4b0
        => new( new FhMethodLocation("FFX.exe", 0x65A4B0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065a990(int param_1);
    public FhMethodHandle<d_FUN_0065a990> FUN_0065a990
        => new( new FhMethodLocation("FFX.exe", 0x65A990) );
    //private FUN_00a5a990 _FUN_00a5a990; // => fhutil.get_fptr<FUN_00a5a990>(__addr_FUN_00a5a990);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0065b030();
    public FhMethodHandle<d_FUN_0065b030> FUN_0065b030
        => new( new FhMethodLocation("FFX.exe", 0x65B030) );
    //private FUN_00a5b030 _FUN_00a5b030; // => fhutil.get_fptr<FUN_00a5b030>(__addr_FUN_00a5b030);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0065b7b0();
    public FhMethodHandle<d_FUN_0065b7b0> FUN_0065b7b0
        => new( new FhMethodLocation("FFX.exe", 0x65B7B0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065b980(uint param_1, short param_2, uint param_3);
    public FhMethodHandle<d_FUN_0065b980> FUN_0065b980
        => new( new FhMethodLocation("FFX.exe", 0x65B980) );
    //private FUN_00a5b980 _FUN_00a5b980; // => fhutil.get_fptr<FUN_00a5b980>(__addr_FUN_00a5b980);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0065bb70();
    public FhMethodHandle<d_FUN_0065bb70> FUN_0065bb70
        => new( new FhMethodLocation("FFX.exe", 0x65BB70) );
    //private FUN_00a5bb70 _FUN_00a5bb70; // => fhutil.get_fptr<FUN_00a5bb70>(__addr_FUN_00a5bb70);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_004a8f40(uint param_1);
    public FhMethodHandle<d_FUN_004a8f40> FUN_004a8f40
        => new( new FhMethodLocation("FFX.exe", 0x4A8F40) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_004bde00();
    public FhMethodHandle<d_FUN_004bde00> FUN_004bde00
        => new( new FhMethodLocation("FFX.exe", 0x4BDE00) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_006505e0();
    public FhMethodHandle<d_FUN_006505e0> FUN_006505e0
        => new( new FhMethodLocation("FFX.exe", 0x6505E0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_006534c0();
    public FhMethodHandle<d_FUN_006534c0> FUN_006534c0
        => new( new FhMethodLocation("FFX.exe", 0x6534C0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00650ed0(int param_1);
    public FhMethodHandle<d_FUN_00650ed0> FUN_00650ed0
        => new( new FhMethodLocation("FFX.exe", 0x650ED0) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_0064b4b0();
    public FhMethodHandle<d_FUN_0064b4b0> FUN_0064b4b0
        => new( new FhMethodLocation("FFX.exe", 0x64B4B0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_00653de0(SaveSphereGrid* save_sphere_grid);
    public FhMethodHandle<d_FUN_00653de0> FUN_00653de0
        => new( new FhMethodLocation("FFX.exe", 0x653DE0) );

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate abmapVertexInfo* d_AbmapManager_AllocBuffMemory(nint abmapManager, int param_1);
    public FhMethodHandle<d_AbmapManager_AllocBuffMemory> AbmapManager_AllocBuffMemory
        => new( new FhMethodLocation("FFX.exe", 0x281C10) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_op1_md_draw_eiabm_sphe(int param_1, temp_FUN_00a4c8d0_struct* param_2, int node_idx, int chr_id);
    public FhMethodHandle<d_op1_md_draw_eiabm_sphe> op1_md_draw_eiabm_sphe
        => new( new FhMethodLocation("FFX.exe", 0x668140) );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00653510();
    public FhMethodHandle<d_FUN_00653510> FUN_00653510
        => new( new FhMethodLocation("FFX.exe", 0x653510) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_004efd90(int param_1, int chr_id, int param_3, int param_4, int param_5, int param_6, int param_7, int param_8, int param_9);
    public FhMethodHandle<d_FUN_004efd90> FUN_008efd90
        => new( new FhMethodLocation("FFX.exe", 0x4EFD90) );


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_eiAbmParaGet();
    public FhMethodHandle<d_eiAbmParaGet> eiAbmParaGet
        => new( new FhMethodLocation("FFX.exe", 0x654860) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool d_FUN_0065d120(byte sphere_type, int node_idx, SphereGridNodeType* param_3, int chr_id);
    public FhMethodHandle<d_FUN_0065d120> FUN_0065d120
        => new( new FhMethodLocation("FFX.exe", 0x65D120) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool d_FUN_00645800(int chr_id, int nodes_idx);
    public FhMethodHandle<d_FUN_00645800> FUN_00645800
        => new( new FhMethodLocation("FFX.exe", 0x645800) );

    private static uint num_characters = 8;
    private SphereGridChrInfo* custom_party_infos;

    // TODO: Initialize with proper values on new game start
    private short[] custom_party_selected_node_idx = new short[num_characters - 7];

    private short[][] custom_starting_selected_node_idx = [
            [0xF6, 0xF6, 0xAA] // Middle of the Fira/Blizzara/Thundara/Watera Cluster
        ];

    private ushort[][][] custom_starting_activated_nodes = [
        [
            [   // Original
              220, 221, 223, 222, 251, 246, 748, 252, // Fire, Thunder, Water, Blizzard, Fira, Thundara, Watera, Blizzara
              335, 146, 337, 338, 340, 648            // Cure, Cura, NulBlaze, NulShock, NulTide, Scan
            ],
            [   // Standard
              220, 221, 223, 222, 251, 246, 748, 252, // Fire, Thunder, Water, Blizzard, Fira, Thundara, Watera, Blizzara
              335, 146, 337, 338, 340, 648            // Cure, Cura, NulBlaze, NulShock, NulTide, Scan
            ],
            [   // Expert
              14, 15, 16, 17, 154, 155, 156, 157,     // Fire, Thunder, Water, Blizzard, Fira, Thundara, Watera, Blizzara
              8, 185, 3, 4, 5, 56                     // Cure, Cura, NulBlaze, NulShock, NulTide, Scan
            ]
        ]
    ];

    private Vec2s16[,] custom_node_indicator_pos = new Vec2s16[130, num_characters-7]; // 130 node types

    private class CustomSphereGridState(short[] custom_party_selected_node_idx) {
        [JsonInclude]
        public short[] custom_party_selected_node_idx = custom_party_selected_node_idx;
    }

    public override bool init(FhModContext mod_context, FileStream global_state_file) {
        custom_party_infos = (SphereGridChrInfo*)NativeMemory.AllocZeroed((nuint)(sizeof(SphereGridChrInfo) * num_characters));

        Vector4f_ARRAY_00c86010 = (Vector4*)NativeMemory.AllocZeroed((nuint)(sizeof(Vector4) * 4 * num_characters));
        p_DAT_00c86580 = (uint*)NativeMemory.AllocZeroed(sizeof(int) * num_characters);
        p_DAT_00c86660 = (uint*)NativeMemory.AllocZeroed(sizeof(int) * (num_characters+1)); // Extra is used for selection circle
        p_DAT_00c86644 = (uint*)NativeMemory.AllocZeroed(sizeof(int) * num_characters);
        p_DAT_00c8659c = (uint*)NativeMemory.AllocZeroed(sizeof(int) * num_characters);
        p_DAT_00c865bc = (uint*)NativeMemory.AllocZeroed(sizeof(int) * num_characters);

        Vector4* original_Vector4f_ARRAY_00c86010 = FhUtil.ptr_at<Vector4>(0x886010);
        uint* original_p_DAT_00c86580 = FhUtil.ptr_at<uint>(0x886580);
        uint* original_p_DAT_00c86660 = FhUtil.ptr_at<uint>(0x886660);
        uint* original_p_DAT_00c86644 = FhUtil.ptr_at<uint>(0x886644);
        uint* original_p_DAT_00c8659c = FhUtil.ptr_at<uint>(0x88659C);
        uint* original_p_DAT_00c865bc = FhUtil.ptr_at<uint>(0x8865BC);

        for (int i = 0; i < 7; i++) {
            Vector4f_ARRAY_00c86010[i] = original_Vector4f_ARRAY_00c86010[i];
            p_DAT_00c86580[i] = original_p_DAT_00c86580[i];
            p_DAT_00c86660[i] = original_p_DAT_00c86660[i];
            p_DAT_00c86644[i] = original_p_DAT_00c86644[i];
            p_DAT_00c8659c[i] = original_p_DAT_00c8659c[i];
            p_DAT_00c865bc[i] = original_p_DAT_00c865bc[i*5]; // Values inbetween seem unused?
        }
        p_DAT_00c86660[num_characters] = original_p_DAT_00c86660[7]; // Selection circle

        // Seymour colors
        Vector4f_ARRAY_00c86010[7] = new Vector4(0.0f, 1.0f, 1.0f, 1.0f); // Selected character ambient(?) light color on surrounding nodes
        p_DAT_00c86580[7] = 0x805C5C22; // Selected character aura color
        p_DAT_00c86660[7] = 0x60A0A000; // Circle color
        p_DAT_00c86644[7] = 0x802D2D18; // Inctive indicator color
        p_DAT_00c8659c[7] = 0x60A0A000; // Active indicator color
        p_DAT_00c865bc[7] = 0x806A6A00; // Node to move to color (each byte is circle color * 2/3)


        return FUN_00644d30.hook(this, h_FUN_00a44d30) &&
               FUN_00645010.hook(this, h_FUN_00a45010) &&
               abmap_get_chr_point.hook(this, h_abmap_get_chr_point) &&
               FUN_00647d50.hook(this, h_FUN_00a47d50) &&
               FUN_00647f00.hook(this, h_FUN_00a47f00) &&
               abmap_set_chr_posInternal_00648a80.hook(this, h_abmap_set_chr_posInternal_00a48a80) &&
               FUN_00648c80.hook(this, h_FUN_00a48c80) &&
               FUN_00649590.hook(this, h_FUN_00a49590) &&
               FUN_0064b790.hook(this, h_FUN_00a4b790) &&
               FUN_0064c8d0.hook(this, h_FUN_00a4c8d0) &&
               eiAbmStart.hook(this, h_eiAbmStart) &&
               FUN_006560d0.hook(this, h_FUN_00a560d0) &&
               FUN_00656160.hook(this, h_FUN_00a56160) &&
               FUN_00657f80.hook(this, h_FUN_00a57f80) &&
               FUN_00658080.hook(this, h_FUN_00a58080) &&
               FUN_00658ec0.hook(this, h_FUN_00a58ec0) &&
               FUN_006598a0.hook(this, h_FUN_00a598a0) &&
               FUN_00659990.hook(this, h_FUN_00a59990) &&
               FUN_0065a4b0.hook(this, h_FUN_00a5a4b0) &&
               FUN_0065a990.hook(this, h_FUN_00a5a990) &&
               FUN_0065b030.hook(this, h_FUN_00a5b030) &&
               FUN_0065b7b0.hook(this, h_FUN_00a5b7b0) &&
               FUN_0065b980.hook(this, h_FUN_00a5b980) &&
               FUN_0065bb70.hook(this, h_FUN_00a5bb70) &&
               FUN_004a8f40.hook(this, h_FUN_008a8ef0) &&
               FUN_004bde00.hook(this, h_FUN_008bddc0) &&
               FUN_006505e0.hook(this, h_FUN_00a505e0) &&
               FUN_00650ed0.hook(this, h_FUN_00a50ed0) &&
               FUN_006534c0.hook(this, h_FUN_00a534c0) &&
               op1_md_draw_eiabm_sphe.hook(this, h_op1_md_draw_eiabm_sphe) &&
               AbmapManager_AllocBuffMemory.hook(this, h_AbmapManager_AllocBuffMemory) && // Testing
               FUN_00653510.hook(this, h_FUN_00a53510) &&
               FUN_0064b4b0.hook(this, h_FUN_00a4b4b0) &&
               FUN_00653de0.hook(this, h_FUN_00a53de0) &&
               FUN_008efd90.hook(this, h_FUN_008efd90) &&
               eiAbmParaGet.hook(this, h_eiAbmParaGet) &&
               FUN_0065d120.hook(this, h_FUN_00a5d120) &&
               FUN_00645800.hook(this, h_FUN_00a45800);
    }


    public override void render_imgui() {
        CustomCharacterGUI.render();
    }

    public override void load_local_state(FileStream? local_state_file, FhLocalStateInfo local_state_info) {
        try {
            var loaded_state = JsonSerializer.Deserialize<CustomSphereGridState>(local_state_file);
            if (loaded_state != null) {
                custom_party_selected_node_idx = loaded_state.custom_party_selected_node_idx;
            }
        } catch {
            custom_party_selected_node_idx = new short[num_characters - 7];
        }
    }
    public override void save_local_state(FileStream  local_state_file) {
        CustomSphereGridState state = new(custom_party_selected_node_idx);
        JsonSerializer.Serialize(local_state_file, state);
        local_state_file.SetLength(local_state_file.Position);
    }



    public unsafe struct XYWHs16 {
        public short x;
        public short y;
        public short w;
        public short h;
    }
    public unsafe struct MenuEntry {
        public int text;
        public int unknown1;
        public int unknown2;
    }



    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x340)]
    public unsafe struct SphereGridMenu {
        [InlineArray(64)]
        public struct MenuEntryArray {
            private MenuEntry _data;
        }

        [FieldOffset(0x00)] public XYWHs16        pos1;
        [FieldOffset(0x08)] public XYWHs16        pos2;
        [FieldOffset(0x10)] public short          something1;
        [FieldOffset(0x12)] public short          max_lines1;
        [FieldOffset(0x14)] public short          something2;
        [FieldOffset(0x16)] public short          max_lines2;
        [FieldOffset(0x18)] public int            __0x18;
        [FieldOffset(0x1c)] public short          __0x1C;
        [FieldOffset(0x1e)] public short          num_entries;
        [FieldOffset(0x20)] public short          __0x20;
        [FieldOffset(0x22)] public short          num_columns;
        [FieldOffset(0x24)] public byte           __0x24;
        [FieldOffset(0x25)] public short          __0x25;

        [FieldOffset(0x28)] public bool           is_full;

        [FieldOffset(0x2a)] public XYWHs16        pos3;
        [FieldOffset(0x32)] public short          __0x32;
        [FieldOffset(0x34)] public void*          func1;
        [FieldOffset(0x38)] public void*          func2;
        [FieldOffset(0x3c)] public void*          func3;
        [FieldOffset(0x40)] public MenuEntryArray entries;
    }
    public unsafe struct SphereGridMenuData {
        [InlineArray(12)]
        public struct SphereGridMenuArray {
            private SphereGridMenu _data;
        }
        public SphereGridMenuArray menus;
        public int                 __0x2700;
        public void*               func;
    }

    private nint _panel_bin_ptr => FhUtil.get_at<nint>(0x16860E0);

    private LpAbilityMapEngine* lpamng => Globals.SphereGrid.lpamng;
    private nint  sphere_bin_ptr => FhUtil.get_at<nint>(0x16860E4);
    private SphereGridMenuData* sphere_grid_menu_ptr  => (SphereGridMenuData*)FhUtil.get_at<nint>(0x01686108);
    private short _DAT_0168607e => FhUtil.get_at<byte>(0x0168607E);
    private nint  p_DAT_01686034  => (nint)FhUtil.ptr_at<nint>(0x1686034);
    private nint  p_DAT_012c1830  => (nint)FhUtil.ptr_at<nint>(0x12C1830);
    private nint  p_DAT_01686060  => (nint)FhUtil.ptr_at<nint>(0x1686060);
    private nint* p_ppvCurPrimp => FhUtil.ptr_at<nint>(0x1F0FD2C);

    private uint _gParticleDoNotRender => FhUtil.get_at<uint>(0xEFB7D0);


    private uint*  p_DAT_01441c30                       => FhUtil.ptr_at<uint>(0x01441c30);
    private uint*  p_DAT_01441c34                       => FhUtil.ptr_at<uint>(0x01441c34);
    private uint*  p_DAT_01441c2c                       => FhUtil.ptr_at<uint>(0x01441c2c);
    private byte*  p_DAT_01441c14_PauseMenuPlayerList   => FhUtil.ptr_at<byte>(0x01441c14);
    private uint*  p_DAT_01441c24_PauseMenuFrontlineNum => FhUtil.ptr_at<uint>(0x01441c24);
    private uint*  p_UINT_01441c1c_PlayerListMax        => FhUtil.ptr_at<uint>(0x01441c1c);
    private uint*  p_UINT_01441c20_PlayerListMax        => FhUtil.ptr_at<uint>(0x01441c20);
    private uint*  p_DAT_01441c28_PauseMenuSelIdx       => FhUtil.ptr_at<uint>(0x01441c28);

    private byte* p_DAT_01469f19 => FhUtil.ptr_at<byte>(0x01469F19);
    private int*  p_DAT_01469f24 => FhUtil.ptr_at<int >(0x01469F24);
    private byte* p_DAT_01869F18 => FhUtil.ptr_at<byte>(0x01469F18);

    private int  DAT_01F057ec   => FhUtil.get_at<int>(0x1F057EC);

    private int* p_DAT_014663e8 => FhUtil.ptr_at<int>(0x14663E8);


    //private Vector4* Vector4f_ARRAY_00c86010 => FhUtil.ptr_at<Vector4>(0x886010); // Selected character ambient(?) light color on surrounding nodes
    //private int* p_DAT_00c86580 => FhUtil.ptr_at<int>(0x886580); // Selected character aura color?
    //private int* p_DAT_00c86660 => FhUtil.ptr_at<int>(0x886660); // Circle color?
    private Vector4* Vector4f_ARRAY_00c86010;
    private uint* p_DAT_00c86580; // Aura color
    private uint* p_DAT_00c86660; // Circle color
    private uint* p_DAT_00c86644; // Inactive indicator color
    private uint* p_DAT_00c8659c; // Active indicator color
    private uint* p_DAT_00c865bc; // Highligted nodes color

    private float* eff_sin_t => FhUtil.ptr_at<float>(0x844BF0);

    private int DAT_01f057f8 => FhUtil.get_at<int>(0x1F057F8);
    private int DAT_01f057fc => FhUtil.get_at<int>(0x1F057FC);
    private int* p_DAT_01340870_sphere_grid_layout_dat => FhUtil.ptr_at<int>(0x1340870);


    private int* p_DAT_01685f70 => FhUtil.ptr_at<int>(0x1685F70);
    private int* p_DAT_01685f74 => FhUtil.ptr_at<int>(0x1685F74);
    private int  DAT_01f05800 => FhUtil.get_at<int>(0x1F05800);

    private int* p_DAT_016860ec => FhUtil.ptr_at<int>(0x16860EC);
    private int* p_DAT_016860f0 => FhUtil.ptr_at<int>(0x16860F0);


    private uint DAT_01f05814 => FhUtil.get_at<uint>(0x01f05814);
    private uint DAT_01f05818 => FhUtil.get_at<uint>(0x01f05818);
    private uint DAT_01f0581c => FhUtil.get_at<uint>(0x01f0581c);
    private uint DAT_01f05820 => FhUtil.get_at<uint>(0x01f05820);

    private short DAT_01f05810 => FhUtil.get_at<short>(0x01f05810);
    private short DAT_01f05808 => FhUtil.get_at<short>(0x01f05808);
    private uint  DAT_01f05830 => FhUtil.get_at<uint>(0x01f05830);
    private uint  DAT_01f0580c => FhUtil.get_at<uint>(0x01f0580c);
    private short DAT_01f05804 => FhUtil.get_at<short>(0x01f05804);






    private Vector4* asmreg_0_zero => FhUtil.ptr_at<Vector4>(0x88F508); // Vector4i in Ghidra

    private float* _asmreg_Q => FhUtil.ptr_at<float>(0x88F788);
    private Vector4* asmreg_vf0  => FhUtil.ptr_at<Vector4>(0x80a004);
    private Vector4* asmreg_vf4  => FhUtil.ptr_at<Vector4>(0x88F7D0);
    private Vector4* asmreg_vf5  => FhUtil.ptr_at<Vector4>(0x88F7E0);
    private Vector4* asmreg_vf7  => FhUtil.ptr_at<Vector4>(0x88F800);
    private Vector4* asmreg_vf8  => FhUtil.ptr_at<Vector4>(0x88F810);
    private Vector4* asmreg_vf9  => FhUtil.ptr_at<Vector4>(0x88F820);
    private Vector4* asmreg_vf10 => FhUtil.ptr_at<Vector4>(0x88F830);
    private Vector4* asmreg_vf26 => FhUtil.ptr_at<Vector4>(0x88F930);
    private Vector4* asmreg_vf27 => FhUtil.ptr_at<Vector4>(0x88F940);
    private Vector4* asmreg_vf28 => FhUtil.ptr_at<Vector4>(0x88F950);
    private Vector4* asmreg_vf29 => FhUtil.ptr_at<Vector4>(0x88F960);
    private Vector4* asmreg_vf30 => FhUtil.ptr_at<Vector4>(0x88F970);
    private Vector4* asmreg_vf31 => FhUtil.ptr_at<Vector4>(0x88F980);
    private Vector4* asmreg_ACC  => FhUtil.ptr_at<Vector4>(0x88F790);


    private SphereGridLinkPoint* SphereGridLinkPoint_ARRAY_01693160 => FhUtil.ptr_at<SphereGridLinkPoint>(0x12931A0);


    public struct FUN_00a59710_Struct {
        public Sphere*                  ptr_sphere;
        public int                      chr_id;
        public int                      chr_flag;
        public int                      status;
        public SphereGridNodeProperties properties;
    }

    private void h_FUN_00a44d30() {
        short uVar1;
        ushort uVar2;
        SphereGridMenuData* iVar3;
        uint uVar4;
        PCommand *pMVar5;
        //byte *puVar6;
        int iVar6;
        FUN_00a59710_Struct local_28 = new();
        int local_c;
        uint local_8;

        iVar3 = sphere_grid_menu_ptr;
        iVar6 = 0;
        uVar1 = custom_party_infos[lpamng->current_chr_id].current_node_idx;
        if (0 < sphere_grid_menu_ptr->menus[8].num_entries) {
            //puVar6 = (byte*)(sphere_grid_menu_ptr + 0x1a44);
            ref MenuEntry entry = ref sphere_grid_menu_ptr->menus[8].entries[iVar6];
            do {
                //uVar2 = *(ushort*)(puVar6 + 4);
                uVar2 = (ushort)entry.unknown2;
                local_8 = lpamng->current_chr_id;
                uVar4 = FhCall.MsGetSaveItemNum.fnptr!(uVar2);
                if (uVar4 == 0) {
                    //*puVar6 = 1;
                    entry.unknown1 = 1;
                }
                else {
                    local_28.chr_flag = 1 << ((byte)local_8 & 0x1f);
                    local_28.chr_id = (int)local_8;
                    local_28.status = 0;
                    pMVar5 = MsGetRomItem.fnptr!(uVar2, &local_c);
                    if (pMVar5->command_pdata.sphere_grid_role == 0xff) {
                        local_28.ptr_sphere = (Sphere*)0;
                    }
                    else {
                        local_28.ptr_sphere =
                             (Sphere*)FhXCall.MsGetExcelData.fnptr!(pMVar5->command_pdata.sphere_grid_role, sphere_bin_ptr, &local_c);
                    }
                    if (local_28.ptr_sphere != (Sphere*)0x0) {
                        if (local_28.ptr_sphere->range == SphereRange.UNLIMITED) {
                            FUN_00659710.fnptr!((nint)FhUtil.ptr_at<nint>(0x649440), &local_28);
                        }
                        else {
                            FUN_00659760.fnptr!(uVar1, (nint)FhUtil.ptr_at<nint>(0x649440), &local_28);
                        }
                    }
                    if (local_28.status == 0) {
                        //*puVar6 = 1;
                        entry.unknown1 = 1;
                    } else {
                        //*puVar6 = 0;
                        entry.unknown1 = 0;
                    }
                }
                iVar6 = iVar6 + 1;
                //puVar6 = puVar6 + 0xc;
            } while (iVar6 < iVar3->menus[8].num_entries);
        }
        return;
    }

    void h_FUN_00a45010() {
        byte *pbVar1;
        ushort uVar2;
        SphereGridMenuData *pSVar3;

        FUN_00658ff0.fnptr!(0x0);
        if ((lpamng->__0x115CD == 0) && (lpamng->__0x115B0 == 0)) {
            FUN_00658ec0.fnptr!();
            if (lpamng->__0x115B0 == 0) {
                if (lpamng->__0x115C4 == 0) {
                    lpamng->__0x115C4 = 1;
                    FUN_00648f20.fnptr!(6);
                }
                uVar2 = lpamng->abmap_input[1];
                if ((uVar2 & 0x20) != 0) {
                    FhCall.SndSepPlaySimple.fnptr!(0x80000001);
                    lpamng->__0x11666 = 0;
                    FUN_00648c20.fnptr!(6);
                    FUN_00648c20.fnptr!(1);
                    FUN_00648c20.fnptr!(2);
                    FUN_00648c20.fnptr!(3);
                    FUN_00648c20.fnptr!(4);
                    FUN_00648c20.fnptr!(5);
                    lpamng->__0x115C8 = 0;
                    FUN_00648e40.fnptr!(custom_party_infos[lpamng->current_chr_id].current_node_idx, 0x3e800000);
                    return;
                }
                if ((uVar2 & 0x40) != 0) {
                    FhCall.SndSepPlaySimple.fnptr!(0x80000001);
                    FUN_00648c20.fnptr!(6);
                    FUN_00648c20.fnptr!(1);
                    FUN_00648c20.fnptr!(2);
                    FUN_00648c20.fnptr!(3);
                    FUN_00648c20.fnptr!(4);
                    FUN_00648c20.fnptr!(5);
                    lpamng->__0x115C8 = 0;
                    pSVar3 = sphere_grid_menu_ptr;
                    *(byte*)((int)&sphere_grid_menu_ptr->menus[10].num_columns + 1) = 1;
                    //FUN_00a59860(0xb, FUN_00a56060);
                    FUN_00659860.fnptr!(0xb, FhUtil.ptr_at<nint>(0x656060));
                    pbVar1 = &pSVar3->menus[0].__0x24;
                    *pbVar1 = (byte)(*pbVar1 | 0xc);
                    *(short*)&pSVar3->menus[0].__0x18 = 0;
                    return;
                }
                if (((((sphere_grid_menu_ptr->menus[6].func1 == (void*)0x0) &&
                      (sphere_grid_menu_ptr->menus[1].func1 == (void*)0x0)) &&
                     ((sphere_grid_menu_ptr->menus[3].func1 == (void*)0x0 &&
                      ((sphere_grid_menu_ptr->menus[2].func1 == (void*)0x0 &&
                       (sphere_grid_menu_ptr->menus[4].func1 == (void*)0x0)))))) &&
                    (sphere_grid_menu_ptr->menus[5].func1 == (void*)0x0)) && ((uVar2 & 0x10) != 0)) {
                    FhCall.SndSepPlaySimple.fnptr!(0x80000001);
                    lpamng->__0x115C8 = (byte)(lpamng->__0x115C8 + 1);
                    if (5 < lpamng->__0x115C8) {
                        lpamng->__0x115C8 = 0;
                    }
                    switch (lpamng->__0x115C8) {
                        case 0:
                            FUN_00648c20.fnptr!(5);
                            FUN_00648f20.fnptr!(6);
                            return;
                        case 1:
                            *(byte*)((int)&sphere_grid_menu_ptr->menus[6].num_columns + 1) = 0;
                            FUN_00648f20.fnptr!(1);
                            return;
                        case 2:
                            FUN_0065a2e0.fnptr!(3);
                            *(byte*)((int)&sphere_grid_menu_ptr->menus[1].num_columns + 1) = 0;
                            FUN_00648f20.fnptr!(3);
                            return;
                        case 3:
                            FUN_0065a2e0.fnptr!(2);
                            *(byte*)((int)&sphere_grid_menu_ptr->menus[3].num_columns + 1) = 0;
                            FUN_00648f20.fnptr!(2);
                            return;
                        case 4:
                            FUN_0065a2e0.fnptr!(4);
                            *(byte*)((int)&sphere_grid_menu_ptr->menus[2].num_columns + 1) = 0;
                            FUN_00648f20.fnptr!(4);
                            return;
                        case 5:
                            FUN_0065a2e0.fnptr!(5);
                            *(byte*)((int)&sphere_grid_menu_ptr->menus[4].num_columns + 1) = 0;
                            FUN_00648f20.fnptr!(5);
                            return;
                    }
                }
            }
        }
        return;
    }

    int h_abmap_get_chr_point(int param_1) {
        if (!FhXCall.MsGetSavePlyJoined.fnptr!((byte)param_1)) {
            return -1;
        }
        return custom_party_infos[param_1].current_node_idx;
    }

    void h_FUN_00a47d50() {
        float fVar1;
        float fVar2;
        float fVar3;
        LpAbilityMapEngine *plVar4;
        float *pfVar5;
        int iVar6;
        uint uStack_8;

        iVar6 = 0;
        uStack_8 = lpamng->__0x11650;
        pfVar5 = &custom_party_infos[0].pos_circle_radius;
        fVar1 = lpamng->moving_halo_target_width;
        fVar2 = lpamng->moving_halo_start_width;
        fVar3 = lpamng->moving_halo_start_width;
        plVar4 = lpamng;
        do {
            if ((0.0 < *pfVar5 != float.IsNaN(*pfVar5)) && (*(ushort*)(pfVar5 + 2) == plVar4->__0x1164E)) {
                *pfVar5 = (fVar1 - fVar2) * (uStack_8 / 40.0f) + fVar3;
                FUN_00658080.fnptr!(iVar6);
                plVar4 = lpamng;
            }
            iVar6 = iVar6 + 1;
            pfVar5 = pfVar5 + 0x14;
            if (iVar6 == num_characters) pfVar5 = (float*)((int)lpamng + 0x112b8 + 0x3c);
        } while (iVar6 < num_characters+1);
        if ((plVar4->__0x11650 < 0x14) && (0x13 < plVar4->__0x11650 + 1)) {
            FUN_0065bb70.fnptr!();
            eiAbmParaGet.fnptr!();
            *(short*)((int)&lpamng->nodes[lpamng->__0x1164E] + 6) = *(short*)(&lpamng->__0x1164C);
            lpamng->should_update_node = lpamng->__0x1164E;
            lpamng->should_update = 1;
            lpamng->link_points = SphereGridLinkPoint_ARRAY_01693160;
            FUN_0065a800.fnptr!();
            plVar4 = lpamng;
        }
        plVar4->__0x11650 += 1;
        if (_DAT_0168607e == 0) {
            iVar6 = 0;
            pfVar5 = &custom_party_infos[0].pos_circle_radius;
            plVar4 = lpamng;
            do {
                if ((0.0 < *pfVar5 != float.IsNaN(*pfVar5)) && (*(ushort*)(pfVar5 + 2) == plVar4->__0x1164E)) {
                    *pfVar5 = plVar4->moving_halo_target_width;
                    FUN_00658080.fnptr!(iVar6);
                    plVar4 = lpamng;
                }
                iVar6 = iVar6 + 1;
                pfVar5 = pfVar5 + 0x14;
                if (iVar6 == num_characters) pfVar5 = (float*)((int)lpamng + 0x112b8 + 0x3c);
            } while (iVar6 < num_characters+1);
            plVar4->__0x115A8 = plVar4->__0x115B0;
            lpamng->__0x115B0 = 0;
            lpamng->__0x115AC = lpamng->__0x115B4;
            lpamng->__0x115B4 = 0;
        }
        return;
    }

    void h_FUN_00a47f00() {
        byte bVar1;
        float progress;
        LpAbilityMapEngine *plVar2;
        Vector4 local_28;
        Vector4 local_18;

        plVar2 = lpamng;
        bVar1 = lpamng->__0x1164C;
        if (bVar1 == 0) {
            lpamng->__0x1164D += 1;
            lpamng->__0x115C6 = (byte)(-0x80 - (byte)(((uint)lpamng->__0x1164D << 7) / 0x28));
            if (0x7f < lpamng->__0x115C6) {
                lpamng->__0x115C6 = 0x80;
            }
            if (_DAT_0168607e == 0) {
                custom_party_infos[lpamng->moving_chr_id].pos_circle_radius = 0.0f;
                lpamng->__0x1164C = 1;
                lpamng->__0x115C6 = 0;
            }
        }
        else {
            if (bVar1 == 1) {
                local_18.X = lpamng->nodes[lpamng->move_last_target_node_idx].x;
                local_18.Y = lpamng->nodes[lpamng->move_last_target_node_idx].y;
                local_18.Z = 0.0f;
                local_18.W = 1.0f;
                progress = lpamng->moving_progress + 0.083333336f;
                lpamng->moving_progress = progress;
                if (1.0 <= progress) {
                    plVar2->__0x1164C = 2;
                    lpamng->__0x1164D = 0;
                    FhCall.SndSepPlaySimple.fnptr!(0x80000070);
                    plVar2 = lpamng;
                    (lpamng->cam_desired_pos).X = local_18.X;
                    (plVar2->cam_desired_pos).Y = local_18.Y;
                    (plVar2->cam_desired_pos).Z = local_18.Z;
                    (plVar2->cam_desired_pos).W = local_18.W;
                    pppCreateHeap.fnptr!(p_DAT_01686034, p_DAT_012c1830, 0x7d000);
                    FUN_0065bad0.fnptr!(p_DAT_01686060, 1, local_18.X, local_18.Y, 0, 0, 0, 0, 0.5f, 0.5f, 0.5f);
                    custom_party_infos[lpamng->moving_chr_id].current_node_idx = lpamng->move_last_target_node_idx;
                    FUN_0065a990.fnptr!(lpamng->moving_chr_id);
                    FUN_00658080.fnptr!(lpamng->moving_chr_id);
                    lpamng->__0x115C7 = 1;
                    FUN_0065b030.fnptr!();
                    return;
                }
                FFXVu0InterVectorXYZ.fnptr!(&local_28, &local_18, &lpamng->move_prev_node_pos, progress);
                (lpamng->cam_desired_pos).X = local_28.X;
                (lpamng->cam_desired_pos).Y = local_28.Y;
                return;
            }
            if (bVar1 == 2) {
                lpamng->__0x1164D += 1;
                lpamng->__0x115C6 = (byte)(((uint)lpamng->__0x1164D << 7) / 0x28);
                if (0x7f < lpamng->__0x115C6) {
                    lpamng->__0x115C6 = 0x80;
                }
                if (_DAT_0168607e == 0) {
                    lpamng->__0x115C6 = 0x80;
                    lpamng->__0x115A8 = lpamng->__0x115B0;
                    lpamng->__0x115B0 = 0;
                    lpamng->__0x115AC = lpamng->__0x115B4;
                    lpamng->__0x115B4 = 0;
                    return;
                }
            }
        }
        return;
    }

    void h_abmap_set_chr_posInternal_00a48a80(int chr_id, short node_idx) {
        float node_y;
        LpAbilityMapEngine *_lpamng;
        short current_node;
        float node_x;

        _lpamng = lpamng;
        current_node = custom_party_infos[chr_id].current_node_idx;
        FhCall.SndSepPlaySimple.fnptr!(0x80000070);
        lpamng->__0x1164C = 0;
        lpamng->__0x1164D = 0;
        node_x = _lpamng->nodes[current_node].x;
        lpamng->cam_desired_pos.X = node_x;
        lpamng->move_prev_node_pos.X = node_x;
        node_y = _lpamng->nodes[current_node].y;
        lpamng->cam_desired_pos.Y = node_y;
        lpamng->move_prev_node_pos.Y = node_y;
        lpamng->moving_progress = 0;
        lpamng->move_last_target_node_idx = node_idx;
        lpamng->moving_chr_id = (byte)chr_id;
        pppCreateHeap.fnptr!(p_DAT_01686034, p_DAT_012c1830, 0x7d000);
        FUN_0065bad0.fnptr!(p_DAT_01686060, 2, _lpamng->nodes[current_node].x,
                     _lpamng->nodes[current_node].y, 0, 0, 0, 0, 0.5f, 0.5f, 0.5f);
        if (lpamng->__0x115B4 == 0) {
            lpamng->__0x115B4 = lpamng->__0x115AC;
            lpamng->__0x115AC = (int)FhUtil.ptr_at<int>(0x64C430);
        }
        if (lpamng->__0x115B0 == 0) {
            lpamng->__0x115B0 = lpamng->__0x115A8;
            lpamng->__0x115A8 = (int)FhUtil.ptr_at<int>(0x647f00);
        }
        return;
    }

    void h_FUN_00a48c80(int chr_id, short node_idx) {
        lpamng->move_next_target_node_idx = custom_party_infos[chr_id].current_node_idx;
        lpamng->move_start_node_idx = lpamng->move_next_target_node_idx;
        lpamng->move_last_target_node_idx = node_idx;
        lpamng->moving_progress = 1.0f;
        lpamng->moving_speed = 0.0f;
        lpamng->moving_chr_id = (byte)chr_id;
        if (lpamng->__0x115B0 == 0) {
            lpamng->__0x115B0 = lpamng->__0x115A8;
            lpamng->__0x115A8 = (int)FhUtil.ptr_at<int>(0x659990);
        }
        return;
    }

    void h_FUN_00a49590() {
        byte bVar1;
        float fVar2;
        SaveSphereGrid *save_ability_map;
        LpAbilityMapEngine *plVar3;
        int link_idx;
        int node_idx;
        SphereGridTilt tilt_level;

        save_ability_map = MsGetSaveAbilityMap.fnptr!();
        node_idx = 0;
        plVar3 = lpamng;
        if (0 < lpamng->node_count) {
            do {
                if (plVar3->nodes[node_idx].node_type != NodeType.NULL) {
                    bVar1 = save_ability_map->nodes[node_idx].node_type;
                    if (bVar1 == 0xff) {
                        plVar3->nodes[node_idx].node_type = NodeType.NULL;
                        //* (ushort*)((int)plVar3->nodes[0].links_ptr + node_offset + -6) = 0xffff;
                    }
                    else {
                        plVar3->nodes[node_idx].node_type = (NodeType)(ushort)bVar1;
                        //*(ushort*)((int)plVar3->nodes[0].links + node_offset + -6) = (ushort)bVar1;
                    }
                    plVar3->nodes[node_idx].activated_by = save_ability_map->nodes[node_idx].activated_by;
                    //*(byte*)((int)plVar3->nodes[0].links + node_offset + 0x15) =
                    //     save_ability_map->nodes[node_idx].activated_by;
                    plVar3 = lpamng;
                }
                node_idx = node_idx + 1;
            } while (node_idx < plVar3->node_count);
        }
        link_idx = 0;
        if (0 < plVar3->link_count) {
            do {
                plVar3->links[link_idx].activated_by = save_ability_map->links_activated_by[link_idx];
                //(&plVar3->links[0].activated_by)[link_offset] = save_ability_map->links_activated_by[link_idx]
                ;
                link_idx = link_idx + 1;
                plVar3 = lpamng;
            } while (link_idx < lpamng->link_count);
        }
        // TODO: Handle extra characters
        custom_party_infos[0].current_node_idx = (short)save_ability_map->party_selected_node_idx[0];
        custom_party_infos[1].current_node_idx = (short)save_ability_map->party_selected_node_idx[1];
        custom_party_infos[2].current_node_idx = (short)save_ability_map->party_selected_node_idx[2];
        custom_party_infos[3].current_node_idx = (short)save_ability_map->party_selected_node_idx[3];
        custom_party_infos[4].current_node_idx = (short)save_ability_map->party_selected_node_idx[4];
        custom_party_infos[5].current_node_idx = (short)save_ability_map->party_selected_node_idx[5];
        custom_party_infos[6].current_node_idx = (short)save_ability_map->party_selected_node_idx[6];
        for (int i = 0; i < num_characters - 7; i++) {
            custom_party_infos[i+7].current_node_idx = custom_party_selected_node_idx[i];
        }
        lpamng->tilt_level = save_ability_map->tilt_level;
        lpamng->zoom_level = save_ability_map->zoom_level;
        plVar3 = lpamng;
        tilt_level = lpamng->tilt_level;
        if (tilt_level != SphereGridTilt.FLAT) {
            if (tilt_level == SphereGridTilt.SLIGHT_TILT) {
                fVar2 = -3640.0f;
                goto LAB_00a496fe;
            }
            if (tilt_level == SphereGridTilt.FAR_TILT) {
                fVar2 = -7281.0f;
                goto LAB_00a496fe;
            }
        }
        fVar2 = 0.0f;
    LAB_00a496fe:
        node_idx = (int)(fVar2); // Is this equivalent to ftol(fVar2)?
        plVar3->tilt_vector.x = node_idx;
        switch (lpamng->zoom_level) {
            default:
                fVar2 = 1.0f;
                break;
            case SphereGridZoom.MEDIUM:
                fVar2 = 0.5f;
                break;
            case SphereGridZoom.FAR:
                fVar2 = 0.25f;
                break;
            case SphereGridZoom.VERY_FAR:
                fVar2 = 0.125f;
                break;
        }
        (lpamng->zoom_vector).Z = fVar2;
        (lpamng->zoom_vector).Y = fVar2;
        (lpamng->zoom_vector).X = fVar2;
        if (0.375 < fVar2) {
            lpamng->__0x116B0 = 2;
            return;
        }
        lpamng->__0x116B0 = -2;
        return;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct graphicDrawUIAbmapElement_param1 {
        public InlineArray4<float> floats0;
        public InlineArray4<int  > ints0;
        public InlineArray4<float> floats1;
        public InlineArray4<int  > ints1;
        public InlineArray4<float> floats2;
        public InlineArray4<int  > ints2;
        public InlineArray4<float> floats3;
        public InlineArray4<int  > ints3;
    }

    void h_FUN_00a4b790() {
        //var _asmreg_ACC  = asmreg_ACC;
        //var _asmreg_vf26 = asmreg_vf26;
        //var _asmreg_vf27 = asmreg_vf27;
        //var _asmreg_vf28 = asmreg_vf28;
        //var _asmreg_vf29 = asmreg_vf29;
        //var _asmreg_vf30 = asmreg_vf30;
        //var _asmreg_vf31 = asmreg_vf31;

        float x;
        LpAbilityMapEngine *plVar1;
        byte bVar2;
        float *piVar3;
        int iVar4;
        SphereGridChrInfo *pSVar5;
        int iVar6;
        int *piVar7;
        float fVar8;
        float extraout_ST0;
        float fVar9;
        float extraout_ST1;
        float extraout_ST1_00;
        int local_294;
        float *local_290;
        int local_28c;
        int local_288 = 0;
        int local_284;
        int *local_280;
        int local_27c;
        int local_278;
        int local_274;
        float local_270 = 0f;
        float local_26c = 0f;
        int local_268;
        float local_264;
        float[] _local_260 = new float[8];
        fixed (float* local_260 = _local_260) {
            int local_25c;
            int local_258;
            int local_254;
            float local_250;
            float local_24c;
            float local_248;
            float local_244;
            graphicDrawUIAbmapElement_param1 local_240 = new();
            int[] _local_1a8 = new int[4 * (num_characters+1)];
            fixed (int* local_1a8 = _local_1a8) {
                int[] _local_128 = new int[2];
                fixed (int* local_128 = _local_128) {
                    float[] _local_118 = new float[3];
                    fixed (float* local_118 = _local_118) {
                        byte[] _local_108 = new byte[256];
                        fixed (byte* local_108 = _local_108) {

                            piVar3 = (float*)user_malloc.fnptr!(0x1ec);
                            Span<float> _piVar3 = new Span<float>(piVar3, 0x7b);
                            fVar9 = 0f;
                            fVar8 = 16.0f;
                            //local_274 = &custom_party_infos[0].pos_circle_radius;
                            var chr_info = &custom_party_infos[0];

                            local_268 = (int)num_characters;
                            piVar7 = local_1a8 + 3;
                            local_290 = piVar3;
                            do {
                                asmreg_vf27->X = chr_info->label_pos.X;
                                asmreg_vf27->Y = chr_info->label_pos.Y;
                                asmreg_vf27->Z = chr_info->label_pos.Z;
                                asmreg_vf27->W = chr_info->label_pos.W;
                                asmreg_vf28->X = (lpamng->__0x113E0).M11;
                                asmreg_vf28->Y = (lpamng->__0x113E0).M12;
                                asmreg_vf28->Z = (lpamng->__0x113E0).M13;
                                asmreg_vf28->W = (lpamng->__0x113E0).M14;
                                asmreg_vf29->X = (lpamng->__0x113E0).M21;
                                asmreg_vf29->Y = (lpamng->__0x113E0).M22;
                                asmreg_vf29->Z = (lpamng->__0x113E0).M23;
                                asmreg_vf29->W = (lpamng->__0x113E0).M24;
                                asmreg_vf30->X = (lpamng->__0x113E0).M31;
                                asmreg_vf30->Y = (lpamng->__0x113E0).M32;
                                asmreg_vf30->Z = (lpamng->__0x113E0).M33;
                                asmreg_vf30->W = (lpamng->__0x113E0).M34;
                                asmreg_vf31->X = (lpamng->__0x113E0).M41;
                                asmreg_vf31->Y = (lpamng->__0x113E0).M42;
                                asmreg_vf31->Z = (lpamng->__0x113E0).M43;
                                asmreg_vf31->W = (lpamng->__0x113E0).M44;
                                asmreg_ACC->X = asmreg_vf27->Z * asmreg_vf30->X +
                                                asmreg_vf27->Y * asmreg_vf29->X + asmreg_vf27->X * asmreg_vf28->X;
                                asmreg_ACC->Y = asmreg_vf30->Y * asmreg_vf27->Z +
                                                asmreg_vf29->Y * asmreg_vf27->Y + asmreg_vf28->Y * asmreg_vf27->X;
                                asmreg_ACC->Z = asmreg_vf30->Z * asmreg_vf27->Z +
                                                asmreg_vf29->Z * asmreg_vf27->Y + asmreg_vf28->Z * asmreg_vf27->X;
                                *piVar7 = 0;
                                asmreg_ACC->W = asmreg_vf27->Z * asmreg_vf30->W +
                                                asmreg_vf27->Y * asmreg_vf29->W + asmreg_vf27->X * asmreg_vf28->W;
                                asmreg_vf26->X = asmreg_ACC->X + asmreg_vf0->W * asmreg_vf31->X;
                                asmreg_vf26->Y = asmreg_vf31->Y * asmreg_vf0->W + asmreg_ACC->Y;
                                asmreg_vf26->Z = asmreg_vf31->Z * asmreg_vf0->W + asmreg_ACC->Z;
                                asmreg_vf26->W = asmreg_vf0->W * asmreg_vf31->W + asmreg_ACC->W;
                                piVar3[0xc] = asmreg_vf26->X;
                                piVar3[0xd] = asmreg_vf26->Y;
                                piVar3[0xe] = asmreg_vf26->Z;
                                piVar3[0xf] = asmreg_vf26->W;
                                if ((fVar9 < chr_info->pos_circle_radius != (float.IsNaN(fVar9) || float.IsNaN(chr_info->pos_circle_radius))) &&
                                   (fVar9 < piVar3[0xf] != (float.IsNaN(fVar9) || float.IsNaN(piVar3[0xf])))) {
                                    asmreg_vf4->W = piVar3[0xf];
                                    asmreg_vf5->X = piVar3[0xf];
                                    iVar6 = 0;
                                    *_asmreg_Q = asmreg_vf0->W / asmreg_vf5->X;
                                    asmreg_vf4->X = *_asmreg_Q * piVar3[0xc];
                                    asmreg_vf4->Y = piVar3[0xd] * *_asmreg_Q;
                                    asmreg_vf4->Z = *_asmreg_Q * piVar3[0xe];
                                    piVar3[0xc] = asmreg_vf4->X;
                                    piVar3[0xd] = asmreg_vf4->Y;
                                    piVar3[0xe] = asmreg_vf4->Z;
                                    piVar3[0xf] = asmreg_vf4->W;
                                    asmreg_vf8->X = piVar3[0xc];
                                    asmreg_vf8->Y = piVar3[0xd];
                                    asmreg_vf8->Z = piVar3[0xe];
                                    asmreg_vf8->W = piVar3[0xf];
                                    local_260[0] = piVar3[0xc];
                                    local_260[1] = piVar3[0xd];
                                    local_260[2] = piVar3[0xe];
                                    local_260[3] = piVar3[0xf];
                                    //local_28c = BitConverter.SingleToInt32Bits(asmreg_vf8->Z);
                                    //local_284 = BitConverter.SingleToInt32Bits(asmreg_vf8->X);
                                    //local_280 = (int*)BitConverter.SingleToInt32Bits(asmreg_vf8->Y);
                                    //local_264 = asmreg_vf8->W;
                                    do {
                                        iVar4 = (int)((float)(*(local_260 + iVar6) * fVar8));
                                        *(int*)(asmreg_vf7 + iVar6) = iVar4;
                                        iVar6 = iVar6 + 1;
                                        //fVar8 = extraout_ST1;
                                    } while (iVar6 < 2);
                                    local_260[4] = asmreg_vf8->X;
                                    local_260[5] = asmreg_vf8->Y;
                                    local_260[6] = asmreg_vf8->Z;
                                    local_260[7] = asmreg_vf8->W;
                                    asmreg_vf7->Z = (float)(int)(asmreg_vf8->Z);
                                    asmreg_vf7->W = (float)(int)(local_260[7]);
                                    piVar3[0x18] = asmreg_vf7->X;
                                    piVar3[0x19] = asmreg_vf7->Y;
                                    piVar3[0x1a] = asmreg_vf7->Z;
                                    piVar3[0x1b] = asmreg_vf7->W;
                                    piVar7[-3] = BitConverter.SingleToInt32Bits(piVar3[0x18]) >> 4;
                                    piVar7[-2] = BitConverter.SingleToInt32Bits(piVar3[0x19]) >> 4;
                                    *piVar7 = 1;
                                    //fVar9 = extraout_ST0;
                                    //fVar8 = extraout_ST1_00;
                                }
                                //local_274 = local_274 + 0x14;
                                chr_info += 1;
                                piVar7 = piVar7 + 4;
                                local_268 = local_268 + -1;
                            } while (local_268 != 0);
                            local_280 = local_1a8;
                            local_284 = (int)num_characters;
                            local_274 = 0;
                            pSVar5 = custom_party_infos;
                            var temp = &custom_party_infos[0];
                            local_268 = 0;
                            do {
                                if ((fVar9 < pSVar5->pos_circle_radius ==
                                     (float.IsNaN(fVar9) || float.IsNaN(pSVar5->pos_circle_radius))) || (local_280[3] == 0))
                                    goto LAB_00a4c3cd;
                                local_268 = *local_280 + -0x800;
                                local_118[0] = (float)local_268;
                                bVar2 = (byte)(pSVar5->__0x4E & 3);
                                if ((bVar2 == 0) || (bVar2 == 2)) {
                                    local_118[1] = ((pSVar5->pos).X - local_118[0]) + (pSVar5->pos).Y;
                                }
                                else {
                                    local_118[1] = (pSVar5->pos).Y - ((pSVar5->pos).X - local_118[0]);
                                }
                                local_118[2] = 1.0f;
                                FUN_002428d0.fnptr!(local_128, local_118);
                                iVar6 = local_128[0] + 0x100;
                                iVar4 = local_128[1] + 0xd0;
                                if (pSVar5->__0x46 != 0) {
                                    iVar6 = iVar6 + (pSVar5->__0x46 >> 4);
                                }
                                if (pSVar5->__0x48 != 0) {
                                    iVar4 = iVar4 + (pSVar5->__0x48 >> 4);
                                }
                                local_264 = (uint)(local_274 != lpamng->current_chr_id ? 1 : 0);
                                local_268 = (pSVar5->__0x38 + pSVar5->name_width);
                                local_27c = iVar6;
                                local_278 = iVar4;
                                //local_268 = local_268; // ???
                                local_294 = 0x13;
                                switch (pSVar5->__0x4E & 3) {
                                    case 0:
                                        local_26c = 0.25f;
                                        break;
                                    case 1:
                                        local_26c = 0.51464844f;
                                        iVar6 = iVar6 + (-7 - local_268);
                                        local_27c = iVar6;
                                        break;
                                    case 2:
                                        local_26c = 0.51464844f;
                                        iVar6 = iVar6 + (-7 - local_268);
                                        local_27c = iVar6;
                                        goto LAB_00a4bdd3;
                                    case 3:
                                        local_26c = 0.25f;
                                    LAB_00a4bdd3:
                                        local_288 = 1;
                                        local_270 = 0.119140625f;
                                        goto default;
                                    default:
                                        goto switchD_00a4bd71_caseD_4;
                                }
                                iVar4 = iVar4 + -0x13;
                                local_270 = 0.18554688f;
                                local_288 = 0x13;
                                local_278 = iVar4;
                            switchD_00a4bd71_caseD_4:

                                if (!(0.5 < local_26c == float.IsNaN(local_26c))) {
                                    if (local_264 == 1.0) local_26c = 0.76464844f;
                                    LAB_00a4be2f:
                                    local_240.floats0[0] = local_268 + iVar6;
                                    local_240.floats0[1] = local_278;
                                    local_240.floats1[0] = iVar6 + 7 + local_268;
                                    local_240.floats2[1] = iVar4 + 0x13;
                                    local_240.ints0[0] = 0x80;
                                    local_240.ints0[1] = 0x80;
                                    local_240.ints0[2] = 0x80;
                                    local_240.ints0[3] = 0x80;
                                    local_240.ints1[0] = 0x80;
                                    local_240.ints1[1] = 0x80;
                                    local_240.ints1[2] = 0x80;
                                    local_240.ints1[3] = 0x80;
                                    local_240.ints2[0] = 0x80;
                                    local_240.floats0[2] = local_26c + 0.20996094f;
                                    local_240.ints2[1] = 0x80;
                                    local_240.ints2[2] = 0x80;
                                    local_240.ints2[3] = 0x80;
                                    local_240.ints3[0] = 0x80;
                                    local_240.ints3[1] = 0x80;
                                    local_240.ints3[2] = 0x80;
                                    local_240.ints3[3] = 0x80;
                                    local_240.floats0[3] = local_270;
                                    local_240.floats1[2] = local_26c + 0.23632813f;
                                    local_240.floats1[3] = local_270;
                                    local_264 = local_270 + 0.05078125f;
                                    local_240.floats1[1] = local_240.floats0[1];
                                    local_240.floats2[0] = local_240.floats0[0];
                                    local_240.floats2[2] = local_240.floats0[2];
                                    local_240.floats2[3] = local_264;
                                    local_240.floats3[0] = local_240.floats1[0];
                                    local_240.floats3[1] = local_240.floats2[1];
                                    local_240.floats3[2] = local_240.floats1[2];
                                    local_240.floats3[3] = local_264;
                                    graphicDrawUIAbmapElement.fnptr!(&local_240, local_108, 5);
                                    local_264 = (float)local_27c;
                                    local_240.floats1[2] = local_26c;
                                    local_240.floats3[2] = local_26c;
                                    local_240.floats1[0] = local_264;
                                    local_240.floats3[0] = local_264;
                                }
                                else {
                                    if (local_264 == 1.0) local_26c = 0.0f;
                                LAB_00a4c0e9:
                                    local_240.floats0[0] = (float)local_27c;
                                    local_240.floats0[1] = (float)local_278;
                                    local_240.floats1[0] = (float)(iVar6 + 7);
                                    local_240.floats2[1] = (float)(iVar4 + 0x13);
                                    local_240.ints0[0] = 0x80;
                                    local_240.ints0[1] = 0x80;
                                    local_240.ints0[2] = 0x80;
                                    local_240.ints0[3] = 0x80;
                                    local_240.ints1[0] = 0x80;
                                    local_240.ints1[1] = 0x80;
                                    local_240.ints1[2] = 0x80;
                                    local_240.ints1[3] = 0x80;
                                    local_240.ints2[0] = 0x80;
                                    local_240.ints2[1] = 0x80;
                                    local_240.floats0[3] = local_270;
                                    local_240.ints2[2] = 0x80;
                                    local_240.ints2[3] = 0x80;
                                    local_240.floats1[2] = local_26c + 0.026367188f;
                                    local_240.ints3[0] = 0x80;
                                    local_240.ints3[1] = 0x80;
                                    local_240.ints3[2] = 0x80;
                                    local_240.ints3[3] = 0x80;
                                    local_240.floats1[3] = local_270;
                                    local_264 = local_270 + 0.05078125f;
                                    local_240.floats0[2] = local_26c;
                                    local_240.floats1[1] = local_240.floats0[1];
                                    local_240.floats2[0] = local_240.floats0[0];
                                    local_240.floats2[2] = local_26c;
                                    local_240.floats2[3] = local_264;
                                    local_240.floats3[0] = local_240.floats1[0];
                                    local_240.floats3[1] = local_240.floats2[1];
                                    local_240.floats3[2] = local_240.floats1[2];
                                    local_240.floats3[3] = local_264;
                                    graphicDrawUIAbmapElement.fnptr!(&local_240, local_108, 5);
                                    local_240.floats0[0] = (float)(local_268 + 7 + iVar6);
                                    local_264 = local_26c + 0.23632813f;
                                    local_240.floats0[2] = local_264;
                                    local_240.floats2[0] = local_240.floats0[0];
                                    local_240.floats2[2] = local_264;
                                }
                                graphicDrawUIAbmapElement.fnptr!(&local_240, local_108, 5);
                                FUN_004b7130.fnptr!((nint)pSVar5->chr_name, &local_28c, &local_294);
                                bVar2 = (byte)(pSVar5->__0x4E & 3);
                                if ((bVar2 == 1) || (bVar2 == 2)) {
                                    x = ((float)local_268 - local_28c) * 0.5f;
                                }
                                else {
                                    x = ((float)local_268 - local_28c) * 0.5f + 7.0f;
                                }
                                local_268 = local_28c;
                                local_268 = (int)(x);
                                plVar1 = lpamng;
                                iVar4 = pSVar5->__0x4C + local_288 + local_278;
                                iVar6 = (int)((lpamng->zoom_vector).Y * 100.0);
                                *p_ppvCurPrimp = FUN_004e8fb0.fnptr!(*p_ppvCurPrimp + 0x10, 0xffffffff, pSVar5->chr_name,
                                                           local_27c + local_268, iVar4, 0, 0, 0x80, 0x80, 0x80,
                                                           plVar1->__0x115B9, iVar6);
                                fVar9 = 0f;
                            LAB_00a4c3cd:
                                local_280 = local_280 + 4;
                                local_274 = local_274 + 1;
                                pSVar5 = pSVar5 + 1;
                                local_284 = local_284 + -1;
                                if (local_284 == 0) {
                                    user_free.fnptr!((nint)local_290);
                                    return;
                                }
                            } while (true);
                        }
                    }
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x48)]
    public struct temp_FUN_00a4c8d0_struct {
        [FieldOffset(0x00)] public int        __0x0;
        [FieldOffset(0x04)] public int        __0x4;
        [FieldOffset(0x08)] public ushort     __0x8;
        [FieldOffset(0x0a)] public byte       __0xA;
        [FieldOffset(0x0b)] public byte       __0xB;
        [FieldOffset(0x0c)] public int        __0xC;
        [FieldOffset(0x10)] public int        __0x10;
        [FieldOffset(0x14)] public int        __0x14;
        [FieldOffset(0x18)] public uint       rgba; // rgba ?
        [FieldOffset(0x1b)] public byte       a; // a ?
        [FieldOffset(0x1c)] public int        __0x1C;
        [FieldOffset(0x20)] public Matrix4x4* __0x20;
        [FieldOffset(0x24)] public int        __0x24;
        [FieldOffset(0x28)] public int        __0x28;
        [FieldOffset(0x2c)] public Matrix4x4* __0x2C;
        [FieldOffset(0x30)] public int        __0x30;
        [FieldOffset(0x34)] public int        __0x34;
        [FieldOffset(0x38)] public int        __0x38;
        [FieldOffset(0x3c)] public int        __0x3C;
        [FieldOffset(0x40)] public int        __0x40;
        [FieldOffset(0x44)] public Matrix4x4* __0x44;
    }

    void h_FUN_00a4c8d0() {
        short sVar1;
        short uVar2;
        LpAbilityMapEngine *plVar3;
        int iVar4;
        uint uVar5;
        //float *pfVar6;
        //double extraout_ST0;
        double fVar7;
        uint uStack_154 = 0;
        temp_FUN_00a4c8d0_struct local_150 = new();
        Matrix4x4 local_d8 = new();
        Matrix4x4 local_98 = new();
        Matrix4x4 local_58 = new();

        plVar3 = lpamng;
        iVar4 = DAT_01f057fc;
        local_150.__0x0 = 4;
        local_150.rgba = p_DAT_00c86580[lpamng->current_chr_id]; // Extend with custom color for Seymour
        //local_150.__0x18 = *(p_DAT_00c86580 + (uint)lpamng->current_chr_id * 4);
        local_150.a = (byte)(((long)lpamng->__0x115C5 * 0x55555556) >> 0x20);
        local_150.__0x8 = 0x48;
        local_150.__0x20 = &local_d8;
        local_150.__0x44 = &local_98;
        local_98.M43 = 4.0f;
        local_98.M13 = asmreg_0_zero->Z;
        local_98.M23 = asmreg_0_zero->Z;
        local_98.M33 = asmreg_0_zero->Z;
        local_58.M13 = asmreg_0_zero->Z;
        local_58.M23 = asmreg_0_zero->Z;
        local_150.__0x1C = 0;
        local_98.M44 = 1.0f;
        local_150.__0xA = 0;
        local_150.__0x3C = 0;
        local_150.__0x38 = 0;
        local_150.__0x4 = (int)p_DAT_01340870_sphere_grid_layout_dat;
        local_150.__0xC = 0;
        local_150.__0x10 = 0;
        local_150.__0x14 = 0;
        local_150.__0x40 = 0;
        local_150.__0x2C = (Matrix4x4*)0;
        local_150.__0x28 = 0;
        local_150.__0x24 = 0;
        local_98.M11 = asmreg_0_zero->X;
        local_98.M12 = asmreg_0_zero->Y;
        local_98.M14 = asmreg_0_zero->W;
        local_98.M21 = asmreg_0_zero->X;
        local_98.M22 = asmreg_0_zero->Y;
        local_98.M24 = asmreg_0_zero->W;
        local_98.M31 = asmreg_0_zero->X;
        local_98.M32 = asmreg_0_zero->Y;
        local_98.M34 = asmreg_0_zero->W;
        local_98.M41 = asmreg_0_zero->X;
        local_98.M42 = asmreg_0_zero->Y;
        local_58.M12 = asmreg_0_zero->Y;
        local_58.M14 = asmreg_0_zero->W;
        local_58.M21 = asmreg_0_zero->X;
        local_58.M24 = asmreg_0_zero->W;
        local_58.M31 = asmreg_0_zero->X;
        local_58.M32 = asmreg_0_zero->Y;
        local_58.M34 = asmreg_0_zero->W;
        local_58.M11 = (float)((lpamng->__0x115A4 * 3.0 + 125.0) * 0.0007812500116415322);
        local_58.M41 = lpamng->__0x11520.X;
        local_58.M42 = lpamng->__0x11520.Y;
        local_58.M43 = 0.0f;
        local_58.M44 = 1.0f;
        local_58.M22 = local_58.M11;
        local_58.M33 = local_58.M11;
        cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &lpamng->__0x113E0, &local_58);
        FUN_006657c0.fnptr!(iVar4, &local_150, 4, &lpamng->__0x116A4);
        sVar1 = lpamng->__0x11698;
        uVar2 = custom_party_infos[lpamng->current_chr_id].current_node_idx;
        local_150.__0x8 = 0x48;
        local_150.__0x20 = &local_d8;
        local_150.__0x44 = &local_98;
        local_98.M43 = 3.0f;
        local_98.M44 = 1.0f;
        local_150.__0x1C = 0;
        local_150.__0xA = 0;
        local_150.__0x3C = 0;
        local_150.__0x38 = 0;
        local_150.__0x4 = (int)p_DAT_01340870_sphere_grid_layout_dat;
        local_150.__0xC = 0;
        local_150.__0x10 = 0;
        local_150.__0x14 = 0;
        local_150.__0x40 = 0;
        local_150.__0x2C = (Matrix4x4*)0;
        local_150.__0x28 = 0;
        local_150.__0x24 = 0;
        local_98.M11 = asmreg_0_zero->X;
        local_98.M12 = asmreg_0_zero->Y;
        local_98.M13 = asmreg_0_zero->Z;
        local_98.M14 = asmreg_0_zero->W;
        local_98.M21 = asmreg_0_zero->X;
        local_98.M22 = asmreg_0_zero->Y;
        local_98.M23 = asmreg_0_zero->Z;
        local_98.M24 = asmreg_0_zero->W;
        local_98.M31 = asmreg_0_zero->X;
        local_98.M32 = asmreg_0_zero->Y;
        local_98.M33 = asmreg_0_zero->Z;
        local_98.M34 = asmreg_0_zero->W;
        local_98.M41 = asmreg_0_zero->X;
        local_98.M42 = asmreg_0_zero->Y;
        local_58.M11 = asmreg_0_zero->X;
        local_58.M12 = asmreg_0_zero->Y;
        local_58.M43 = 0.0f;
        local_58.M44 = 1.0f;
        local_58.M21 = asmreg_0_zero->X;
        local_58.M31 = asmreg_0_zero->X;
        local_58.M41 = asmreg_0_zero->X;
        uVar5 = 0;
        local_58.M13 = asmreg_0_zero->Z;
        local_58.M14 = asmreg_0_zero->W;
        local_58.M22 = asmreg_0_zero->Y;
        local_58.M23 = asmreg_0_zero->Z;
        local_58.M24 = asmreg_0_zero->W;
        local_58.M32 = asmreg_0_zero->Y;
        local_58.M33 = asmreg_0_zero->Z;
        local_58.M34 = asmreg_0_zero->W;
        local_58.M42 = asmreg_0_zero->Y;
        local_150.__0x0 = 0x24;
        //pfVar6 = &custom_party_infos[0].pos_circle_radius;
        SphereGridChrInfo* chr_info = &custom_party_infos[0];
        do {
            fVar7 = 0.0012499999720603228;
            if (uVar5 == num_characters) {
                local_98.M43 = 2.0f;
            }
            //if ((0.0 < *pfVar6 != float.IsNaN(*pfVar6)) &&
            //   (((uVar2 != *(ushort*)(pfVar6 + 2) || (uVar5 == lpamng->current_chr_id)) || (uVar5 == 7)))) {
            if ((0.0 < chr_info->pos_circle_radius != float.IsNaN(chr_info->pos_circle_radius)) &&
               (((uVar2 != chr_info->current_node_idx || (uVar5 == lpamng->current_chr_id)) || (uVar5 == num_characters)))) {
                uStack_154 = (uStack_154 & 0xFFFFFF00) |
                     (uint)((int)Math.Round((eff_sin_t[(int)(uVar5 * 0x2000 + (uint)(ushort)(sVar1 << 0xb)) >> 4 &
                                                 0xfff] + 1.0f) * 16.0f) & 0xFF);
                local_150.rgba = (p_DAT_00c86660)[uVar5];
                local_150.a = (byte)((byte)uStack_154 + 0x60U);
                var halo_alpha = lpamng->halo_alpha;
                if (lpamng->halo_alpha < 1.0) {
                    uStack_154 = (byte)((byte)uStack_154 + 0x60U);
                    iVar4 = (int)(lpamng->halo_alpha * (float)uStack_154);
                    local_150.a = (byte)iVar4;
                    //fVar7 = extraout_ST0;
                }
                //local_58.M11 = (float)(fVar7 * *pfVar6);
                //local_58.M41 = (((SphereGridChrInfo*)(pfVar6 + -0xf))->pos).X;
                //local_58.M42 = pfVar6[-0xe];
                local_58.M11 = (float)(fVar7 * chr_info->pos_circle_radius);
                local_58.M41 = chr_info->pos.X;
                local_58.M42 = chr_info->pos.Y;
                local_58.M22 = local_58.M11;
                local_58.M33 = local_58.M11;
                cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &lpamng->__0x113E0, &local_58);
                FUN_006657c0.fnptr!(DAT_01f057f8, &local_150, 4, &lpamng->__0x116A4);
            }
            uVar5 = uVar5 + 1;
            //pfVar6 = pfVar6 + 0x14;
            chr_info += 1;
            if (uVar5 == num_characters) chr_info = (SphereGridChrInfo*)((int)lpamng + 0x112b8);
        } while ((int)uVar5 < num_characters+1);
        return;
    }

    void h_eiAbmStart() {
        float fVar1;
        short sVar2;
        short uVar3;
        short pSVar4;
        short pSVar5;
        LpAbilityMapEngine *plVar6;
        bool joined;
        FhLangId LVar7;
        //undefined3 extraout_var;
        uint uVar8;
        byte *pbVar9;
        LpAbilityMapEngine *plVar10;
        uint chr_id;
        //int iVar11;
        int chr_id_00;
        SphereGridMenuData *menuData;

        *p_DAT_01685f70 = 0;
        LVar7 = FhXCall.TOGetFFXLang.fnptr!();
        /* Japanese, Korean, Chinese, or Debug */
        if ((LVar7 == FhLangId.Japanese) || ((8 < (int)LVar7 && ((int)LVar7 < 0xc)))) {
            *p_DAT_01685f74 = 1;
        }
        else {
            *p_DAT_01685f74 = 0;
        }
        FUN_006572e0.fnptr!();
        FUN_00657620.fnptr!();
        FUN_00645570.fnptr!();
        TOMenuTransFacePlyTex.fnptr!();

        // Calculate node activation indicator positions
        for (int n = 0; n < 130; n++) {
            if (lpamng->node_type_infos[n].pos[0].x == 0x1000) {
                for (int i = 0; i < num_characters-7; i++) {
                    custom_node_indicator_pos[n, i] = lpamng->node_type_infos[n].pos[0];
                }
            } else {
                float offset = lpamng->node_type_infos[n].pos[0].xy.Length();

                float angle = (float)(2*Math.PI / num_characters);

                Vector2 vec = new Vector2(0, -1) * offset;

                for (int i = 0; i < num_characters; i ++) {
                    if (i < 7) {
                        lpamng->node_type_infos[n].pos[i] = new() { x = (short)vec.X, y = (short)vec.Y };
                    } else {
                        custom_node_indicator_pos[n, i - 7] = new() { x = (short)vec.X, y = (short)vec.Y };
                    }

                    vec = Vector2.Transform(vec, Quaternion.CreateFromAxisAngle(new(0, 0, 1), angle));
                }
            }
        }

        chr_id = 0;
        lpamng->available_indicators = 0;
        do {
            joined = FhXCall.MsGetSavePlyJoined.fnptr!((byte)chr_id);
            if (joined) {
                lpamng->available_indicators.set_bit((int)chr_id, joined);
                FUN_00657f80.fnptr!(chr_id, 0, 0x40000000, 0x80404040, 0x80404040, 0x80808080);
            }
            chr_id = chr_id + 1;
        } while ((int)chr_id < num_characters);
        FUN_00649590.fnptr!();
        chr_id_00 = 0;
        //iVar11 = 0;
        plVar10 = lpamng;
        do {
            //fVar1 = *(float*)((int)&custom_party_infos[0].pos_circle_radius + iVar11);
            ///* ... ignore casts, iVar11 is basically the index */
            //if (0.0 < fVar1 != float.IsNaN(fVar1)) {
            //    uVar3 = *(ushort*)((int)&custom_party_infos[0].current_node_idx + iVar11);
            //    *(float*)((int)&custom_party_infos[0].pos.x + iVar11) = (float)(int)plVar10->nodes[uVar3].x
            //    ;
            //    *(float*)((int)&custom_party_infos[0].pos.y + iVar11) = (float)(int)plVar10->nodes[uVar3].y
            //    ;
            //    *(undefined4*)((int)&custom_party_infos[0].pos.z + iVar11) = 0;
            //    *(undefined4*)((int)&custom_party_infos[0].pos.w + iVar11) = 0x3f800000;
            //    plVar6 = lpamng;
            //    *(float*)((int)&custom_party_infos[0].pos_circle_radius + iVar11) =
            //         (float)(int)(lpamng->node_type_infos
            //                      [lpamng->nodes
            //                       [*(ushort*)((int)&custom_party_infos[0].current_node_idx + iVar11)].
            //                       node_type].width >> 1) + 3.0;
            //    FUN_00a58080(plVar6, plVar10, chr_id_00);
            //    plVar10 = lpamng;
            //}
            //iVar11 = iVar11 + 0x50;
            //chr_id_00 = chr_id_00 + 1;

            ref SphereGridChrInfo chr_info = ref custom_party_infos[chr_id_00];
            fVar1 = chr_info.pos_circle_radius;
            if (0.0 < fVar1 != float.IsNaN(fVar1)) {
                uVar3 = chr_info.current_node_idx;
                chr_info.pos.X = plVar10->nodes[uVar3].x;
                chr_info.pos.Y = plVar10->nodes[uVar3].y;
                chr_info.pos.Z = 0;
                chr_info.pos.W = 1.0f;
                plVar6 = lpamng;
                chr_info.pos_circle_radius =
                     (float)(int)(lpamng->node_type_infos
                                  [(int)lpamng->nodes
                                   [chr_info.current_node_idx].
                                   node_type].width >> 1) + 3.0f;
                FUN_00658080.fnptr!(chr_id_00);
                plVar10 = lpamng;
            }
            //iVar11 = iVar11 + 0x50;
            chr_id_00 = chr_id_00 + 1;
        //} while (iVar11 < 0x230);
        } while (chr_id_00 < num_characters);
        plVar10->__0x115C7 = 1;
        plVar10 = lpamng;
        uVar3 = custom_party_infos[lpamng->current_chr_id].current_node_idx;
        lpamng->selected_node_idx = uVar3;
        (plVar10->__0x112B8).X = plVar10->nodes[uVar3].x;
        (plVar10->__0x112B8).Y = plVar10->nodes[uVar3].y;
        (plVar10->__0x112B8).Z = 0.0f;
        (plVar10->__0x112B8).W = 1.0f;
        sVar2 = lpamng->node_type_infos[(int)lpamng->nodes[uVar3].node_type].width;
        plVar10->__0x11306 = 0;
        plVar10->__0x112D8 = 0x80808080;
        plVar10->__0x112DC = 0x80808080;
        plVar10->current_halo_width = (sVar2 >> 1) + 3.0f;
        plVar10->__0x112E0 = 0x80ffffff;
        plVar10->__0x112F8 = 0x40000000;
        plVar10 = lpamng;
        (lpamng->cam_desired_pos).X = (lpamng->__0x112B8).X;
        (plVar10->cam_desired_pos).Y = (plVar10->__0x112B8).Y;
        (plVar10->cam_desired_pos).Z = (plVar10->__0x112B8).Z;
        (plVar10->cam_desired_pos).W = (plVar10->__0x112B8).W;
        lpamng->link_points = SphereGridLinkPoint_ARRAY_01693160;
        FUN_0065a800.fnptr!();
        FUN_00657120.fnptr!();
        FUN_0065b030.fnptr!();
        pppInitEnv.fnptr!(p_DAT_01686034, DAT_01f05800, p_DAT_012c1830, 0x7d000);
        menuData = sphere_grid_menu_ptr;
        menuData->menus[0].pos2.x = 0x30;
        menuData->menus[0].pos2.y = 0x23;
        menuData->menus[0].pos2.w = 0x1a0;
        menuData->menus[0].pos2.h = 0x14;
        menuData->menus[0].pos1.x = 0x30;
        menuData->menus[0].pos1.y = 0x23;
        menuData->menus[0].pos1.w = 0x1a0;
        menuData->menus[0].pos1.h = 0x14;
        menuData->menus[0].something2 = 0x1a;
        menuData->menus[0].max_lines2 = 1;
        menuData->menus[0].something1 = 0x1a;
        menuData->menus[0].max_lines1 = 1;
        menuData->menus[0].num_entries = 0;
        menuData->menus[0].__0x20 = 0xf;
        menuData->menus[0].num_columns = 0x101;
        menuData->menus[0].func2 = FhUtil.ptr_at<nint>(0x64F930); // FUN_00a4f930
        menuData->menus[0].func3 = FhUtil.ptr_at<nint>(0x6570A0); // FUN_00a570a0
        menuData->menus[0].__0x18 = 0;
        menuData->menus[0].__0x25 = 0;
        menuData->menus[0].__0x24 = 0;
        menuData->menus[0].is_full = false;
        menuData->menus[0].func1 = (void*)0;
        *(uint*)&menuData->menus[7].pos2 = 0x00cd0030;
        menuData->menus[7].pos2.w = 0x50;
        menuData->menus[7].pos2.h = 0x28;
        *(uint*)&menuData->menus[7].pos1 = 0x00cd0030;
        menuData->menus[7].pos1.w = 0x50;
        menuData->menus[7].pos1.h = 0x28;
        menuData->menus[7].something2 = 5;
        menuData->menus[7].max_lines2 = 2;
        menuData->menus[7].something1 = 5;
        menuData->menus[7].max_lines1 = 2;
        menuData->menus[7].num_columns = 1;
        menuData->menus[7].func2 = FhUtil.ptr_at<nint>(0x64F930); // FUN_00a4f930
        menuData->menus[7].func3 = FhUtil.ptr_at<nint>(0x6570A0); // FUN_00a570a0
        if (*p_DAT_01685f74 == 0) {
            menuData->menus[7].num_entries = 0;
            menuData->menus[7].__0x20 = 10;
        }
        else {
            menuData->menus[7].num_entries = 0;
            menuData->menus[7].__0x20 = 0x12;
        }
        menuData->menus[7].func1 = (void*)0;
        menuData->menus[7].is_full = false;
        menuData->menus[7].__0x24 = 0;
        menuData->menus[7].__0x25 = 0;
        menuData->menus[7].__0x18 = 0;
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.mmain_txt, 0x1f, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[7].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[7].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[7].num_columns *
                      (int)sphere_grid_menu_ptr->menus[7].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[7].num_entries = (short)(sVar2 + 1);
            menuData->menus[7].entries[sVar2].text = (int)pbVar9;
            menuData->menus[7].entries[sVar2].unknown2 = 0x1f;
            *(byte*)&menuData->menus[7].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.mmain_txt, 0x1e, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[7].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[7].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[7].num_columns *
                      (int)sphere_grid_menu_ptr->menus[7].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[7].num_entries = (short)(sVar2 + 1);
            menuData->menus[7].entries[sVar2].text = (int)pbVar9;
            menuData->menus[7].entries[sVar2].unknown2 = 0x1e;
            *(byte*)&menuData->menus[7].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
            menuData = sphere_grid_menu_ptr;
        }
        *(uint*)&menuData->menus[8].pos2 = 0x00cd0030;
        *(uint*)&menuData->menus[8].pos1 = 0x00cd0030;
        menuData->menus[8].num_entries = 0;
        menuData->menus[8].__0x20 = 8;
        menuData->menus[8].num_columns = 1;
        menuData->menus[8].func2 = FhUtil.ptr_at<nint>(0x64F630); // FUN_00a4f630
        menuData->menus[8].func3 = FhUtil.ptr_at<nint>(0x657040); // FUN_00a57040
        menuData->menus[8].__0x18 = 0;
        menuData->menus[8].__0x25 = 0;
        menuData->menus[8].__0x24 = 0;
        menuData->menus[8].is_full = false;
        menuData->menus[8].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            menuData->menus[8].pos2.w = 0xb0;
            menuData->menus[8].pos2.h = 0x50;
            menuData->menus[8].pos1.w = 0xb0;
            menuData->menus[8].pos1.h = 0x50;
            menuData->menus[8].something2 = 0xb;
            menuData->menus[8].max_lines2 = 4;
            menuData->menus[8].something1 = 0xb;
            menuData->menus[8].max_lines1 = 4;
        }
        else {
            menuData->menus[8].pos2.w = 0x90;
            menuData->menus[8].pos2.h = 0x50;
            menuData->menus[8].pos1.w = 0x90;
            menuData->menus[8].pos1.h = 0x50;
            menuData->menus[8].something2 = 9;
            menuData->menus[8].max_lines2 = 4;
            menuData->menus[8].something1 = 9;
            menuData->menus[8].max_lines1 = 4;
        }
        menuData->menus[8].num_entries = 0;
        FUN_00645fd0.fnptr!(8, 3);
        menuData = sphere_grid_menu_ptr;
        *(uint*)&sphere_grid_menu_ptr->menus[6].pos2 = 0x01640030;
        *(uint*)&menuData->menus[6].pos1 = 0x01640030;
        menuData->menus[6].num_entries = 0;
        menuData->menus[6].__0x20 = 0x14;
        menuData->menus[6].num_columns = 1;
        menuData->menus[6].func2 = FhUtil.ptr_at<nint>(0x64F9E0); // FUN_00a4f9e0;
        menuData->menus[6].__0x18 = 0;
        menuData->menus[6].__0x25 = 0;
        menuData->menus[6].__0x24 = 0;
        menuData->menus[6].is_full = false;
        menuData->menus[6].func3 = (void*)0x0;
        menuData->menus[6].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            menuData->menus[6].pos2.w = 0xb0;
            menuData->menus[6].pos2.h = 0x14;
            menuData->menus[6].pos1.w = 0xb0;
            menuData->menus[6].pos1.h = 0x14;
            menuData->menus[6].something2 = 0xb;
            menuData->menus[6].max_lines2 = 1;
            menuData->menus[6].something1 = 0xb;
            menuData->menus[6].max_lines1 = 1;
        }
        else {
            menuData->menus[6].pos2.w = 0x80;
            menuData->menus[6].pos2.h = 0x14;
            menuData->menus[6].pos1.w = 0x80;
            menuData->menus[6].pos1.h = 0x14;
            menuData->menus[6].something2 = 8;
            menuData->menus[6].max_lines2 = 1;
            menuData->menus[6].something1 = 8;
            menuData->menus[6].max_lines1 = 1;
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.mmain_txt, 0x23, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[6].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[6].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[6].num_columns *
                      (int)sphere_grid_menu_ptr->menus[6].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[6].num_entries = (short)(sVar2 + 1);
            menuData->menus[6].entries[sVar2].text = (int)pbVar9;
            menuData->menus[6].entries[sVar2].unknown2 = 0x23;
            *(byte*)&menuData->menus[6].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
            menuData = sphere_grid_menu_ptr;
        }
        menuData->menus[1].num_entries = 0;
        menuData->menus[1].__0x20 = 0x20;
        menuData->menus[1].num_columns = 2;
        menuData->menus[1].func2 = FhUtil.ptr_at<nint>(0x64FA30); // FUN_00a4fa30
        menuData->menus[1].__0x18 = 0;
        menuData->menus[1].__0x25 = 0;
        menuData->menus[1].__0x24 = 0;
        menuData->menus[1].is_full = false;
        menuData->menus[1].func3 = (void*)0x0;
        menuData->menus[1].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            *(uint*)&menuData->menus[1].pos2 = 0x01140088;
            menuData->menus[1].pos2.w = 0xf0;
            menuData->menus[1].pos2.h = 100;
            *(uint*)&menuData->menus[1].pos1 = 0x01140088;
            menuData->menus[1].pos1.w = 0xf0;
            menuData->menus[1].pos1.h = 100;
            menuData->menus[1].something2 = 0xf;
            menuData->menus[1].max_lines2 = 5;
            menuData->menus[1].something1 = 0xf;
            menuData->menus[1].max_lines1 = 5;
        }
        else {
            *(uint*)&menuData->menus[1].pos2 = 0x011400a0;
            menuData->menus[1].pos2.w = 0xc0;
            menuData->menus[1].pos2.h = 100;
            *(uint*)&menuData->menus[1].pos1 = 0x011400a0;
            menuData->menus[1].pos1.w = 0xc0;
            menuData->menus[1].pos1.h = 100;
            menuData->menus[1].something2 = 0xc;
            menuData->menus[1].max_lines2 = 5;
            menuData->menus[1].something1 = 0xc;
            menuData->menus[1].max_lines1 = 5;
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 0, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 0;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 1, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 1;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 7, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 2;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 0xb, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 3;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 8, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 4;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 0xc, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 5;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 9, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 6;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 0xd, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 7;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 10, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 8;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.status_txt, 0xe, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[1].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[1].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[1].num_columns *
                      (int)sphere_grid_menu_ptr->menus[1].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[1].num_entries = (short)(sVar2 + 1);
            menuData->menus[1].entries[sVar2].text = (int)pbVar9;
            menuData->menus[1].entries[sVar2].unknown2 = 9;
            *(byte*)&menuData->menus[1].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
            menuData = sphere_grid_menu_ptr;
        }
        menuData->menus[3].num_entries = 0;
        menuData->menus[3].__0x20 = 0x20;
        menuData->menus[3].num_columns = 3;
        menuData->menus[3].func2 = FhUtil.ptr_at<nint>(0x64F250); // FUN_00a4f250
        menuData->menus[3].__0x18 = 0;
        menuData->menus[3].__0x25 = 0;
        menuData->menus[3].__0x24 = 0;
        menuData->menus[3].is_full = false;
        menuData->menus[3].func3 = (void*)0x0;
        menuData->menus[3].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            *(uint*)&menuData->menus[3].pos2 = 0x00d80048;
            menuData->menus[3].pos2.w = 0x170;
            menuData->menus[3].pos2.h = 0xa0;
            *(uint*)&menuData->menus[3].pos1 = 0x00d80048;
            menuData->menus[3].pos1.w = 0x170;
            menuData->menus[3].pos1.h = 0xa0;
            menuData->menus[3].something2 = 0x17;
            menuData->menus[3].max_lines2 = 8;
            menuData->menus[3].something1 = 0x17;
            menuData->menus[3].max_lines1 = 8;
        }
        else {
            *(uint*)&menuData->menus[3].pos2 = 0x00d8005f;
            *(uint*)&menuData->menus[3].pos2.w = 0x00a00140;
            *(uint*)&menuData->menus[3].pos1 = 0x00d8005f;
            *(uint*)&menuData->menus[3].pos1.w = 0x00a00140;
            menuData->menus[3].something2 = 0x14;
            menuData->menus[3].max_lines2 = 8;
            menuData->menus[3].something1 = 0x14;
            menuData->menus[3].max_lines1 = 8;
        }
        FUN_006459e0.fnptr!(3, 0x40);
        menuData = sphere_grid_menu_ptr;
        menuData->menus[2].num_entries = 0;
        menuData->menus[2].__0x20 = 0x20;
        menuData->menus[2].func2 = FhUtil.ptr_at<nint>(0x64F9A0); // FUN_00a4f9a0
        menuData->menus[2].__0x18 = 0;
        menuData->menus[2].__0x25 = 0;
        menuData->menus[2].__0x24 = 0;
        menuData->menus[2].is_full = false;
        menuData->menus[2].func3 = (void*)0x0;
        menuData->menus[2].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            *(uint*)&menuData->menus[2].pos2 = 0x00d80048;
            menuData->menus[2].pos2.w = 0x170;
            menuData->menus[2].pos2.h = 0xa0;
            *(uint*)&menuData->menus[2].pos1 = 0x00d80048;
            menuData->menus[2].pos1.w = 0x170;
            menuData->menus[2].pos1.h = 0xa0;
            menuData->menus[2].something2 = 0x17;
            menuData->menus[2].max_lines2 = 8;
            menuData->menus[2].something1 = 0x17;
            menuData->menus[2].max_lines1 = 8;
            menuData->menus[2].num_columns = 3;
        }
        else {
            *(uint*)&menuData->menus[2].pos2 = 0x01000060;
            menuData->menus[2].pos2.w = 0x140;
            menuData->menus[2].pos2.h = 0x78;
            *(uint*)&menuData->menus[2].pos1 = 0x01000060;
            menuData->menus[2].pos1.w = 0x140;
            menuData->menus[2].pos1.h = 0x78;
            menuData->menus[2].something2 = 0x14;
            menuData->menus[2].max_lines2 = 6;
            menuData->menus[2].something1 = 0x14;
            menuData->menus[2].max_lines1 = 6;
            menuData->menus[2].num_columns = 4;
        }
        FUN_006459e0.fnptr!(2, 0x41);
        menuData = sphere_grid_menu_ptr;
        menuData->menus[4].num_entries = 0;
        menuData->menus[4].__0x20 = 0x20;
        menuData->menus[4].num_columns = 4;
        menuData->menus[4].func2 = FhUtil.ptr_at<nint>(0x64F250); // FUN_00a4f250;
        menuData->menus[4].__0x18 = 0;
        menuData->menus[4].__0x25 = 0;
        menuData->menus[4].__0x24 = 0;
        menuData->menus[4].is_full = false;
        menuData->menus[4].func3 = (void*)0x0;
        menuData->menus[4].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            *(uint*)&menuData->menus[4].pos2 = 0x01000040;
            menuData->menus[4].pos2.w = 0x180;
            menuData->menus[4].pos2.h = 0x78;
            *(uint*)&menuData->menus[4].pos1 = 0x01000040;
            menuData->menus[4].pos1.w = 0x180;
            menuData->menus[4].pos1.h = 0x78;
            menuData->menus[4].something2 = 0x18;
            menuData->menus[4].max_lines2 = 6;
            menuData->menus[4].something1 = 0x18;
            menuData->menus[4].max_lines1 = 6;
        }
        else {
            *(uint*)&menuData->menus[4].pos2 = 0x01000060;
            menuData->menus[4].pos2.w = 0x140;
            menuData->menus[4].pos2.h = 0x78;
            *(uint*)&menuData->menus[4].pos1 = 0x01000060;
            menuData->menus[4].pos1.w = 0x140;
            menuData->menus[4].pos1.h = 0x78;
            menuData->menus[4].something2 = 0x14;
            menuData->menus[4].max_lines2 = 6;
            menuData->menus[4].something1 = 0x14;
            menuData->menus[4].max_lines1 = 6;
        }
        FUN_006459e0.fnptr!(4, 0x45);
        menuData = sphere_grid_menu_ptr;
        menuData->menus[5].num_entries = 0;
        menuData->menus[5].__0x20 = 0x20;
        menuData->menus[5].num_columns = 4;
        menuData->menus[5].func2 = FhUtil.ptr_at<nint>(0x64F250); // FUN_00a4f250;
        menuData->menus[5].__0x18 = 0;
        menuData->menus[5].__0x25 = 0;
        menuData->menus[5].__0x24 = 0;
        menuData->menus[5].is_full = false;
        menuData->menus[5].func3 = (void*)0x0;
        menuData->menus[5].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            *(uint*)&menuData->menus[5].pos2 = 0x01140040;
            menuData->menus[5].pos2.w = 0x180;
            menuData->menus[5].pos2.h = 100;
            *(uint*)&menuData->menus[5].pos1 = 0x01140040;
            menuData->menus[5].pos1.w = 0x180;
            menuData->menus[5].pos1.h = 100;
            menuData->menus[5].something2 = 0x18;
            menuData->menus[5].max_lines2 = 5;
            menuData->menus[5].something1 = 0x18;
            menuData->menus[5].max_lines1 = 5;
        }
        else {
            *(uint*)&menuData->menus[5].pos2 = 0x01140060;
            menuData->menus[5].pos2.w = 0x140;
            menuData->menus[5].pos2.h = 100;
            *(uint*)&menuData->menus[5].pos1 = 0x01140060;
            menuData->menus[5].pos1.w = 0x140;
            menuData->menus[5].pos1.h = 100;
            menuData->menus[5].something2 = 0x14;
            menuData->menus[5].max_lines2 = 5;
            menuData->menus[5].something1 = 0x14;
            menuData->menus[5].max_lines1 = 5;
        }
        FUN_006459e0.fnptr!(5, 0x44);
        menuData = sphere_grid_menu_ptr;
        *(uint*)&sphere_grid_menu_ptr->menus[9].pos2 = 0x00cd0030;
        *(uint*)&menuData->menus[9].pos1 = 0x00cd0030;
        menuData->menus[9].num_entries = 0;
        menuData->menus[9].__0x20 = 10;
        menuData->menus[9].num_columns = 1;
        menuData->menus[9].func2 = FhUtil.ptr_at<nint>(0x64FB70); // FUN_00a4fb70
        menuData->menus[9].__0x18 = 0;
        menuData->menus[9].__0x25 = 0;
        menuData->menus[9].__0x24 = 0;
        menuData->menus[9].is_full = false;
        menuData->menus[9].func3 = (void*)0x0;
        menuData->menus[9].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            menuData->menus[9].pos2.w = 0x90;
            menuData->menus[9].pos2.h = 0x14;
            menuData->menus[9].pos1.w = 0x90;
            menuData->menus[9].pos1.h = 0x14;
            menuData->menus[9].something2 = 9;
            menuData->menus[9].max_lines2 = 1;
            menuData->menus[9].something1 = 9;
            menuData->menus[9].max_lines1 = 1;
        }
        else {
            menuData->menus[9].pos2.w = 0x60;
            menuData->menus[9].pos2.h = 0x14;
            menuData->menus[9].pos1.w = 0x60;
            menuData->menus[9].pos1.h = 0x14;
            menuData->menus[9].something2 = 6;
            menuData->menus[9].max_lines2 = 1;
            menuData->menus[9].something1 = 6;
            menuData->menus[9].max_lines1 = 1;
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.mmain_txt, 0x2b, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[9].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[9].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[9].num_columns *
                      (int)sphere_grid_menu_ptr->menus[9].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[9].num_entries = (short)(sVar2 + 1);
            menuData->menus[9].entries[sVar2].text = (int)pbVar9;
            menuData->menus[9].entries[sVar2].unknown2 = 0x2b;
            *(byte*)&menuData->menus[9].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
            menuData = sphere_grid_menu_ptr;
        }
        *(uint*)&menuData->menus[10].pos2 = 0x00cd0030;
        *(uint*)&menuData->menus[10].pos1 = 0x00cd0030;
        menuData->menus[10].num_entries = 0;
        menuData->menus[10].__0x20 = 10;
        menuData->menus[10].num_columns = 1;
        menuData->menus[10].func2 = FhUtil.ptr_at<nint>(0x64FB70); // FUN_00a4fb70
        menuData->menus[10].__0x18 = 0;
        menuData->menus[10].__0x25 = 0;
        menuData->menus[10].__0x24 = 0;
        menuData->menus[10].is_full = false;
        menuData->menus[10].func3 = (void*)0x0;
        menuData->menus[10].func1 = (void*)0;
        if (*p_DAT_01685f74 == 0) {
            menuData->menus[10].pos2.w = 0x90;
            menuData->menus[10].pos2.h = 0x14;
            menuData->menus[10].pos1.w = 0x90;
            menuData->menus[10].pos1.h = 0x14;
            menuData->menus[10].something2 = 9;
            menuData->menus[10].max_lines2 = 1;
            menuData->menus[10].something1 = 9;
            menuData->menus[10].max_lines1 = 1;
        }
        else {
            menuData->menus[10].pos2.w = 0x70;
            menuData->menus[10].pos2.h = 0x14;
            menuData->menus[10].pos1.w = 0x70;
            menuData->menus[10].pos1.h = 0x14;
            menuData->menus[10].something2 = 7;
            menuData->menus[10].max_lines2 = 1;
            menuData->menus[10].something1 = 7;
            menuData->menus[10].max_lines1 = 1;
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.mmain_txt, 0x2e, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[10].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[10].num_entries = (short)(sVar2 + 1);
            menuData->menus[10].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[10].num_columns * sphere_grid_menu_ptr->menus[10].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[10].entries[sVar2].text = (int)pbVar9;
            menuData->menus[10].entries[sVar2].unknown2 = 0x2e;
            *(byte*)&menuData->menus[10].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
            menuData = sphere_grid_menu_ptr;
        }
        *(uint*)&menuData->menus[0xb].pos2 = 0x00f50030;
        menuData->menus[0xb].pos2.w = 0x50;
        menuData->menus[0xb].pos2.h = 0x28;
        *(uint*)&menuData->menus[0xb].pos1 = 0x00f50030;
        menuData->menus[0xb].pos1.w = 0x50;
        menuData->menus[0xb].pos1.h = 0x28;
        menuData->menus[0xb].something2 = 5;
        menuData->menus[0xb].max_lines2 = 2;
        menuData->menus[0xb].something1 = 5;
        menuData->menus[0xb].max_lines1 = 2;
        menuData->menus[0xb].num_entries = 0;
        menuData->menus[0xb].__0x20 = 0xf;
        menuData->menus[0xb].__0x18 = 0;
        menuData->menus[0xb].num_columns = 1;
        menuData->menus[0xb].__0x25 = 0;
        menuData->menus[0xb].__0x24 = 0;
        menuData->menus[0xb].is_full = false;
        menuData->menus[0xb].func2 = FhUtil.ptr_at<nint>(0x64F930); // FUN_00a4f930;
        menuData->menus[0xb].func3 = (void*)0x0;
        menuData->menus[0xb].func1 = (void*)0;
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.mmain_txt, 0x2c, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[0xb].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[0xb].num_entries = (short)(sVar2 + 1);
            menuData->menus[0xb].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[0xb].num_columns * sphere_grid_menu_ptr->menus[0xb].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[0xb].entries[sVar2].text = (int)pbVar9;
            menuData->menus[0xb].entries[sVar2].unknown2 = 0x2c;
            *(byte*)&menuData->menus[0xb].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        uVar8 = MsGetSaveConfigHiragana.fnptr!();
        pbVar9 = MsMenuGetText.fnptr!(MenuTextFile.mmain_txt, 0x2d, uVar8 & 1);
        menuData = sphere_grid_menu_ptr;
        sVar2 = sphere_grid_menu_ptr->menus[0xb].num_entries;
        if (sVar2 < 0x40) {
            sphere_grid_menu_ptr->menus[0xb].num_entries = (short)(sVar2 + 1);
            menuData->menus[0xb].is_full =
                 (int)((uint)(byte)sphere_grid_menu_ptr->menus[0xb].num_columns * sphere_grid_menu_ptr->menus[0xb].max_lines2) < (int)(short)(sVar2 + 1);
            menuData->menus[0xb].entries[sVar2].text = (int)pbVar9;
            menuData->menus[0xb].entries[sVar2].unknown2 = 0x2d;
            *(byte*)&menuData->menus[0xb].entries[sVar2].unknown1 = 0;
        }
        else {
            //dbgPrintf("addMenuPrim error!!!  menu->mprimn >= MAXMENUPRIM\n", 0x40);
            //debug_exit_trace(0);
        }
        graphicAbmapCreate.fnptr!(*(void**)&lpamng->__0x116A4);
        graphicDeActivateLoadingScreen.fnptr!();
        graphicSetFlipVsnc.fnptr!(2);
        *p_DAT_016860ec = (int)user_malloc.fnptr!(0x200);
        *p_DAT_016860f0 = (int)user_malloc.fnptr!(0x200);
        return;
    }

    void h_FUN_00a560d0(nint param_1, int param_2, nint param_3, int param_4) {
        SphereGridMenuData *pSVar1;
        bool bVar2;

        pSVar1 = sphere_grid_menu_ptr;
        if (param_4 != 0) {
            bVar2 = *p_DAT_01685f74 == 0;
            *(byte*)((int)&sphere_grid_menu_ptr->menus[8].num_columns + 1) = 1;
            *(int*)&pSVar1->menus[8].pos3 = 0x01640030;
            pSVar1->menus[8].__0x32 = 0;
            pSVar1->menus[8].func1 = FhUtil.ptr_at<nint>(0x65A080); // FUN_00a5a080
            if (bVar2) {
                pSVar1->menus[8].pos3.w = 0xb0;
                pSVar1->menus[8].pos3.h = 0x14;
            }
            else {
                pSVar1->menus[8].pos3.w = 0x90;
                pSVar1->menus[8].pos3.h = 0x14;
            }
            FUN_0065b980.fnptr!((uint)lpamng->current_chr_id,
                         custom_party_infos[lpamng->current_chr_id].current_node_idx,
                         (uint)*(ushort*)(param_2 + 8));
            return;
        }
        FUN_00659950.fnptr!();
        return;
    }

    void h_FUN_00a56160(nint param_1, int param_2, nint param_3, int param_4) {
        byte bVar1;
        SphereGridMenuData *pSVar2;
        LpAbilityMapEngine *plVar3;
        int iVar4;
        byte *pbVar5;

        FUN_0065b930.fnptr!();
        plVar3 = lpamng;
        if (param_3 == 0) {
            FhCall.SndSepPlaySimple.fnptr!(0x80000052);
            FUN_00386ef0.fnptr!(lpamng->current_chr_id, lpamng->slv_queued);
        }
        else if (param_3 == 1) {
            iVar4 = (int)lpamng->link_count;
            FhCall.SndSepPlaySimple.fnptr!(0x80000004);
            if (iVar4 != 0) {
                pbVar5 = &plVar3->links[0].activated_by;
                do {
                    iVar4 = iVar4 + -1;
                    if ((pbVar5[2] & 8) != 0) {
                        *pbVar5 = (byte)(*pbVar5 & ~(1 << (lpamng->current_chr_id & 0x1f)));
                        lpamng->should_update = 1;
                    }
                    pbVar5 = pbVar5 + 0x14;
                } while (iVar4 != 0);
            }
            plVar3 = lpamng;
            bVar1 = lpamng->moving_chr_id;
            custom_party_infos[bVar1].current_node_idx = lpamng->move_start_node_idx;
            FUN_0065a990.fnptr!(lpamng->moving_chr_id);
            FUN_00658080.fnptr!(lpamng->moving_chr_id);
            lpamng->__0x115C7 = 1;
            FUN_0065b030.fnptr!();
            FUN_00648d70.fnptr!(custom_party_infos[bVar1].current_node_idx, 0.5f);
            if (lpamng->__0x115B0 == 0) {
                lpamng->__0x115B0 = lpamng->__0x115A8;
                lpamng->__0x115A8 = (int)FhUtil.ptr_at<nint>(0x659E80); // FUN_00a59e80;
            }
        }
        iVar4 = lpamng->link_count;
        if (iVar4 != 0) {
            pbVar5 = &lpamng->links[0].__0xE;
            do {
                *pbVar5 = (byte)(*pbVar5 & 0xf0);
                pbVar5 = pbVar5 + 0x14;
                iVar4 = iVar4 + -1;
            } while (iVar4 != 0);
        }
        pSVar2 = sphere_grid_menu_ptr;
        *(byte*)((int)&sphere_grid_menu_ptr->menus[9].num_columns + 1) = 0;
        pSVar2->menus[7].pos2.x = pSVar2->menus[7].pos1.x;
        pSVar2->menus[7].pos2.y = pSVar2->menus[7].pos1.y;
        pSVar2->menus[7].pos2.w = pSVar2->menus[7].pos1.w;
        pSVar2->menus[7].pos2.h = pSVar2->menus[7].pos1.h;
        pSVar2->menus[7].something2 = pSVar2->menus[7].something1;
        pSVar2->menus[7].max_lines2 = pSVar2->menus[7].max_lines1;
        lpamng->slv_queued = 0;
        return;
    }

    int custom_TOGetEasyMesWFontLInterModeChrName(byte* name, int param_2) {
        float fVar1;
        int in_EAX;
        float char_width;
        int width_sum;
        byte cur_char;

        width_sum = 0;
        cur_char = *name;
        *p_DAT_014663e8 = 0;
        while (cur_char != 0x0) {
            name = FUN_004b7c00.fnptr!(name, 0, &char_width, param_2);
            width_sum = (int)(width_sum + char_width);
            *p_DAT_014663e8 = *p_DAT_014663e8 + 1;
            cur_char = *name;
        }
        return width_sum;
    }

    void h_FUN_00a57f80(uint chr_id, int node_idx, uint param_3, uint param_4, uint param_5, uint param_6) {
        float x;
        LpAbilityMapEngine *plVar1;
        byte *chr_name;
        int name_width_int;
        SphereGridChrInfo *chr_info;
        float name_width;
        short node_size;
        _logger.Debug($"{chr_id}");

        plVar1 = lpamng;
        chr_info = &custom_party_infos[(int)chr_id];
        chr_info->current_node_idx = (short)node_idx;
        (chr_info->pos).X = (float)(int)plVar1->nodes[node_idx].x;
        (chr_info->pos).Y = (float)(int)plVar1->nodes[node_idx].y;
        (chr_info->pos).Z = 0.0f;
        (chr_info->pos).W = 1.0f;
        node_size = lpamng->node_type_infos[(int)lpamng->nodes[node_idx].node_type].width;
        chr_info->a = param_4;
        chr_info->b = param_5;
        chr_info->pos_circle_radius = (node_size >> 1) + 3.0f;
        chr_info->__0x4E = 0;
        chr_info->c = param_6;
        chr_info->__0x40 = param_3;
        if ((int)chr_id < num_characters) {
            chr_name = FhXCall.TOGetSaveChrName.fnptr!((int)chr_id);
            chr_info->chr_name = chr_name;
            //TOGetEasyMesWFontLInterModeChrName(chr_name, 0x1);
            //x = (float)name_width;
            int width = custom_TOGetEasyMesWFontLInterModeChrName(chr_name, 0x1);
            x = width;
            if (x < 32.0f != float.IsNaN(x)) {
                x = 32.0f;
            }
            name_width_int = (int)x;
            chr_info->name_width = (short)name_width_int;
            chr_info->__0x32 = 0x10;
        }
        return;
    }

    void h_FUN_00a58080(int chr_id) {
        ushort uVar1;
        short pos_y;
        uint uVar2;
        short pos_x;
        uint uVar3;
        SphereGridChrInfo *chr_info;
        if (chr_id >= num_characters) {
            // last character + 1 is valid
            chr_info = (SphereGridChrInfo*)((int)lpamng + 0x112b8);
            return;
        } else {
            chr_info = &custom_party_infos[chr_id];
        }
        uVar1 = (ushort)(chr_info->__0x4E * 0x4000 + 0x2000);
        FUN_00647c60.fnptr!(chr_info);
        (chr_info->label_pos).X =
             eff_sin_t[(int)(uVar1 + 0x4000) >> 4 & 0xfff] * chr_info->pos_circle_radius +
             (chr_info->pos).X;
        (chr_info->label_pos).Y = (chr_info->pos).Y - eff_sin_t[uVar1 >> 4] * chr_info->pos_circle_radius;
        (chr_info->label_pos).Z = 0.0f;
        (chr_info->label_pos).W = 1.0f;
        uVar2 = DAT_01f05814;
        uVar3 = DAT_01f05818;
        if ((chr_info->__0x4E & 4) == 0) {
            uVar2 = DAT_01f0581c;
            uVar3 = DAT_01f05820;
        }
        pos_y = (short)uVar2;
        pos_x = (short)uVar3;
        /* Different label rendering positions */
        switch (chr_info->__0x4E & 3) {
            case 0:
                /* Topright */
                chr_info->__0x48 = (short)-pos_y;
                chr_info->__0x46 = pos_x;
                chr_info->__0x4A = DAT_01f05810;
                chr_info->__0x4C = DAT_01f05808;
                return;
            case 1:
                /* Topleft */
                chr_info->__0x48 = (short)-pos_y;
                chr_info->__0x46 = (short)-pos_x;
                chr_info->__0x4A = (short)-((short)DAT_01f05830 + (short)DAT_01f0580c);
                chr_info->__0x4C = DAT_01f05808;
                return;
            case 2:
                /* Bottomleft */
                chr_info->__0x48 = pos_y;
                chr_info->__0x46 = (short)-pos_x;
                chr_info->__0x4A = (short)-((short)DAT_01f05830 + (short)DAT_01f0580c);
                chr_info->__0x4C = DAT_01f05804;
                return;
            case 3:
                /* Bottomright */
                chr_info->__0x46 = pos_x;
                chr_info->__0x48 = pos_y;
                chr_info->__0x4A = DAT_01f05810;
                chr_info->__0x4C = DAT_01f05804;
                return;
        }
        return;
    }

    void h_FUN_00a58ec0() {
        byte bVar1;

        if (lpamng->__0x115B0 != 0) {
            return;
        }
        if ((lpamng->abmap_input[3] & 4) == 0) {
            if ((lpamng->abmap_input[3] & 8) == 0) goto LAB_00a58fdb;
            lpamng->__0x115BE = 2;
            FUN_004aaf10.fnptr!();
        }
        else {
            FUN_004aafa0.fnptr!();
            lpamng->__0x115BE = 1;
        }
        lpamng->__0x115BF = 0;
        lpamng->__0x115BD = lpamng->current_chr_id;
        bVar1 = TkMenuGetCurrentPlayer.fnptr!();
        lpamng->current_chr_id = bVar1;
        if (lpamng->__0x115BD == lpamng->current_chr_id) {
            lpamng->__0x115BE = 0;
        }
        else {
            lpamng->should_update = 1;
            lpamng->should_update_node = -1;
            FhCall.SndSepPlaySimple.fnptr!(0x80000004);
        }
        FUN_00648d70.fnptr!(custom_party_infos[lpamng->current_chr_id].current_node_idx, 0.25f);
        if (lpamng->__0x115B0 == 0) {
            lpamng->__0x115B0 = lpamng->__0x115A8;
            lpamng->__0x115A8 = (int)FhUtil.ptr_at<nint>(0x659E80); // FUN_00a59e80;
        }
        FUN_00647210.fnptr!();
        FUN_0065aca0.fnptr!();
    LAB_00a58fdb:
        FUN_0065b030.fnptr!();
        return;
    }


    void h_FUN_00a598a0() {
        short uVar1;
        SphereGridMenuData *pSVar2;
        int iVar3;
        int iVar4;
        int *piVar5;

        pSVar2 = sphere_grid_menu_ptr;
        uVar1 = custom_party_infos[lpamng->current_chr_id].current_node_idx;
        iVar4 = 0;
        if (0 < sphere_grid_menu_ptr->menus[8].num_entries) {
            piVar5 = &sphere_grid_menu_ptr->menus[8].entries[0].unknown1;
            do {
                iVar3 = FUN_00649310.fnptr!(lpamng->current_chr_id, uVar1, (uint)(piVar5[1] & 0xffff));
                *(bool*)piVar5 = iVar3 == 0;
                iVar4 = iVar4 + 1;
                piVar5 = piVar5 + 3;
            } while (iVar4 < pSVar2->menus[8].num_entries);
        }
        pSVar2 = sphere_grid_menu_ptr;
        *(short*)((int)&sphere_grid_menu_ptr->menus[8].num_columns + 1) = 0x301;
        *(byte*)&pSVar2->menus[8].__0x25 = 1;
        *(short*)&pSVar2->__0x2700 = 8;
        pSVar2->func = FhUtil.ptr_at<nint>(0x6560d0); // FUN_00a560d0;
        return;
    }

    void h_FUN_00a59990() {
        byte *puVar1;
        float fVar2;
        short uVar3;
        LpAbilityMapEngine *plVar4;
        short uVar5;
        int iVar6;
        SphereGridChrInfo *pSVar7;
        float fVar8;
        Vector4 local_58 = new();
        SphereGridLink* local_44;
        //int local_40;
        //float fStack_3c;
        Vector4 local_38 = new();
        Vector4 local_28 = new();
        Vector4 local_18 = new();

        plVar4 = lpamng;
        puVar1 = &lpamng->moving_chr_id;
        lpamng->moving_progress = lpamng->moving_speed + lpamng->moving_progress;
        pSVar7 = &custom_party_infos[*puVar1];
        if (lpamng->should_update == 0) {
            lpamng->should_update = 1;
        }
        local_18.X = (float)lpamng->nodes[lpamng->move_next_target_node_idx].x;
        //local_44 = (ushort*)(int)lpamng->nodes[lpamng->move_next_target_node_idx].y;
        //local_18.Y = (float)(int)local_44;
        local_18.Y = (float)lpamng->nodes[lpamng->move_next_target_node_idx].y;
        fVar2 = lpamng->moving_progress;
        if (!float.IsNaN(fVar2) && 1.0f < fVar2 != (fVar2 == 1.0f)) {
            do {
                local_18.W = 1.0f;
                local_18.Z = 0.0f;
                lpamng->next_move_link = (SphereGridLink*)0;
                plVar4 = lpamng;
                if (lpamng->move_next_target_node_idx == lpamng->move_last_target_node_idx) {
                //LAB_00a59d91:
                    (pSVar7->pos).X = local_18.X;
                    (pSVar7->pos).Y = local_18.Y;
                    (pSVar7->pos).Z = local_18.Z;
                    (pSVar7->pos).W = local_18.W;
                    lpamng->__0x115C7 = 1;
                    lpamng->__0x115A8 = lpamng->__0x115B0;
                    lpamng->__0x115B0 = 0;
                    return;
                }
                uVar5 = AbmapFindNextConnectingNode.fnptr!(lpamng->move_next_target_node_idx, lpamng->move_last_target_node_idx,
                                     &local_44);
                plVar4->move_next_target_node_idx = uVar5;
                //if (*(short*)&lpamng->move_next_target_node_idx == -1) goto LAB_00a59d91;
                if (*(short*)&lpamng->move_next_target_node_idx == -1) {
                    (pSVar7->pos).X = local_18.X;
                    (pSVar7->pos).Y = local_18.Y;
                    (pSVar7->pos).Z = local_18.Z;
                    (pSVar7->pos).W = local_18.W;
                    lpamng->__0x115C7 = 1;
                    lpamng->__0x115A8 = lpamng->__0x115B0;
                    lpamng->__0x115B0 = 0;
                    return;
                }
                lpamng->move_next_link_anchor_idx = local_44->anchor_idx;
                if ((byte)(local_44->activated_by & (byte)(1 << (lpamng->moving_chr_id & 0x1f))) == 0) {
                    local_44->activated_by = (byte)(1 << (lpamng->moving_chr_id & 0x1f) | local_44->activated_by);
                    local_44->__0xE = (byte)(local_44->__0xE | 8);
                    lpamng->next_move_link = local_44;
                }
                pSVar7->current_node_idx = lpamng->move_next_target_node_idx;
                plVar4 = lpamng;
                (lpamng->move_prev_node_pos).X = (pSVar7->pos).X;
                (plVar4->move_prev_node_pos).Y = (pSVar7->pos).Y;
                (plVar4->move_prev_node_pos).Z = (pSVar7->pos).Z;
                (plVar4->move_prev_node_pos).W = (pSVar7->pos).W;
                local_18.X = (float)lpamng->nodes[lpamng->move_next_target_node_idx].x;
                //iVar6 = (int)lpamng->nodes[*(ushort*)&lpamng->move_next_target_node_idx].y;
                //_local_40 = CONCAT44(iVar6, local_40);
                //local_18.y = (float)iVar6;
                local_18.Y = (float)lpamng->nodes[lpamng->move_next_target_node_idx].y;
                asmreg_vf9->X = (lpamng->move_prev_node_pos).X;
                asmreg_vf9->Y = (lpamng->move_prev_node_pos).Y;
                asmreg_vf10->X = local_18.X - asmreg_vf9->X;
                asmreg_vf9->Z = (lpamng->move_prev_node_pos).Z;
                asmreg_vf9->W = (lpamng->move_prev_node_pos).W;
                asmreg_vf10->Y = local_18.Y - asmreg_vf9->Y;
                asmreg_vf10->W = local_18.W;
                asmreg_vf10->Z = local_18.Z - asmreg_vf9->Z;
                restoreVf00Register.fnptr!();
                local_38.X = asmreg_vf10->X;
                local_38.Y = asmreg_vf10->Y;
                local_38.Z = asmreg_vf10->Z;
                asmreg_vf10->Y = asmreg_vf10->Y * asmreg_vf10->Y;
                local_38.W = asmreg_vf10->W;
                asmreg_vf10->Z = asmreg_vf10->Z * asmreg_vf10->Z;
                asmreg_vf10->X = asmreg_vf10->Z + asmreg_vf10->Y + asmreg_vf10->X * asmreg_vf10->X;
                //_local_40 = CONCAT44(ABS(asmreg_vf10->x), local_40);
                //fVar8 = CIsqrt((float10)ABS.fnptr!(asmreg_vf10->x));
                fVar8 = (float)Math.Sqrt(Math.Abs(asmreg_vf10->X));
                *_asmreg_Q = (float)fVar8;
                asmreg_vf10->X = asmreg_vf0->X + *_asmreg_Q;
                if (0.0f < asmreg_vf10->X == float.IsNaN(asmreg_vf10->X)) {
                    fVar2 = 0.53333336f;
                }
                else {
                    fVar2 = 8.0f / asmreg_vf10->X;
                }
                lpamng->moving_speed = fVar2;
                plVar4 = lpamng;
                lpamng->moving_progress = lpamng->moving_progress - 1.0f;
                lpamng->moving_halo_start_width = pSVar7->pos_circle_radius;
                iVar6 = (int)(lpamng->node_type_infos[(int)lpamng->nodes[pSVar7->current_node_idx].node_type].width
                             >> 1);
                lpamng->moving_halo_target_width = (float)iVar6 + 3.0f;
                //local_40 = SUB84((double)iVar6, 0);
                local_18.X = (float)(int)lpamng->nodes[lpamng->move_next_target_node_idx].x;
                iVar6 = (int)lpamng->nodes[lpamng->move_next_target_node_idx].y;
                //_local_40 = CONCAT44(iVar6, local_40);
                local_18.Y = (float)iVar6;
                fVar2 = plVar4->moving_progress;
            } while (!float.IsNaN(fVar2) && 1.0f < fVar2 != (fVar2 == 1.0f));
        }
        local_18.W = 1.0f;
        local_18.Z = 0.0f;
        uVar3 = lpamng->move_next_link_anchor_idx;
        if (uVar3 == -1) {
            FFXVu0InterVectorXYZ.fnptr!
                      (&local_28, &local_18, &lpamng->move_prev_node_pos,
                       lpamng->moving_progress);
            (pSVar7->pos).X = local_28.X;
            (pSVar7->pos).Y = local_28.Y;
        }
        else {
            local_58.X = (float)lpamng->nodes[uVar3].x;
            local_58.Y = (float)lpamng->nodes[uVar3].y;
            local_58.Z = 0.0f;
            local_58.W = 1.0f;
            FUN_006563b0.fnptr!(&pSVar7->pos, &lpamng->move_prev_node_pos, &local_18, &local_58,
                         lpamng->moving_progress);
        }
        pSVar7->pos_circle_radius =
             (lpamng->moving_halo_target_width - lpamng->moving_halo_start_width) *
             lpamng->moving_progress + lpamng->moving_halo_start_width;
        lpamng->__0x115C7 = 1;
        FUN_0065b030.fnptr!();
        return;
    }

    void h_FUN_00a5a4b0() {
        bool bVar1;
        uint uVar2;
        SphereGridChrInfo *pSVar3;
        //undefined3 extraout_var;
        //undefined3 extraout_var_00;
        Vector4 *pfVar4;
        int iVar5;
        int chr_id;
        Vector4 *pfVar6;
        int local_80;
        int local_7c;
        Vector4[] _local_78 = new Vector4[num_characters];

        fixed (Vector4* local_78 = _local_78) {
            chr_id = 0;
            iVar5 = 0;
            do {
                (&custom_party_infos[0].__0x4E)[iVar5] = 0;
                FUN_00658080.fnptr!(chr_id);
                iVar5 = iVar5 + 0x50;
                chr_id = chr_id + 1;
            //} while (iVar5 < 0x230);
            } while (chr_id < num_characters);
            local_7c = 0;
            uVar2 = lpamng->current_chr_id;
            pfVar4 = local_78;
            do {
                pSVar3 = &custom_party_infos[(int)uVar2];
                FUN_006482d0.fnptr!(pSVar3, pfVar4);
                do {
                    iVar5 = 0;
                    pfVar6 = local_78;
                    while (true) {
                        if (local_7c <= iVar5) goto LAB_00a5a56c;
                        bVar1 = FUN_00649270.fnptr!(pfVar4, pfVar6);
                        //if (CONCAT31(extraout_var, bVar1) != 0) break;
                        if (bVar1) break;
                        iVar5 = iVar5 + 1;
                        pfVar6 = pfVar6 + 1;
                    }
                    pSVar3->__0x4E = (byte)(pSVar3->__0x4E + 1);
                    FUN_00658080.fnptr!((int)uVar2);
                    FUN_006482d0.fnptr!(pSVar3, pfVar4);
                } while (pSVar3->__0x4E < num_characters);
            LAB_00a5a56c:
                local_7c = local_7c + 1;
                pfVar4 = pfVar4 + 1;
                uVar2 = (uint)(((num_characters - 1) < (int)(uVar2 + 1) ? 1 : 0) - 1 & uVar2 + 1);
            } while (local_7c < num_characters);
            uVar2 = lpamng->current_chr_id;
            local_80 = 0;
            pfVar4 = local_78;
            do {
                pSVar3 = &custom_party_infos[(int)uVar2];
                do {
                    iVar5 = 0;
                    pfVar6 = local_78;
                    while (true) {
                        if ((num_characters - 1) < iVar5) goto LAB_00a5a606;
                        if ((local_80 != iVar5) &&
                        //   (bVar1 = FUN_00a49270(pfVar4, pfVar6), CONCAT31(extraout_var_00, bVar1) != 0)) break;
                             FUN_00649270.fnptr!(pfVar4, pfVar6)) break;
                        iVar5 = iVar5 + 1;
                        pfVar6 = pfVar6 + 1;
                    }
                    pSVar3->__0x4E = (byte)(pSVar3->__0x4E + 1);
                    FUN_00658080.fnptr!((int)uVar2);
                    FUN_006482d0.fnptr!(pSVar3, pfVar4);
                } while (pSVar3->__0x4E < num_characters);
            LAB_00a5a606:
                local_80 = local_80 + 1;
                pfVar4 = pfVar4 + 1;
                uVar2 = (uint)(((num_characters - 1) < (int)(uVar2 + 1) ? 1 : 0) - 1 & uVar2 + 1);
                if ((num_characters - 1) < local_80) {
                    return;
                }
            } while (true);
        }
    }

    void h_FUN_00a5a990(int param_1) {
        short uVar1;
        LpAbilityMapEngine *plVar2;
        SphereGridChrInfo *pSVar3;

        plVar2 = lpamng;
        pSVar3 = &custom_party_infos[param_1];
        uVar1 = pSVar3->current_node_idx;
        (pSVar3->pos).X = (float)lpamng->nodes[uVar1].x;
        (pSVar3->pos).Y = (float)plVar2->nodes[uVar1].y;
        (pSVar3->pos).Z = 0.0f;
        (pSVar3->pos).W = 1.0f;
        pSVar3->pos_circle_radius =
             (lpamng->node_type_infos[(int)lpamng->nodes[pSVar3->current_node_idx].node_type].width
                         >> 1) + 3.0f;
        return;
    }

    void h_FUN_00a5b030() {
        LpAbilityMapEngine *__lpamng;
        LpAbilityMapEngine *_lpamng;
        byte chr_id;

        _lpamng = lpamng;
        chr_id = lpamng->current_chr_id;
        lpamng->__0x115A0 = 256.0f;
        __lpamng = lpamng;
        (lpamng->__0x11520).X = custom_party_infos[chr_id].pos.X;
        (__lpamng->__0x11520).Y = custom_party_infos[chr_id].pos.Y;
        (__lpamng->__0x11520).Z = custom_party_infos[chr_id].pos.Z;
        (__lpamng->__0x11520).W = custom_party_infos[chr_id].pos.W;
        (lpamng->__0x11520).Z = custom_party_infos[chr_id].pos.Z - 32.0f;
        _lpamng = lpamng;
        chr_id = lpamng->current_chr_id;
        (lpamng->__0x11560).X = Vector4f_ARRAY_00c86010[chr_id].X;
        (_lpamng->__0x11560).Y = Vector4f_ARRAY_00c86010[chr_id].Y;
        (_lpamng->__0x11560).Z = Vector4f_ARRAY_00c86010[chr_id].Z;
        (_lpamng->__0x11560).W = Vector4f_ARRAY_00c86010[chr_id].W;
        (lpamng->__0x11520).W = lpamng->__0x115A0 + lpamng->__0x115A0;
        FUN_00647440.fnptr!();
        return;
    }

    void h_FUN_00a5b7b0() {
        short uVar1;
        ushort uVar2;
        byte *pbVar3;
        uint uVar4;
        int iVar5;
        byte bVar6;

        uVar1 = custom_party_infos[lpamng->current_chr_id].current_node_idx;
        lpamng->__0x115A8 = (int)FhUtil.ptr_at<nint>(0x644EF0); // FUN_00a44ef0
        lpamng->__0x115AC = (int)FhUtil.ptr_at<nint>(0x645440); // FUN_00a45440
        bVar6 = lpamng->current_chr_id;
        uVar2 = FUN_007853e0.fnptr!(bVar6);
        FUN_006474d0.fnptr!(uVar1, uVar2, bVar6);
        iVar5 = lpamng->node_count;
        if (iVar5 != 0) {
            pbVar3 = (byte*)&lpamng->nodes[0].properties;
            do {
                iVar5 = iVar5 + -1;
                if (*(ushort*)(pbVar3 + -0x1c) != 0xffff) {
                    *pbVar3 = (byte)(*pbVar3 & 0xfc);
                }
                pbVar3 = pbVar3 + 0x28;
            } while (iVar5 != 0);
        }
        uVar4 = FUN_007853e0.fnptr!(lpamng->current_chr_id);
        iVar5 = lpamng->node_count;
        if (iVar5 != 0) {
            pbVar3 = (byte*)&lpamng->nodes[0].properties;
            do {
                iVar5 = iVar5 + -1;
                if ((*(ushort*)(pbVar3 + -0x1c) != 0xffff) &&
                   (*(ushort*)(pbVar3 + 2) <= (ushort)((uVar4 & 0xffff) << 2))) {
                    *pbVar3 = (byte)(*pbVar3 | 3);
                }
                pbVar3 = pbVar3 + 0x28;
            } while (iVar5 != 0);
        }
        lpamng->__0x116A0 = 0;
        lpamng->__0x1169C = 0;
        lpamng->slv_queued = 0;
        FUN_00648d70.fnptr!(uVar1, 0.25f);
        if (lpamng->__0x115B0 != 0) {
            lpamng->__0x115C3 = 1;
            return;
        }
        lpamng->__0x115B0 = lpamng->__0x115A8;
        lpamng->__0x115A8 = (int)FhUtil.ptr_at<nint>(0x659E80); // FUN_00a59e80;
        lpamng->__0x115C3 = 1;
        return;
    }

    // Calculates valid nodes for item?
    void h_FUN_00a5b980(uint chr_id, short node_idx, uint item_id) {
        uint node_to_select;
        byte *pbVar1;
        SphereGridNode *psVar2;
        int iVar3;
        float local_8;

        iVar3 = lpamng->node_count;
        if (iVar3 != 0) {
            pbVar1 = (byte*)&lpamng->nodes[0].properties;
            do {
                iVar3 = iVar3 + -1;
                if (*(ushort*)(pbVar1 + -0x1c) != 0xffff) {
                    *pbVar1 = (byte)(*pbVar1 & 0xfc);
                }
                pbVar1 = pbVar1 + 0x28;
            } while (iVar3 != 0);
        }
        FUN_0065b400.fnptr!((int)chr_id, node_idx, item_id, 3);
        lpamng->__0x116A0 = 0;
        lpamng->__0x1169C = 0;
        lpamng->__0x115A8 = (int)FhUtil.ptr_at<nint>(0x6452D0); // abmCalcSpheUseCurMove
        lpamng->__0x115AC = (int)FhUtil.ptr_at<nint>(0x645500); // FUN_00a45500
        psVar2 = FUN_00656a40.fnptr!(&local_8, &custom_party_infos[lpamng->current_chr_id].pos,
                              //abmCalcChrMoveCurMoveCheck);
                              FhUtil.ptr_at<nint>(0x645000));
        node_to_select = (uint)(((int)psVar2 + (-0x808 - (int)lpamng)) / 0x28);
        if ((psVar2 != (SphereGridNode*)0x0) && (node_to_select != lpamng->selected_node_idx)) {
            FUN_00648d70.fnptr!((int)node_to_select, 0.5f);
            if (lpamng->__0x115B0 == 0) {
                lpamng->__0x115B0 = lpamng->__0x115A8;
                lpamng->__0x115A8 = (int)FhUtil.ptr_at<nint>(0x659E80); // FUN_00a59e80;
                lpamng->__0x115C3 = 1;
                return;
            }
            lpamng->__0x115C3 = 1;
            return;
        }
        lpamng->__0x115C3 = 1;
        return;
    }

    void h_FUN_00a5bb70() {
        LpAbilityMapEngine *plVar1;
        SaveSphereGrid *ability_map;
        int node_idx;
        int link_idx;
        int node_offset;
        int link_offset;

        ability_map = MsGetSaveAbilityMap.fnptr!();
        node_idx = 0;
        if (0 < lpamng->node_count) {
            node_offset = 0;
            do {
                plVar1 = lpamng;
                ability_map->nodes[node_idx].node_type =
                     //*(byte*)((int)lpamng->nodes[0].links_ptr + node_offset + -6);
                     (byte)lpamng->nodes[node_idx].node_type;
                ability_map->nodes[node_idx].activated_by =
                     //*(byte*)((int)plVar1->nodes[0].links_ptr + node_offset + 0x15);
                     lpamng->nodes[node_idx].activated_by;
                node_idx = node_idx + 1;
                node_offset = node_offset + 0x28;
            } while (node_idx < lpamng->node_count);
        }
        link_idx = 0;
        if (0 < lpamng->link_count) {
            link_offset = 0;
            do {
                ability_map->links_activated_by[link_idx] = (&lpamng->links[0].activated_by)[link_offset];
                link_idx = link_idx + 1;
                link_offset = link_offset + 0x14;
            } while (link_idx < lpamng->link_count);
        }
        // TODO: Handle extra characters
        ability_map->party_selected_node_idx[0] = (ushort)custom_party_infos[0].current_node_idx;
        ability_map->party_selected_node_idx[1] = (ushort)custom_party_infos[1].current_node_idx;
        ability_map->party_selected_node_idx[2] = (ushort)custom_party_infos[2].current_node_idx;
        ability_map->party_selected_node_idx[3] = (ushort)custom_party_infos[3].current_node_idx;
        ability_map->party_selected_node_idx[4] = (ushort)custom_party_infos[4].current_node_idx;
        ability_map->party_selected_node_idx[5] = (ushort)custom_party_infos[5].current_node_idx;
        ability_map->party_selected_node_idx[6] = (ushort)custom_party_infos[6].current_node_idx;
        for (int i = 0; i < num_characters - 7; i++) {
            custom_party_selected_node_idx[i] = custom_party_infos[i + 7].current_node_idx;
        }
        ability_map->tilt_level = lpamng->tilt_level;
        ability_map->zoom_level = lpamng->zoom_level;
        return;
    }

    void h_FUN_008a8ef0(uint param_1) {
        byte bVar1;
        byte *pbVar2;
        uint uVar3;
        //undefined3 extraout_var;
        int iVar4;
        uint uVar5;
        uint uVar6;
        uint uVar7;
        byte idx;
        uint local_c;
        int local_8;

        uVar5 = param_1 & 0xffff0000;
        *p_DAT_01441c30 = 0;
        *p_DAT_01441c34 = 0;
        pbVar2 = MsGetSaveInParty.fnptr!(&local_8);
        uVar7 = 0;
        uVar6 = 0;
        iVar4 = 0;
        local_c = 0;
        *p_DAT_01441c2c = 0;
        if (0 < local_8) {
            uVar7 = 0;
            do {
                bVar1 = pbVar2[iVar4];
                if (((bVar1 != 0xff)) && (uVar5 != 0x10000)) {
                    p_DAT_01441c14_PauseMenuPlayerList[uVar6] = bVar1;
                    uVar3 = (uint)(1 << (pbVar2[iVar4] & 0x1f));
                    uVar6 = uVar6 + 1;
                    uVar7 = uVar7 | uVar3;
                    *p_DAT_01441c2c = *p_DAT_01441c2c | uVar3;
                }
                iVar4 = iVar4 + 1;
            } while (iVar4 < local_8);
        }
        *p_DAT_01441c24_PauseMenuFrontlineNum = uVar6;
        pbVar2 = MsGetSaveOutParty.fnptr!(&local_8);
        iVar4 = 0;
        if (0 < local_8) {
            do {
                bVar1 = pbVar2[iVar4];
                if (((bVar1 != 0xff)) && (uVar5 != 0x10000)) {
                    p_DAT_01441c14_PauseMenuPlayerList[uVar6] = bVar1;
                    uVar6 = uVar6 + 1;
                    uVar7 = uVar7 | (uint)(1 << (pbVar2[iVar4] & 0x1f));
                }
                iVar4 = iVar4 + 1;
            } while (iVar4 < local_8);
        }
        iVar4 = 0;
        *p_UINT_01441c1c_PlayerListMax = uVar6;
        *p_DAT_01441c30 = uVar7;
        do {
            idx = (byte)iVar4;
            //if (bVar1 &&
            //   ((uVar5 != 0x10000 &&
            //    (uVar3 = 1 << (idx & 0x1f), local_c = local_c | uVar3, (uVar7 & uVar3) == 0)))) {
            if (FhXCall.MsGetSavePlyJoined.fnptr!(idx) && (uVar5 != 0x10000)) {
                uVar3 = (uint)(1 << (idx & 0x1f));
                local_c = local_c | uVar3;
                if ((uVar7 & uVar3) == 0) {
                    p_DAT_01441c14_PauseMenuPlayerList[uVar6] = idx;
                    uVar6 = uVar6 + 1;
                }
            }
            iVar4 = iVar4 + 1;
        } while (iVar4 < 8);
        *p_UINT_01441c20_PlayerListMax = uVar6;
        *p_DAT_01441c34 = local_c | uVar7;
        *p_DAT_01441c28_PauseMenuSelIdx = 0;
        return;
    }
    void h_FUN_008bddc0() {
        byte uVar1;
        int ply_chr_id;
        int iVar2;
        int iVar3;
        uint uVar4;
        int *puVar5;
        int local_8;

        iVar3 = 0;
        *p_DAT_01469f19 = 0;
        ply_chr_id = 0;
        do {
            if (Globals.Battle.reward_data->in_battle[ply_chr_id] != false) {
                if (Globals.Battle.reward_data->get_ap_temp[ply_chr_id] != 0) {
                    *p_DAT_01469f19 = 1;
                }
                iVar3 = iVar3 + 1;
            }
            ply_chr_id = ply_chr_id + 1;
        } while (ply_chr_id < 8);
        iVar2 = 0;
        local_8 = 0;
        uVar4 = 0;
        puVar5 = p_DAT_01469f24;
        do {
            if (Globals.Battle.reward_data->in_battle[(int)uVar4] != false) {
                *(short*)((int)puVar5 + -2) = (short)((short)iVar2 * 6);
                *(short*)puVar5 = 0;
                *(short*)((int)puVar5 + 2) = (short)uVar4;
                uVar1 = FUN_004b9eb0.fnptr!(uVar4);
                *(byte*)(puVar5 + 1) = uVar1;
                uVar1 = (byte)FUN_004b9ec0.fnptr!(uVar4);
                *(byte*)((int)puVar5 + 5) = uVar1;
                ply_chr_id = FUN_004ba370.fnptr!(local_8, iVar3);
                *(short*)(puVar5 + -1) = (short)ply_chr_id;
                iVar2 = local_8 + 1;
                *(byte*)((int)puVar5 + 6) = 0;
                puVar5 = (int*)((int)puVar5 + 0xe);
                local_8 = iVar2;
            }
            uVar4 = uVar4 + 1;
        } while ((int)uVar4 < 8);
        *p_DAT_01869F18 = (byte)iVar3;
        FUN_004ba400.fnptr!();
        return;
    }

    // TODO: Just render indicators "immediate mode" instead
    // Initialize activation indicators
    void h_FUN_00a505e0() {
        byte uVar1;
        int iVar2;
        uint uVar3;
        SphereGridNodeTypeUiInfo *pSVar4;
        LpAbilityMapEngine *plVar5;
        int iVar6;
        int iVar7;
        SphereGridNode *node;
        LpAbilityMapEngine *plVar8;
        double fVar9;
        //float10 extraout_ST0;
        uint local_190;
        uint local_18c;
        uint local_188;
        uint local_184;
        uint local_17c = 0;
        int chr_id;
        uint local_174 = 0;
        uint local_170 = 0;
        uint local_16c = 0;
        Vec2s16 *local_164;
        byte activated_by;
        temp_FUN_00a4c8d0_struct local_150 = new();
        Matrix4x4 local_d8 = new();
        Matrix4x4 local_98 = new();
        Matrix4x4 local_58 = new();

        iVar6 = (int)lpamng->node_count;
        node = &lpamng->nodes[0];
        iVar2 = *(int*)&lpamng->__0x11698;
        local_150.__0x20 = &local_d8;
        local_150.__0x44 = &local_58;
        local_150.__0x2C = &local_98;
        local_58.M14 = asmreg_0_zero->W;
        local_58.M24 = asmreg_0_zero->W;
        local_58.M44 = 1.0f;
        local_58.M34 = asmreg_0_zero->W;
        local_150.__0x28 = (int)&lpamng->__0x11520;
        local_150.__0x24 = (int)&lpamng->__0x11560;
        local_150.__0x1C = 0;
        local_150.__0xA = 0;
        local_150.__0x3C = 0;
        local_150.__0x38 = 0;
        local_150.__0x4 = (int)p_DAT_01340870_sphere_grid_layout_dat;
        local_150.__0xC = 0;
        local_150.__0x10 = 0;
        local_150.__0x14 = 0;
        local_150.__0x40 = 0;
        local_58.M11 = asmreg_0_zero->X;
        local_58.M12 = asmreg_0_zero->Y;
        local_58.M13 = asmreg_0_zero->Z;
        local_58.M21 = asmreg_0_zero->X;
        local_58.M22 = asmreg_0_zero->Y;
        local_58.M23 = asmreg_0_zero->Z;
        local_58.M31 = asmreg_0_zero->X;
        local_58.M32 = asmreg_0_zero->Y;
        local_58.M33 = asmreg_0_zero->Z;
        local_58.M41 = asmreg_0_zero->X;
        local_58.M42 = asmreg_0_zero->Y;
        local_58.M43 = asmreg_0_zero->Z;
        if (iVar6 != 0) {
            //local_16c = local_184;
            //local_170 = local_188;
            //local_17c = local_18c;
            //local_174 = local_190;
            do {
                plVar5 = lpamng;
                fVar9 = 6.0;
                iVar6 = iVar6 + -1;
                uVar1 = (byte)node->node_type;
                if (uVar1 == 0xff) {
                    iVar7 = 0;
                    do {
                        plVar5 = lpamng;
                        FUN_0065ad30.fnptr!(&local_98, node, 1.0f);
                        cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &plVar5->__0x113E0, &local_98);
                        local_58.M43 = -1.0f;
                        local_150.rgba = 0;
                        op1_md_draw_eiabm_sphe.fnptr!(DAT_01F057ec, &local_150, (lpamng->node_count - iVar6) + -1, iVar7);
                        iVar7 = iVar7 + 1;
                    } while (iVar7 < num_characters);
                }
                else {
                    local_164 = &lpamng->node_type_infos[uVar1].pos[0];
                    if (local_164->x == 0x1000) {
                        // Locks and empty nodes?
                        iVar7 = 0;
                        pSVar4 = &lpamng->node_type_infos[0];
                        do {
                            plVar5 = lpamng;
                            FUN_0065ad30.fnptr!(&local_98, node, pSVar4[uVar1].__0x10);
                            cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &plVar5->__0x113E0, &local_98);
                            local_58.M43 = -1.0f;
                            local_150.rgba = 0;
                            op1_md_draw_eiabm_sphe.fnptr!(DAT_01F057ec, &local_150, (lpamng->node_count - iVar6) + -1, iVar7);
                            iVar7 = iVar7 + 1;
                        } while (iVar7 < num_characters);
                    }
                    else {
                        activated_by = (byte)(lpamng->available_indicators & node->activated_by);
                        if (activated_by != 0) {
                            //fVar9 = (eff_sin_t[(node->__0x26 + iVar2 * 0x800) >> 4 &
                            //                       0xfff] * 0.15 * -96.0);
                            //iVar7 = (int)fVar9;
                            iVar7 = (int)(eff_sin_t[(int)(node->__0x26 + iVar2 * 0x800) >> 4 &
                                                   0xfff] * 0.15 * -96.0);
                            local_17c = (uint)(0x6cU - iVar7 & 0xff);
                            //fVar9 = extraout_ST0;
                            //fVar9 = iVar7; // Maybe?
                            local_174 = local_17c;
                            local_170 = local_17c;
                            local_16c = local_17c;
                        }
                        //local_150.__0x8 = -0x7f9c;
                        local_150.__0x8 = 0x8064;
                        chr_id = 0;
                        plVar8 = plVar5;
                        while (true) {
                            if ((activated_by & 1) == 0) {
                                local_150.rgba = p_DAT_00c86644[chr_id]; // Inactive indicator colors
                                local_150.__0x0 = 0x24;
                            }
                            else {
                                uVar3 = (uint)p_DAT_00c8659c[chr_id]; // Active indicator colors
                                local_150.rgba =
                                     //CONCAT13(0x80, (((int3)((int)(((int)uVar3 >> 0x18 & 0xffU) * local_16c) >> 7)  * 0x100 +
                                     //                 (int3)((int)(((int)uVar3 >> 0x10 & 0xffU) * local_170) >> 7)) * 0x100 +
                                     //                 (int3)((int)(((int)uVar3 >> 8 & 0xffU) * local_17c)    >> 7)) * 0x100 +
                                     //                 (int3)((int)(     (uVar3      & 0xff ) * local_174)    >> 7));
                                     (uint)((0x80 << 0x18) | ((((((int)(((int)uVar3 >> 0x18 & 0xffU) * local_16c) >> 7)  * 0x100 +
                                                          ((int)(((int)uVar3 >> 0x10 & 0xffU) * local_170) >> 7)) * 0x100 +
                                                          ((int)(((int)uVar3 >> 0x08 & 0xffU) * local_17c) >> 7)) * 0x100 +
                                                          ((int)(     (uVar3         & 0xff ) * local_174) >> 7))
                                                          & 0x00FFFFFF));
                                // Animating the color intensity(?)
                                //local_150.rgba = (int)uVar3;
                                local_150.__0x0 = 0x2c;
                                fVar9 = 1.0;
                            }
                            local_58.M43 = (float)fVar9;
                            //_logger.Debug($"node type:{uVar1}, size:{plVar5->node_type_infos[uVar1].width} x {plVar5->node_type_infos[uVar1].height}, 0x10:{plVar5->node_type_infos[uVar1].__0x10}");
                            FUN_0065ad30.fnptr!(&local_98, node, plVar5->node_type_infos[uVar1].__0x10);
                            //_logger.Debug($"Pos: {node->pos} + {local_164->xy}");
                            FUN_0065a360.fnptr!(&local_98, node, local_164, 0.0008f);
                            cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &plVar8->__0x113E0, &local_98);
                            op1_md_draw_eiabm_sphe.fnptr!(DAT_01F057ec, &local_150, (lpamng->node_count - iVar6) + -1, chr_id);
                            chr_id = chr_id + 1;
                            activated_by = (byte)(activated_by >> 1);
                            if (num_characters-1 < chr_id) break;
                            if (chr_id >= 7) {
                                Vec2s16 tempVec2s16 = custom_node_indicator_pos[uVar1, chr_id - 7];
                                local_164 = &tempVec2s16;
                            } else {
                                local_164 = local_164 + 1;
                            }
                            fVar9 = 6.0;
                            plVar8 = lpamng;
                        }
                    }
                }
                node = node + 1;
            } while (iVar6 != 0);
        }
        return;
    }

    // Update activation indicator color
    void h_FUN_00a534c0() {
        byte uVar1;
        uint uVar2;
        LpAbilityMapEngine *plVar3;
        byte bVar4;
        int iVar5;
        int iVar6;
        int *piVar7;
        int iVar8;
        SphereGridNode *node;
        uint uVar9;
        Vec2s16 *pVVar10;
        uint *local_1c8;
        temp_FUN_00a4c8d0_struct local_1c0 = new();
        int[] _local_148 = new int[4 * num_characters];
        Matrix4x4 local_d8 = new();
        Matrix4x4 local_98 = new();
        Matrix4x4 local_58 = new();
        int iVar11;

        fixed (int* local_148 = _local_148) {

            if (-1 < (int)lpamng->should_update_node) {
                FUN_00650ed0.fnptr!((int)lpamng->should_update_node);
            }
            if (lpamng->__0x116B0 == -2) {
                iVar11 = 2;
            }
            else {
                if (lpamng->__0x116B0 != 2) goto LAB_00a534fb;
                iVar11 = 3;
            }
            FUN_002390D0.fnptr!(iVar11);
        LAB_00a534fb:
            if (lpamng->__0x116B0 < 1) {
                return;
            }
            iVar11 = (int)lpamng->node_count;
            node = &lpamng->nodes[0];
            iVar5 = (int)(eff_sin_t[(int)(*(int*)&lpamng->__0x11698 * 0x800 +
                                        (uint)lpamng->nodes[0].__0x26) >> 4 & 0xfff] * 0.15 *
                         -96.0);
            uVar9 = (uint)(0x6cU - iVar5 & 0xff);
            local_1c8 = (uint*)p_DAT_00c8659c;
            piVar7 = local_148 + 2;
            int chr_id = 0;
            do {
                uVar2 = *local_1c8;
                iVar6 = (int)(((int)uVar2 >> 0x18 & 0xffU) * uVar9) >> 7;
                iVar5 = (int)(((int)uVar2 >> 0x10 & 0xffU) * uVar9) >> 7;
                piVar7[1] = iVar6;
                iVar8 = (int)(((int)uVar2 >> 8 & 0xffU) * uVar9) >> 7;
                piVar7[-1] = iVar8;
                *piVar7 = iVar5;
                uVar2 = *local_1c8;
                local_1c8 = local_1c8 + 1;
                piVar7[-2] = ((iVar6 * 0x100 + iVar5) * 0x100 + iVar8) * 0x100 +
                             ((int)((uVar2 & 0xff) * uVar9) >> 7);
                piVar7 = piVar7 + 4;
                chr_id += 1;
            } while (chr_id < num_characters);
            local_1c0.__0x20 = &local_d8;
            local_1c0.__0x44 = &local_58;
            local_1c0.__0x2C = &local_98;
            local_58.M13 = asmreg_0_zero->Z;
            local_58.M23 = asmreg_0_zero->Z;
            local_58.M33 = asmreg_0_zero->Z;
            local_58.M43 = asmreg_0_zero->Z;
            local_58.M44 = 1.0f;
            local_1c0.__0x1C = 0;
            local_1c0.__0xA = 0;
            local_1c0.__0x3C = 0;
            local_1c0.__0x38 = 0;
            local_1c0.__0x4 = (int)p_DAT_01340870_sphere_grid_layout_dat;
            local_1c0.__0xC = 0;
            local_1c0.__0x10 = 0;
            local_1c0.__0x14 = 0;
            local_1c0.__0x40 = 0;
            local_1c0.__0x28 = 0;
            local_1c0.__0x24 = 0;
            local_58.M11 = asmreg_0_zero->X;
            local_58.M12 = asmreg_0_zero->Y;
            local_58.M14 = asmreg_0_zero->W;
            local_58.M21 = asmreg_0_zero->X;
            local_58.M22 = asmreg_0_zero->Y;
            local_58.M24 = asmreg_0_zero->W;
            local_58.M31 = asmreg_0_zero->X;
            local_58.M32 = asmreg_0_zero->Y;
            local_58.M34 = asmreg_0_zero->W;
            local_58.M41 = asmreg_0_zero->X;
            local_58.M42 = asmreg_0_zero->Y;
            plVar3 = lpamng;
            while (iVar11 != 0) {
                uVar1 = (byte)node->node_type;
                iVar11 = iVar11 + -1;
                //lpamng = plVar3;
                if (uVar1 != 0xff) {
                    pVVar10 = &plVar3->node_type_infos[uVar1].pos[0];
                    if (pVVar10->x != 0x1000) {
                        bVar4 = (byte)(plVar3->available_indicators & node->activated_by);
                        //local_1c0.__0x8 = -0x7f9c;
                        local_1c0.__0x8 = 0x8064;
                        piVar7 = local_148;
                        iVar5 = -1;
                        do {
                            if ((bVar4 & 1) != 0) {
                                local_58.M43 = 1.0f;
                                //local_1c0.rgba = CONCAT13(0x80, (int3) * piVar7);
                                local_1c0.rgba = (uint)((0x80 << 0x18) | (*piVar7 & 0x00FFFFFF));
                                local_1c0.__0x0 = 0x2c;
                                FUN_0065ad30.fnptr!(&local_98, node, plVar3->node_type_infos[uVar1].__0x10);
                                FUN_0065a360.fnptr!(&local_98, node, pVVar10, 0.0008f);
                                cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &lpamng->__0x113E0, &local_98);
                                op1_md_draw_eiabm_sphe.fnptr!(DAT_01F057ec, &local_1c0, (lpamng->node_count - iVar11) + -1, iVar5);
                            }
                            piVar7 = piVar7 + 4;
                            iVar5 = iVar5 + -1;
                            bVar4 = (byte)(bVar4 >> 1);
                            if (-iVar5 > 7 && -(num_characters + 1) < iVar5) {
                                Vec2s16 tempVec2s16 = custom_node_indicator_pos[uVar1, -iVar5 - 8];
                                pVVar10 = &tempVec2s16;
                            }
                            else {
                                pVVar10 = pVVar10 + 1;
                            }
                        } while (-(num_characters+1) < iVar5);
                    }
                }
                node = node + 1;
                plVar3 = lpamng;
            }
            //lpamng = plVar3; // ???
            return;
        }
    }

    void h_FUN_00a50ed0(int param_1) {
        SphereGridNode* pSVar1;
        NodeType SVar2;
        uint uVar3;
        SphereGridNodeTypeUiInfo* pSVar4;
        LpAbilityMapEngine* pLVar5;
        int iVar6;
        LpAbilityMapEngine* pLVar7;
        float extraout_ST0;
        float fVar8;
        uint local_190 = 0;
        uint local_18c = 0;
        uint local_188 = 0;
        uint local_184 = 0;
        uint local_180;
        uint local_178;
        uint local_174;
        uint local_170;
        int local_16c;
        Vec2s16* local_164;
        int local_15c;
        byte local_151;
        temp_FUN_00a4c8d0_struct local_150;
        Matrix4x4 local_d8;
        Matrix4x4 local_98;
        Matrix4x4 local_58;
        float fVar9;

        pLVar5 = lpamng;
        fVar9 = (float)1;
        pSVar1 = &lpamng->nodes[param_1];
        local_150.__0x20 = &local_d8;
        local_150.__0x44 = &local_58;
        local_150.__0x2C = &local_98;
        local_58.M44 = (float)fVar9;
        local_58.M13 = asmreg_0_zero->Z;
        local_58.M14 = asmreg_0_zero->W;
        local_58.M23 = asmreg_0_zero->Z;
        local_58.M24 = asmreg_0_zero->W;
        local_58.M33 = asmreg_0_zero->Z;
        local_58.M34 = asmreg_0_zero->W;
        local_58.M43 = asmreg_0_zero->Z;
        local_58.M11 = asmreg_0_zero->X;
        local_58.M21 = asmreg_0_zero->X;
        local_58.M31 = asmreg_0_zero->X;
        local_58.M41 = asmreg_0_zero->X;
        local_58.M12 = asmreg_0_zero->Y;
        local_58.M22 = asmreg_0_zero->Y;
        local_58.M32 = asmreg_0_zero->Y;
        local_58.M42 = asmreg_0_zero->Y;
        local_150.__0x1C = 0;
        local_150.__0xA = 0;
        local_150.__0x3C = 0;
        local_150.__0x38 = 0;
        local_150.__0x4 = (int)p_DAT_01340870_sphere_grid_layout_dat;
        local_150.__0xC = 0;
        local_150.__0x10 = 0;
        local_150.__0x14 = 0;
        local_150.__0x40 = 0;
        SVar2 = pSVar1->node_type;
        local_150.__0x28 = (int)&lpamng->__0x11520;
        local_150.__0x24 = (int)&lpamng->__0x11560;
        local_164 = &lpamng->node_type_infos[(int)SVar2].pos[0];
        if (local_164->x == 0x1000) {
            //pSVar4 = lpamng->node_type_infos;
            iVar6 = -1;
            do {
                pLVar5 = lpamng;
                FUN_0065ad30.fnptr!(&local_98, pSVar1, lpamng->node_type_infos[(int)SVar2].__0x10);
                cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &pLVar5->__0x113E0, &local_98);
                local_58.M43 = -1.0f;
                local_150.rgba = 0;
                op1_md_draw_eiabm_sphe.fnptr!(DAT_01F057ec, &local_150, param_1, iVar6);
                iVar6 = iVar6 + -1;
            } while (-(num_characters+1) < iVar6);
        }
        else {
            local_151 = (byte)(lpamng->available_indicators & pSVar1->activated_by);
            if (local_151 == 0) {
                local_170 = local_184;
                local_178 = local_188;
                local_180 = local_18c;
                local_174 = local_190;
            } else {
                //iVar6 = FUN_009497e0.fnptr!(pSVar1, 0x1000);
                iVar6 = (int)(eff_sin_t[(int)(pSVar1->__0x26 + *(int*)&lpamng->__0x11698 * 0x800) >> 4 & 0xfff] * 0.15 * -96.0);
                local_180 = (uint)(0x6cU - iVar6 & 0xff);
                //fVar9 = extraout_ST0;
                local_178 = local_180;
                local_174 = local_180;
                local_170 = local_180;
            }
            local_150.__0x8 = 0x8064;
            local_15c = -1;
            local_16c = 0;
            pLVar7 = pLVar5;
            while (true) {
                fVar8 = (float)6.0;
                if ((local_151 & 1) == 0) {
                    local_150.rgba = *(uint*)(p_DAT_00c86644 + local_16c);
                    local_150.__0x0 = 0x24;
                } else {
                    uVar3 = *(uint*)(p_DAT_00c8659c + local_16c);
                    local_150.rgba =
                         //CONCAT13(0x80, (((int3)((int)(((int)uVar3 >> 0x18 & 0xffU) * local_170) >> 7)  * 0x100 +
                         //                 (int3)((int)(((int)uVar3 >> 0x10 & 0xffU) * local_178) >> 7)) * 0x100 +
                         //                 (int3)((int)(((int)uVar3 >> 8 & 0xffU) * local_180)    >> 7)) * 0x100 +
                         //                 (int3)((int)(     (uVar3      & 0xff ) * local_174)    >> 7));
                         (uint)((0x80 << 0x18) | ((((((int)(((int)uVar3 >> 0x18 & 0xffU) * local_170) >> 7)  * 0x100 +
                                              ((int)(((int)uVar3 >> 0x10 & 0xffU) * local_178) >> 7)) * 0x100 +
                                              ((int)(((int)uVar3 >> 0x08 & 0xffU) * local_180) >> 7)) * 0x100 +
                                              ((int)(     (uVar3         & 0xff ) * local_174) >> 7))
                                              & 0x00FFFFFF));
                    local_150.__0x0 = 0x2c;
                    fVar8 = fVar9;
                }
                local_58.M43 = (float)fVar8;
                FUN_0065ad30.fnptr!(&local_98, pSVar1, pLVar5->node_type_infos[(int)SVar2].__0x10);
                FUN_0065a360.fnptr!(&local_98, pSVar1, local_164, 0.0008f);
                cdc_FFXVu0MulMatrix.fnptr!(&local_d8, &pLVar7->__0x113E0, &local_98);
                op1_md_draw_eiabm_sphe.fnptr!(DAT_01F057ec, &local_150, param_1, local_15c);
                local_15c = local_15c + -1;
                local_16c = local_16c + 1;
                local_151 = (byte)(local_151 >> 1);
                if (local_15c < -num_characters) break;
                if (-local_15c > 7) {
                    Vec2s16 tempVec2s16 = custom_node_indicator_pos[(int)SVar2, -local_15c - 8];
                    local_164 = &tempVec2s16;
                } else {
                    local_164 = local_164 + 1;
                }
                fVar9 = (float)1;
                pLVar7 = lpamng;
            }
        }
        return;
    }


    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x6C)]
    public struct VertexInfo_0x94 {
        [FieldOffset(0x00)] public int    field0_0x0;
        [FieldOffset(0x04)] public int    field1_0x4;
        [FieldOffset(0x08)] public int    field2_0x8;
        [FieldOffset(0x0c)] public float* field3_0xc;  // [6020][12]
        [FieldOffset(0x10)] public float* field4_0x10; // [6020][12]
        [FieldOffset(0x14)] public float* field5_0x14; // [6020][16]
        [FieldOffset(0x18)] public float* field6_0x18; // [6020][ 8]
        [FieldOffset(0x1c)] public short* field7_0x1c; // [6020][ 6]
        [FieldOffset(0x20)] public byte*  field8_0x20;
        [FieldOffset(0x24)] public int    field9_0x24;


        [FieldOffset(0x2c)] public float field14_0x2c;
        [FieldOffset(0x48)] public float field33_0x48;
        [FieldOffset(0x30)] public float field15_0x30;
        [FieldOffset(0x4c)] public float field34_0x4c;
        [FieldOffset(0x34)] public float field16_0x34;
        [FieldOffset(0x50)] public float field35_0x50;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0xD0)]
    public struct abmapVertexInfo {
        [FieldOffset(0x0 )] public float field0_0x0;
        [FieldOffset(0x4 )] public float field1_0x4;
        [FieldOffset(0x8 )] public float field2_0x8;
        [FieldOffset(0xc )] public float field3_0xc;
        [FieldOffset(0x10)] public float field4_0x10;
        [FieldOffset(0x14)] public float field5_0x14;
        [FieldOffset(0x18)] public float field6_0x18;
        [FieldOffset(0x1c)] public float field7_0x1c;
        [FieldOffset(0x20)] public float field8_0x20;
        [FieldOffset(0x24)] public float field9_0x24;
        [FieldOffset(0x28)] public float field10_0x28;
        [FieldOffset(0x2c)] public float field11_0x2c;
        [FieldOffset(0x30)] public float field12_0x30;
        [FieldOffset(0x34)] public float field13_0x34;
        [FieldOffset(0x38)] public float field14_0x38;
        [FieldOffset(0x3c)] public float field15_0x3c;

        [FieldOffset(0x90)] public int   field96_0x90;
        [FieldOffset(0x94)] public VertexInfo_0x94* field97_0x94;
        [FieldOffset(0x98)] public float field98_0x98;
        [FieldOffset(0x9c)] public float field99_0x9c;
        [FieldOffset(0xa0)] public float field100_0xa0;
        [FieldOffset(0xa4)] public float field101_0xa4;
        [FieldOffset(0xa8)] public float field102_0xa8;
        [FieldOffset(0xac)] public float field103_0xac;

        [FieldOffset(0xb8)] public int field112_0xb8;
        [FieldOffset(0xbc)] public int field113_0xbc;
    }

    abmapVertexInfo* h_AbmapManager_AllocBuffMemory(nint abmapManager, int param_1) {
        abmapVertexInfo* puVar3;
        if (param_1 == 7) {
            puVar3 = (abmapVertexInfo*)user_malloc.fnptr!(0xd0);
            NativeMemory.Fill(puVar3, 0xd0, 0);
            puVar3->field112_0xb8 = 2;
            puVar3->field113_0xbc = 0;


            uint field3_0xc_size = 0x35C * num_characters * 0x0c * 4;
            uint field4_0x10_size = 0x35C * num_characters * 0x0c * 4;
            uint field5_0x14_size = 0x35C * num_characters * 0x10 * 4;
            uint field6_0x18_size = 0x35C * num_characters * 0x08 * 4;
            uint field7_0x1c_size = 0x35C * num_characters * 0x06 * 2;



            VertexInfo_0x94* pVVar3 = (VertexInfo_0x94*)user_malloc.fnptr!(0x6c);
            NativeMemory.Fill(pVVar3, 0x6c, 0);
            puVar3->field97_0x94 = pVVar3;
            puVar3->field96_0x90 = 1;
            pVVar3->field1_0x4 = (int)(0x35C * num_characters * 4);
            puVar3->field97_0x94->field2_0x8 = (int)(0x35C * num_characters * 6);
            puVar3->field97_0x94->field3_0xc = (float*)user_malloc.fnptr!((nint)field3_0xc_size);
            puVar3->field97_0x94->field4_0x10 = (float*)user_malloc.fnptr!((nint)field4_0x10_size);
            puVar3->field97_0x94->field5_0x14 = (float*)user_malloc.fnptr!((nint)field5_0x14_size);
            puVar3->field97_0x94->field6_0x18 = (float*)user_malloc.fnptr!((nint)field6_0x18_size);
            puVar3->field97_0x94->field7_0x1c = (short*)user_malloc.fnptr!((nint)field7_0x1c_size);
            puVar3->field97_0x94->field8_0x20 = (byte*)user_malloc.fnptr!(0x100);
            puVar3->field97_0x94->field9_0x24 = 1;

            //memset(puVar3->field97_0x94->field8_0x20, 0, 0x100);
            NativeMemory.Fill(puVar3->field97_0x94->field8_0x20, 0x100, 0);

            nint tempStringPointer = Marshal.StringToHGlobalAnsi("NoTexture");
            NativeMemory.Copy((void*)tempStringPointer, puVar3->field97_0x94->field8_0x20, 9);
            Marshal.FreeHGlobal(tempStringPointer);
            //builtin_strncpy(puVar3->field97_0x94->field8_0x20, "NoTexture", 9);



            //memset(puVar3->field97_0x94->field4_0x10, 0, 0x468c0);
            //memset(puVar3->field97_0x94->field5_0x14, 0, 0x5e100);
            //memset(puVar3->field97_0x94->field7_0x1c, 0, 0x11a30);
            //memset(puVar3->field97_0x94->field6_0x18, 0, 0x2f080);
            NativeMemory.Fill(puVar3->field97_0x94->field4_0x10, field4_0x10_size, 0);
            NativeMemory.Fill(puVar3->field97_0x94->field5_0x14, field5_0x14_size, 0);
            NativeMemory.Fill(puVar3->field97_0x94->field6_0x18, field6_0x18_size, 0);
            NativeMemory.Fill(puVar3->field97_0x94->field7_0x1c, field7_0x1c_size, 0);

            //memset(puVar3->field97_0x94->field3_0xc, 0, 0x468c0);
            NativeMemory.Fill(puVar3->field97_0x94->field3_0xc, field3_0xc_size, 0);
            puVar3->field97_0x94->field0_0x0 = 0;
            goto LAB_00682189;


        } else if (param_1 == 5) {
            puVar3 = (abmapVertexInfo*)user_malloc.fnptr!(0xd0);
            NativeMemory.Fill(puVar3, 0xd0, 0);
            puVar3->field112_0xb8 = 2;
            puVar3->field113_0xbc = 0;


            uint field3_0xc_size  = 2 * num_characters * 0x0c * 4;
            uint field4_0x10_size = 2 * num_characters * 0x0c * 4;
            uint field5_0x14_size = 2 * num_characters * 0x10 * 4;
            uint field6_0x18_size = 2 * num_characters * 0x08 * 4;
            uint field7_0x1c_size = 2 * num_characters * 0x06 * 2;


            VertexInfo_0x94* pVVar3 = (VertexInfo_0x94*)user_malloc.fnptr!(0x6c);
            puVar3->field97_0x94 = pVVar3;
            puVar3->field96_0x90 = 1;
            pVVar3->field1_0x4 = (int)(2 * num_characters * 4);
            puVar3->field97_0x94->field2_0x8 = (int)(2 * num_characters * 6);
            puVar3->field97_0x94->field3_0xc  = (float*)user_malloc.fnptr!((nint)field3_0xc_size);
            puVar3->field97_0x94->field4_0x10 = (float*)user_malloc.fnptr!((nint)field4_0x10_size);
            puVar3->field97_0x94->field5_0x14 = (float*)user_malloc.fnptr!((nint)field5_0x14_size);
            puVar3->field97_0x94->field6_0x18 = (float*)user_malloc.fnptr!((nint)field6_0x18_size);
            puVar3->field97_0x94->field7_0x1c = (short*)user_malloc.fnptr!((nint)field7_0x1c_size);
            puVar3->field97_0x94->field8_0x20 = (byte*)user_malloc.fnptr!(0x100);
            puVar3->field97_0x94->field9_0x24 = 1;
            //memset(puVar3->field97_0x94->field8_0x20, 0, 0x100);
            //memset(puVar3->field97_0x94->field5_0x14, 0, 0x380);
            //memset(puVar3->field97_0x94->field7_0x1c, 0, 0xa8);
            //memset(puVar3->field97_0x94->field4_0x10, 0, 0x2a0);
            //memset(puVar3->field97_0x94->field6_0x18, 0, 0x1c0);
            //memset(puVar3->field97_0x94->field3_0xc, 0, 0x2a0);
            NativeMemory.Fill(puVar3->field97_0x94->field3_0xc , field3_0xc_size , 0);
            NativeMemory.Fill(puVar3->field97_0x94->field4_0x10, field4_0x10_size, 0);
            NativeMemory.Fill(puVar3->field97_0x94->field5_0x14, field5_0x14_size, 0);
            NativeMemory.Fill(puVar3->field97_0x94->field6_0x18, field6_0x18_size, 0);
            NativeMemory.Fill(puVar3->field97_0x94->field7_0x1c, field7_0x1c_size, 0);
            NativeMemory.Fill(puVar3->field97_0x94->field8_0x20, 0x100, 0);
            if (*(int*)abmapManager == 0) {
                byte* pcVar9 = (byte*)FhUtil.get_at<nint>(0x833980);
                int i = 0;
                do {
                    i++;
                } while (pcVar9[i] != 0);

                NativeMemory.Copy(pcVar9, puVar3->field97_0x94->field8_0x20, (nuint)i);

                FhLangId iVar11 = FhXCall.TOGetFFXLang.fnptr!();
                if (iVar11 == FhLangId.Debug) {
                    pcVar9 = (byte*)FhUtil.get_at<nint>(0x8339E8);
                    int j = 0;
                    do {
                        j++;
                    } while (pcVar9[i] != 0);

                    NativeMemory.Copy(pcVar9, puVar3->field97_0x94->field8_0x20, (nuint)j);
                }
            } else if (*(int*)abmapManager == 2) {
                byte* pcVar9 = (byte*)FhUtil.get_at<nint>(0x8339BC);
                int i = 0;
                do {
                    i++;
                } while (pcVar9[i] != 0);

                NativeMemory.Copy(pcVar9, puVar3->field97_0x94->field8_0x20, (nuint)i);

                FhLangId iVar11 = FhXCall.TOGetFFXLang.fnptr!();
                if (iVar11 == FhLangId.Debug) {
                    pcVar9 = (byte*)FhUtil.get_at<nint>(0x833A24);
                    int j = 0;
                    do {
                        j++;
                    } while (pcVar9[i] != 0);

                    NativeMemory.Copy(pcVar9, puVar3->field97_0x94->field8_0x20, (nuint)j);
                }
            }
            puVar3->field97_0x94->field0_0x0 = 1;
            goto LAB_00682189;


        } else {
            return AbmapManager_AllocBuffMemory.chain_from(h_AbmapManager_AllocBuffMemory).fnptr!(abmapManager, param_1);
        }


    LAB_00682189:
        puVar3->field97_0x94->field14_0x2c = 0;
        puVar3->field97_0x94->field33_0x48 = 0;
        puVar3->field97_0x94->field15_0x30 = 0;
        puVar3->field97_0x94->field34_0x4c = 0;
        puVar3->field97_0x94->field16_0x34 = 0;
        puVar3->field97_0x94->field35_0x50 = 0;
        puVar3->field0_0x0 = 1.0f;
        puVar3->field1_0x4 = 0.0f;
        puVar3->field2_0x8 = 0.0f;
        puVar3->field3_0xc = 0.0f;
        puVar3->field4_0x10 = 0.0f;
        puVar3->field6_0x18 = 0.0f;
        puVar3->field7_0x1c = 0.0f;
        puVar3->field8_0x20 = 0.0f;
        puVar3->field9_0x24 = 0.0f;
        puVar3->field11_0x2c = 0.0f;
        puVar3->field12_0x30 = 0.0f;
        puVar3->field13_0x34 = 0.0f;
        puVar3->field14_0x38 = 0.0f;
        puVar3->field5_0x14 = 1.0f;
        puVar3->field10_0x28 = 1.0f;
        puVar3->field15_0x3c = 1.0f;
        puVar3->field98_0x98 = -1000.0f;
        puVar3->field99_0x9c = -1000.0f;
        puVar3->field100_0xa0 = -1000.0f;
        puVar3->field101_0xa4 = 2000.0f;
        puVar3->field102_0xa8 = 2000.0f;
        puVar3->field103_0xac = 2000.0f;
        int index = 0;
        byte[] local_108 = new byte[256];
        if (0 < puVar3->field96_0x90) {
            int iVar12 = 0;
            do {
                fixed (byte* p_local_108 = local_108) {
                    fiosUnifyFilename.fnptr!((nint)(*(byte**)((int)&puVar3->field97_0x94->field8_0x20 + iVar12)), (nint)p_local_108,
                                  0x100);

                    int i = 0;
                    do {
                        i++;
                    } while (p_local_108[i] != 0);

                    NativeMemory.Copy(p_local_108, *(byte**)((int)&puVar3->field97_0x94->field8_0x20 + iVar12), (nuint)i);
                }

                index = index + 1;
                iVar12 = iVar12 + 0x6c;
            } while (index < puVar3->field96_0x90);
        }
        return puVar3;

    }

    int h_op1_md_draw_eiabm_sphe(int param_1, temp_FUN_00a4c8d0_struct* param_2, int node_idx, int chr_id) {
        Matrix4x4* pMVar1;
        VertexInfo_0x94* pVVar2;
        float* pfVar3;
        float fVar4;
        short sVar5;
        abmapVertexInfo* paVar6;
        int iVar7;
        int iVar8;
        //int extraout_EDX;
        int local_a8;
        int local_a4;
        float local_a0;
        int local_9c;
        float local_98;
        float local_94;
        int local_90;
        VertexInfo_0x94* local_8c;
        float local_88;
        float local_84;
        float local_80;
        float local_7c;
        float local_78;
        float local_74;
        //undefined4 local_70;
        float fStack_6c;
        Vector4 local_68 = new();
        Vector4 rgba     = new();
        Matrix4x4 local_48 = new();


        local_68.X = 0.0078125f;
        local_68.Y = 0.0078125f;
        local_68.Z = 0.0078125f;
        local_68.W = 0.0078125f;
        local_88 = (param_2->__0x44->W).Z;
        if (_gParticleDoNotRender == 0) {
            local_9c = *(int*)(param_1 + 8) + param_1;
            pMVar1 = param_2->__0x20;
            local_90 = *(int*)(param_1 + 4);
            local_94 = ((pMVar1->W).X / (pMVar1->W).W - 2048.0f) + 256.0f;
            local_98 = ((pMVar1->W).Y / (pMVar1->W).W - 2048.0f) + 208.0f;
            rgba.X = (float)(byte)param_2->rgba;
            rgba.Y = (float)*(byte*)((int)&param_2->rgba + 1);
            rgba.Z = (float)*(byte*)((int)&param_2->rgba + 2);
            rgba.W = (float)(uint)*(byte*)((int)&param_2->rgba + 3);
            FFXVu0MulVector.fnptr!(&rgba, &local_68, &rgba);
            graphicFontGetScreenWH.fnptr!(&local_a8, &local_a4);
            local_7c = (float)local_a8 * 0.001953125f;
            local_84 = (float)local_a4 / 416.0f;
            local_78 = (param_2->__0x20->Z).W;
            if (float.IsNaN(local_78) != (local_78 == 0.0)) {
                local_78 = 1.0f;
            }
            local_80 = (local_84 * 4.0f * local_78) / (local_7c * 3.0f);
            local_a0 = (float)local_a8 * 0.5f;
            local_74 = (float)local_a4 * 0.5f;

            nint tempStringPointer = Marshal.StringToHGlobalAnsi("NoTexture");
            paVar6 = graphicAbmapGetVertexInfo.fnptr!((byte*)tempStringPointer, 7);
            Marshal.FreeHGlobal(tempStringPointer);

            if (-1 < chr_id) {
                pVVar2 = paVar6->field97_0x94;
                iVar8 = (int)(node_idx * num_characters + chr_id);
                local_48.M11 = (float)(uint)*(byte*)(local_90 + 0x10 + param_1);
                local_48.M12 = (float)(uint)*(byte*)(local_90 + 0x11 + param_1);
                local_48.M13 = (float)(uint)*(byte*)(local_90 + 0x12 + param_1);
                local_48.M14 = (float)(uint)*(byte*)(local_90 + 0x13 + param_1);
                local_48.M21 = (float)(uint)*(byte*)(local_90 + 0x14 + param_1);
                local_48.M22 = (float)(uint)*(byte*)(local_90 + 0x15 + param_1);
                local_48.M23 = (float)(uint)*(byte*)(local_90 + 0x16 + param_1);
                local_48.M24 = (float)(uint)*(byte*)(local_90 + 0x17 + param_1);
                local_48.M31 = (float)(uint)*(byte*)(local_90 + 0x18 + param_1);
                local_48.M32 = (float)(uint)*(byte*)(local_90 + 0x19 + param_1);
                local_48.M33 = (float)(uint)*(byte*)(local_90 + 0x1a + param_1);
                local_48.M34 = (float)(uint)*(byte*)(local_90 + 0x1b + param_1);
                //_local_70 = CONCAT44(local_48.M34, local_70);
                local_8c = (VertexInfo_0x94*)(iVar8 * 4);
                local_48.M41 = local_48.M31;
                local_48.M42 = local_48.M32;
                local_48.M43 = local_48.M33;
                local_48.M44 = local_48.M34;
                FFXVu0MulVector.fnptr!((Vector4*)&local_48.M11, &rgba, (Vector4*)&local_48.M11);
                FFXVu0MulVector.fnptr!((Vector4*)&local_48.M21, &rgba, (Vector4*)&local_48.M21);
                FFXVu0MulVector.fnptr!((Vector4*)&local_48.M31, &rgba, (Vector4*)&local_48.M31);
                FFXVu0MulVector.fnptr!((Vector4*)&local_48.M41, &rgba, (Vector4*)&local_48.M41);
                pVVar2->field5_0x14[iVar8 * 0x10]       = local_48.M11 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 1]   = local_48.M12 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 2]   = local_48.M13 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 3]   = local_48.M14 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 4]   = local_48.M21 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 5]   = local_48.M22 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 6]   = local_48.M23 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 7]   = local_48.M24 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 8]   = local_48.M31 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 9]   = local_48.M32 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 10]  = local_48.M33 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 0xb] = local_48.M34 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 0xc] = local_48.M41 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 0xd] = local_48.M42 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 0xe] = local_48.M43 / 255.0f;
                pVVar2->field5_0x14[iVar8 * 0x10 + 0xf] = local_48.M44 / 255.0f;
                if (*(byte*)((int)&param_2->rgba + 3) == 0) {
                    pVVar2->field3_0xc[iVar8 * 0xc    ] = -10000.0f;
                    pVVar2->field3_0xc[iVar8 * 0xc + 1] = -10000.0f;
                    pVVar2->field3_0xc[iVar8 * 0xc + 2] = local_88;
                    pVVar2->field3_0xc[iVar8 * 0xc + 3] = -10000.0f;
                    pVVar2->field3_0xc[iVar8 * 0xc + 4] = -10000.0f;
                    pVVar2->field3_0xc[iVar8 * 0xc + 5] = local_88;
                    pVVar2->field3_0xc[iVar8 * 0xc + 6] = -10000.0f;
                    pVVar2->field3_0xc[iVar8 * 0xc + 7] = -10000.0f;
                    pVVar2->field3_0xc[iVar8 * 0xc + 8] = local_88;
                    fVar4 = -10000.0f;
                    pVVar2->field3_0xc[iVar8 * 0xc + 9] = -10000.0f;
                    //iVar7 = extraout_EDX;
                } else {
                    pVVar2->field3_0xc[iVar8 * 0xc] =
                         local_7c *
                         (local_94 +
                         (float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6) *
                         local_80) - local_a0;
                    pVVar2->field3_0xc[iVar8 * 0xc + 1] =
                         local_84 *
                         (local_98 +
                         (float)(int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6)
                         * local_78) - local_74;
                    pVVar2->field3_0xc[iVar8 * 0xc + 2] = local_88;
                    pVVar2->field3_0xc[iVar8 * 0xc + 3] =
                         (local_94 -
                         (float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6) *
                         local_80) * local_7c - local_a0;
                    pVVar2->field3_0xc[iVar8 * 0xc + 4] =
                         local_84 *
                         (local_98 -
                         (float)(int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6)
                         * local_78) - local_74;
                    pVVar2->field3_0xc[iVar8 * 0xc + 5] = local_88;
                    pVVar2->field3_0xc[iVar8 * 0xc + 6] =
                         ((float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6) *
                          local_80 + local_94) * local_7c - local_a0;
                    pVVar2->field3_0xc[iVar8 * 0xc + 7] =
                         ((float)(int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6
                                                ) * local_78 + local_98) * local_84 - local_74;
                    pVVar2->field3_0xc[iVar8 * 0xc + 8] = local_88;
                    pVVar2->field3_0xc[iVar8 * 0xc + 9] =
                         local_7c *
                         (local_94 -
                         (float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6) *
                         local_80) - local_a0;
                    iVar7 = (int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6);
                    fVar4 = local_84 * (local_98 - (float)iVar7 * local_78) - local_74;
                    //local_70 = SUB84((double)iVar7, 0);
                    iVar7 = local_9c;
                }
                pVVar2->field3_0xc[iVar8 * 0xc + 10  ] = fVar4;
                pVVar2->field3_0xc[iVar8 * 0xc + 0xb ] = local_88;
                pVVar2->field4_0x10[iVar8 * 0xc      ] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x1] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x2] = 1.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x3] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x4] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x5] = 1.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x6] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x7] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x8] = 1.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0x9] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0xa] = 0.0f;
                pVVar2->field4_0x10[iVar8 * 0xc + 0xb] = 1.0f;
                //_local_70 = CONCAT44((float)(iVar8 * 4), local_70);
                //iVar8 = ftol((float)(iVar8 * 0xc), iVar7);
                sVar5 = (short)(iVar8 * 4);
                pVVar2->field7_0x1c[iVar8 * 6    ] = sVar5;
                pVVar2->field7_0x1c[iVar8 * 6 + 1] = (short)(sVar5 + 1);
                pVVar2->field7_0x1c[iVar8 * 6 + 2] = (short)(sVar5 + 2);
                pVVar2->field7_0x1c[iVar8 * 6 + 3] = (short)(sVar5 + 2);
                pVVar2->field7_0x1c[iVar8 * 6 + 4] = (short)(sVar5 + 1);
                pVVar2->field7_0x1c[iVar8 * 6 + 5] = (short)(sVar5 + 3);
                pVVar2->field1_0x4 = pVVar2->field1_0x4 + 4;
                pVVar2->field2_0x8 = pVVar2->field2_0x8 + 6;
                return 0;
            }
            local_8c = paVar6->field97_0x94;
            local_48.M11 = (float)(uint)*(byte*)(local_90 + 0x10 + param_1);
            local_48.M12 = (float)(uint)*(byte*)(local_90 + 0x11 + param_1);
            local_48.M13 = (float)(uint)*(byte*)(local_90 + 0x12 + param_1);
            local_48.M14 = (float)(uint)*(byte*)(local_90 + 0x13 + param_1);
            local_48.M21 = (float)(uint)*(byte*)(local_90 + 0x14 + param_1);
            local_48.M22 = (float)(uint)*(byte*)(local_90 + 0x15 + param_1);
            local_48.M23 = (float)(uint)*(byte*)(local_90 + 0x16 + param_1);
            local_48.M24 = (float)(uint)*(byte*)(local_90 + 0x17 + param_1);
            iVar8 = (int)(node_idx * num_characters - chr_id + -1);
            local_48.M31 = (float)(uint)*(byte*)(local_90 + 0x18 + param_1);
            local_48.M32 = (float)(uint)*(byte*)(local_90 + 0x19 + param_1);
            local_48.M33 = (float)(uint)*(byte*)(local_90 + 0x1a + param_1);
            local_48.M34 = (float)(uint)*(byte*)(local_90 + 0x1b + param_1);
            //_local_70 = CONCAT44(local_48.M34, local_70);
            local_48.M41 = local_48.M31;
            local_48.M42 = local_48.M32;
            local_48.M43 = local_48.M33;
            local_48.M44 = local_48.M34;
            FFXVu0MulVector.fnptr!((Vector4*)&local_48.M11, &rgba, (Vector4*)&local_48.M11);
            FFXVu0MulVector.fnptr!((Vector4*)&local_48.M21, &rgba, (Vector4*)&local_48.M21);
            FFXVu0MulVector.fnptr!((Vector4*)&local_48.M31, &rgba, (Vector4*)&local_48.M31);
            FFXVu0MulVector.fnptr!((Vector4*)&local_48.M41, &rgba, (Vector4*)&local_48.M41);
            //pfVar3 = local_8c->field5_0x14;
            local_8c->field5_0x14[iVar8 * 0x10      ] = local_48.M11 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 1  ] = local_48.M12 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 2  ] = local_48.M13 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 3  ] = local_48.M14 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 4  ] = local_48.M21 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 5  ] = local_48.M22 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 6  ] = local_48.M23 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 7  ] = local_48.M24 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 8  ] = local_48.M31 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 9  ] = local_48.M32 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 10 ] = local_48.M33 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 0xb] = local_48.M34 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 0xc] = local_48.M41 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 0xd] = local_48.M42 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 0xe] = local_48.M43 / 255.0f;
            local_8c->field5_0x14[iVar8 * 0x10 + 0xf] = local_48.M44 / 255.0f;
            if (*(byte*)((int)&param_2->rgba + 3) == 0) {
                //pfVar3 = local_8c->field3_0xc;
                local_8c->field3_0xc[iVar8 * 0xc      ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 1  ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 2  ] = local_88;
                local_8c->field3_0xc[iVar8 * 0xc + 3  ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 4  ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 5  ] = local_88;
                local_8c->field3_0xc[iVar8 * 0xc + 6  ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 7  ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 8  ] = local_88;
                local_8c->field3_0xc[iVar8 * 0xc + 9  ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 10 ] = -10000.0f;
                local_8c->field3_0xc[iVar8 * 0xc + 0xb] = local_88;
                return 0;
            }
            //pfVar3 = local_8c->field3_0xc;
            local_8c->field3_0xc[iVar8 * 0xc] =
                 local_7c *
                 (local_94 +
                 (float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6) *
                 local_80) - local_a0;
            local_8c->field3_0xc[iVar8 * 0xc + 1] =
                 local_84 *
                 (local_98 +
                 (float)(int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6) *
                 local_78) - local_74;
            local_8c->field3_0xc[iVar8 * 0xc + 2] = local_88;
            local_8c->field3_0xc[iVar8 * 0xc + 3] =
                 (local_94 -
                 (float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6) *
                 local_80) * local_7c - local_a0;
            local_8c->field3_0xc[iVar8 * 0xc + 4] =
                 local_84 *
                 (local_98 -
                 (float)(int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6) *
                 local_78) - local_74;
            local_8c->field3_0xc[iVar8 * 0xc + 5] = local_88;
            local_8c->field3_0xc[iVar8 * 0xc + 6] =
                 ((float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6) *
                  local_80 + local_94) * local_7c - local_a0;
            local_8c->field3_0xc[iVar8 * 0xc + 7] =
                 ((float)(int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x20 + param_1) * 6) *
                  local_78 + local_98) * local_84 - local_74;
            local_8c->field3_0xc[iVar8 * 0xc + 8] = local_88;
            local_8c->field3_0xc[iVar8 * 0xc + 9] =
                 local_7c *
                 (local_94 -
                 (float)(int)*(short*)(local_9c + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6) *
                 local_80) - local_a0;
            local_8c->field3_0xc[iVar8 * 0xc + 10] =
                 local_84 *
                 (local_98 -
                 (float)(int)*(short*)(local_9c + 2 + (uint)*(ushort*)(local_90 + 0x1e + param_1) * 6) *
                 local_78) - local_74;
            local_8c->field3_0xc[iVar8 * 0xc + 0xb] = local_88;
        }
        return 0;
    }

    void h_FUN_00a4b4b0() {
        byte bVar1;
        LpAbilityMapEngine *plVar2;
        uint *pfVar3;
        int iVar4;
        byte *pbVar5;

        pfVar3 = (uint*)user_malloc.fnptr!(0x1ec);
        plVar2 = lpamng;
        bVar1 = lpamng->current_chr_id;
        iVar4 = (int)lpamng->link_count;
        pfVar3[0x7a] = 0x3000;
        if (iVar4 != 0) {
            pbVar5 = &plVar2->links[0].point_count;
            do {
                iVar4 = iVar4 + -1;
                if ((pbVar5[-1] & '\x01' << (bVar1 & 0x1f)) == 0) {
                    pfVar3[0x50] = pfVar3[0x58];
                    pfVar3[0x51] = pfVar3[0x59];
                    pfVar3[0x52] = pfVar3[0x5a];
                    pfVar3[0x53] = pfVar3[0x5b];
                    pfVar3[0x54] = pfVar3[0x5c];
                    pfVar3[0x55] = pfVar3[0x5d];
                    pfVar3[0x56] = pfVar3[0x5e];
                    pfVar3[0x57] = pfVar3[0x5f];
                    FUN_00651720.fnptr!(pfVar3, (float*)*(SphereGridLinkPoint**)(pbVar5 + 3), (int)*pbVar5);
                }
                else if ((SphereGridLink*)(pbVar5 + -0xd) == lpamng->next_move_link) {
                    switch (lpamng->current_chr_id) {
                        case 0:
                            pfVar3[0x50] = 0x01000100;
                            break;
                        case 1:
                            pfVar3[0x50] = 0x01000200;
                            break;
                        case 2:
                            pfVar3[0x50] = 0x01000000;
                            break;
                        case 3:
                            pfVar3[0x50] = 0x01000001;
                            break;
                        case 4:
                            pfVar3[0x50] = 0x01000201;
                            break;
                        case 5:
                            pfVar3[0x50] = 0x01000101;
                            break;
                        case 6:
                            pfVar3[0x50] = 0x01000300;
                            break;
                        case 7:
                            pfVar3[0x50] = 0x01000301;
                            break;
                        default:
                            pfVar3[0x50] = 0x01000100; // Tidus color
                            break;
                    }
                    FUN_006521a0.fnptr!(pfVar3, (float*)*(SphereGridLinkPoint**)(pbVar5 + 3), (int)*pbVar5);
                }
                else {
                    switch (lpamng->current_chr_id) {
                        case 0:
                            pfVar3[0x50] = 0x100;
                            break;
                        case 1:
                            pfVar3[0x50] = 0x200;
                            break;
                        case 2:
                            pfVar3[0x50] = 0x0;
                            break;
                        case 3:
                            pfVar3[0x50] = 0x1;
                            break;
                        case 4:
                            pfVar3[0x50] = 0x201;
                            break;
                        case 5:
                            pfVar3[0x50] = 0x101;
                            break;
                        case 6:
                            pfVar3[0x50] = 0x300;
                            break;
                        case 7:
                            pfVar3[0x50] = 0x301;
                            break;
                        default:
                            pfVar3[0x50] = 0x100; // Tidus color
                            break;
                    }
                    FUN_006521a0.fnptr!(pfVar3, (float*)*(SphereGridLinkPoint**)(pbVar5 + 3), (int)*pbVar5);
                }
                pbVar5 = pbVar5 + 0x14;
            } while (iVar4 != 0);
        }
        user_free.fnptr!((nint)pfVar3);
        return;
    }

    // Initializes Sphere Grid
    void h_FUN_00a53de0(SaveSphereGrid* save_sphere_grid) {
        FUN_00653de0.chain_from(h_FUN_00a53de0).fnptr!(save_sphere_grid);
        custom_party_selected_node_idx = new short[num_characters - 7];
        for (int chr_id = 0; chr_id < num_characters-7; chr_id++) {
            uint grid_type = Globals.save_data->config_grid_type switch {
                0 => 0, // Original
                1 => 1, // Standard
                2 => 2, // Expert
                _ => 2, // Defaults to Expert?
            };
            custom_party_selected_node_idx[chr_id] = custom_starting_selected_node_idx[chr_id][grid_type];

            foreach (ushort node in custom_starting_activated_nodes[chr_id][grid_type]) {
                save_sphere_grid->nodes[node].activated_by |= (byte)(1 << (chr_id+7));
            }
        }
    }

    void h_eiAbmParaGet() {
        SaveSphereGrid *save_abmap;
        uint chr_bit;
        SphereGridNodeType *panel;
        int mp;
        int node_idx;
        int dummy_ref;
        MsChrAbilityMap *ability_map;
        uint local_50;
        int strength;
        int hp;
        int defense;
        int chr_id;
        int magic;
        int magic_defense;
        int accuracy;
        int agility;
        int evasion;
        int luck;
        int new_strength;
        int new_defense;
        byte _chr_id;
        SphereTargets sphere_effect;

        MsInitChrAbilityMap.fnptr!();
        chr_id = 0;
        do {
            mp = 0;
            hp = 0;
            strength = 0;
            defense = 0;
            magic = 0;
            magic_defense = 0;
            agility = 0;
            luck = 0;
            evasion = 0;
            accuracy = 0;
            ability_map = MsGetChrAbilityMap.fnptr!((uint)chr_id);
            save_abmap = MsGetSaveAbilityMap.fnptr!();
            node_idx = 0;
            _chr_id = (byte)((byte)chr_id & 0x1f);
            chr_bit = (uint)((1 << _chr_id) | (1U >> (0x20 - _chr_id)));
            local_50 = chr_bit;
            do {
                if ((save_abmap->nodes[node_idx].activated_by & (byte)chr_bit) != 0) {
                    panel = (SphereGridNodeType*)
                            FhXCall.MsGetExcelData.fnptr!((int)save_abmap->nodes[node_idx].node_type, _panel_bin_ptr, &dummy_ref)
                    ;
                    sphere_effect = panel->sphere_effect;
                    /* Strength */
                    if (sphere_effect.HasFlag(SphereTargets.STRENGTH)) {
                        strength = strength + panel->amount;
                    }
                    /* Defense */
                    if (sphere_effect.HasFlag(SphereTargets.DEFENSE)) {
                        defense = defense + panel->amount;
                    }
                    /* Magic */
                    if (sphere_effect.HasFlag(SphereTargets.MAGIC)) {
                        magic = magic + panel->amount;
                    }
                    /* Magic Defense */
                    if (sphere_effect.HasFlag(SphereTargets.MAGIC_DEFENSE)) {
                        magic_defense = magic_defense + panel->amount;
                    }
                    /* Agility */
                    if (sphere_effect.HasFlag(SphereTargets.AGILITY)) {
                        agility = agility + panel->amount;
                    }
                    /* Luck */
                    if (sphere_effect.HasFlag(SphereTargets.LUCK)) {
                        luck = luck + panel->amount;
                    }
                    /* Evasion */
                    if (sphere_effect.HasFlag(SphereTargets.EVASION)) {
                        evasion = evasion + panel->amount;
                    }
                    /* Accuracy */
                    if (sphere_effect.HasFlag(SphereTargets.ACCURACY)) {
                        accuracy = accuracy + panel->amount;
                    }
                    /* HP */
                    if (sphere_effect.HasFlag(SphereTargets.HP)) {
                        hp = hp + panel->amount;
                    }
                    /* MP */
                    if (sphere_effect.HasFlag(SphereTargets.MP)) {
                        mp = mp + panel->amount;
                    }
                    MsSetChrAbilityMapCommand.fnptr!((uint)chr_id, (uint)panel->ability_id);
                    chr_bit = local_50;
                }
                node_idx = node_idx + 1;
            } while (node_idx < 1024);
            new_strength = strength;
            if (255 < strength) {
                new_strength = 255;
            }
            new_defense = defense;
            if (255 < defense) {
                new_defense = 255;
            }
            if (255 < magic) {
                magic = 255;
            }
            if (255 < magic_defense) {
                magic_defense = 255;
            }
            if (255 < agility) {
                agility = 255;
            }
            if (255 < luck) {
                luck = 255;
            }
            if (255 < evasion) {
                evasion = 255;
            }
            if (255 < accuracy) {
                accuracy = 255;
            }
            ability_map->hp = hp;
            ability_map->magic = (byte)magic;
            ability_map->magic_defense = (byte)magic_defense;
            ability_map->agility = (byte)agility;
            ability_map->luck = (byte)luck;
            ability_map->evasion = (byte)evasion;
            ability_map->accuracy = (byte)accuracy;
            chr_id = chr_id + 1;
            ability_map->mp = mp;
            ability_map->strength = (byte)new_strength;
            ability_map->defense = (byte)new_defense;
        } while (chr_id < num_characters);
        MsSetSaveParamAll.fnptr!();
        return;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x48)]
    public struct FUN_003f49e0_param_2 {

        [FieldOffset(0x02)] public ushort __0x02;
        [FieldOffset(0x04)] public byte r;
        [FieldOffset(0x05)] public byte g;
        [FieldOffset(0x06)] public byte b;
        [FieldOffset(0x07)] public byte a;
        [FieldOffset(0x08)] public uint __0x08;
        [FieldOffset(0x0C)] public uint __0x0C;
        [FieldOffset(0x10)] public Matrix4x4* __0x10;

        [FieldOffset(0x18)] public byte __0x18;

        [FieldOffset(0x1C)] public Matrix4x4* __0x1C;
    }
    void h_FUN_00a53510() {
        uint uVar1;
        LpAbilityMapEngine* pLVar2;
        int iVar3;
        uint uVar4;
        int iVar5;
        uint uVar6;
        SphereGridNode* pSVar7;
        FUN_003f49e0_param_2 local_110;
        Matrix4x4 local_d8;
        Matrix4x4 local_98;
        Matrix4x4 local_58;

        iVar3 = lpamng->should_update_node;
        if (iVar3 != -2) {
            if (iVar3 < 0) {
                FUN_002390D0.fnptr!(1);
                FUN_00651340.fnptr!();
            } else {
                FUN_00651560.fnptr!(iVar3);
            }
        }
        pLVar2 = lpamng;
        if (lpamng->__0x115C3 != 1) {
            if (lpamng->__0x115C3 == 0) {
                FUN_0064fe40.fnptr!();
                lpamng->__0x115C3 = 2;
            }
            return;
        }
        uVar4 = (uint)(((float)(eff_sin_t)[lpamng->__0x1169C * 0x800 + -0x3ff1 >> 4 & 0xfff] + 1.0) * 24.0 + 128.0);
        if (pLVar2->__0x116A0 < 0x10) {
            iVar5 = (int)(uVar4 * pLVar2->__0x116A0);
            uVar4 = (uint)((int)(iVar5 + (iVar5 >> 0x1f & 0xfU)) >> 4);
        }
        uVar4 = uVar4 & 0xff;
        local_110.__0x08 = 0;
        local_110.__0x0C = 0;
        //uVar1 = *(uint*)(p_DAT_00c865bc + (uint)pLVar2->current_chr_id * 0x14);
        uVar1 = (uint)p_DAT_00c865bc[pLVar2->current_chr_id];
        local_110.__0x10 = &local_98;
        local_110.__0x1C = &local_58;
        local_58.M43 = 16384.0f;
        local_58.M44 = 1.0f;
        local_110.__0x18 = 0;
        local_110.__0x02 = 0x14;
        local_58.M11 = asmreg_0_zero->X;
        local_58.M21 = asmreg_0_zero->X;
        local_58.M31 = asmreg_0_zero->X;
        local_58.M41 = asmreg_0_zero->X;
        local_58.M14 = asmreg_0_zero->W;
        local_58.M24 = asmreg_0_zero->W;
        local_58.M34 = asmreg_0_zero->W;
        local_58.M12 = asmreg_0_zero->Y;
        local_58.M13 = asmreg_0_zero->Z;
        local_58.M22 = asmreg_0_zero->Y;
        local_58.M23 = asmreg_0_zero->Z;
        local_58.M32 = asmreg_0_zero->Y;
        local_58.M33 = asmreg_0_zero->Z;
        local_58.M42 = asmreg_0_zero->Y;
        iVar3 = (int)lpamng->node_count;
        pSVar7 = &lpamng->nodes[0];
        while (iVar3 != 0) {
            iVar3 = iVar3 + -1;
            if (pSVar7->node_type != NodeType.NULL) {
                FUN_0065ad30.fnptr!(&local_d8, pSVar7, 1.0f);
                cdc_FFXVu0MulMatrix.fnptr!(&local_98, &lpamng->__0x113E0, &local_d8);
                //uVar6 = -(uint)((pSVar7->properties & SphereGridNodeProperties.HIGHLIGHTED) != SphereGridNodeProperties.NONE) &
                //        ((((int)(((int)uVar1 >> 0x18 & 0xffU) * uVar4) >> 7) * 0x100 +
                //         ((int)(((int)uVar1 >> 0x10 & 0xffU) * uVar4) >> 7)) * 0x100 +
                //        ((int)(((int)uVar1 >> 8 & 0xffU) * uVar4) >> 7)) * 0x100 +
                //        ((int)((uVar1 & 0xff) * uVar4) >> 7);
                uVar6 = (uint)(-(uint)((pSVar7->properties & SphereGridNodeProperties.HIGHLIGHTED) != SphereGridNodeProperties.NONE ? 1 : 0) &
                        ((((int)(((int)uVar1 >> 0x18 & 0xffU) * uVar4) >> 7) * 0x100 +
                         ((int)(((int)uVar1 >> 0x10 & 0xffU) * uVar4) >> 7)) * 0x100 +
                        ((int)(((int)uVar1 >> 8 & 0xffU) * uVar4) >> 7)) * 0x100 +
                        ((int)((uVar1 & 0xff) * uVar4) >> 7));

                local_110.r = (byte)uVar6;
                local_110.g = (byte)(uVar6 >> 8);
                local_110.g = (byte)(local_110.g >> 1);
                local_110.r = (byte)(local_110.r >> 1);
                local_110.b = (byte)(uVar6 >> 0x10);
                local_110.b = (byte)(local_110.b >> 1);
                local_110.a = (byte)(uVar6 >> 0x19);
                FUN_003f49e0.fnptr!(*(int*)((int)&pLVar2->node_type_infos[(int)pSVar7->node_type] + 8), &local_110,
                             iVar3 - lpamng->node_count, lpamng->__0x116A4);
            }
            pSVar7 = pSVar7 + 1;
        }
        return;
    }

    int h_FUN_008efd90(int param_1, int chr_id, int param_3, int param_4, int param_5, int param_6, int param_7, int param_8, int param_9) {
        if (chr_id == 7) {
            int iVar1;
            uint uVar2;
            float local_b8;
            float local_b4;
            float local_b0;
            float local_ac;
            float local_a4;
            byte* texture_name;
            graphicDrawUIAbmapElement_param1 local_a0 = new();

            // Seymour
            chr_id = 8; // Skip second Rikku face

            if (param_9 == 6) {
                texture_name = FhXCall.TOGetShapTextureName.fnptr!(0x2ed0);
                FhXCall.TOGetImageWH.fnptr!(0x2ed0, &local_b4, &local_b8);

                local_a0.floats0[0] = (float)param_3;
                local_a0.floats0[1] = (float)param_4;
                //uVar2 = chr_id & 0x80000003;
                uVar2 = 4;
                if ((int)uVar2 < 0) {
                    uVar2 = (uVar2 - 1 | 0xfffffffc) + 1;
                }
                local_a0.floats0[2] = (float)(int)(uVar2 * 100) / local_b4;
                //iVar1 = ((int)(((int)chr_id >> 0x1f & 3U) + chr_id) >> 2) * 100;
                iVar1 = 1 * 100;
                local_a4 = (float)iVar1;
                local_a0.ints0[0] = param_5;
                local_a0.floats0[3] = local_a4 / local_b8;
                local_a0.ints0[1] = param_6;
                local_a0.ints0[2] = param_7;
                local_a0.ints0[3] = param_8;
                local_a0.floats1[0] = (float)(local_a0.floats0[0] + 53.333332);
                local_a0.floats1[1] = (float)(local_a0.floats0[1] + 77.03704);
                local_a0.floats1[2] = (float)(int)(uVar2 * 100 + 100) / local_b4;
                local_b0 = (float)(iVar1 + 100);
                local_a0.ints1[0] = param_5;
                local_a0.floats1[3] = local_b0 / local_b8;
                local_a0.ints1[1] = param_6;
                local_a0.ints1[2] = param_7;
                local_a0.ints1[3] = param_8;
                graphicDrawUIElement.fnptr!(&local_a0, texture_name, 1, 0, 6);
                return param_1;
            }
            texture_name = FhXCall.TOGetShapTextureName.fnptr!(0x2ed0);
            FhXCall.TOGetImageWH.fnptr!(0x2ed0, &local_b4, &local_b8);
            local_a0.floats0[0] = (float)param_3;
            local_a0.floats0[1] = (float)param_4;
            //uVar2 = chr_id & 0x80000003;
            uVar2 = 4;
            if ((int)uVar2 < 0) {
                uVar2 = (uVar2 - 1 | 0xfffffffc) + 1;
            }
            local_b0 = (float)(uVar2 * 100);
            local_a0.floats0[2] = (float)(int)local_b0 / local_b4;
            //local_a4 = (float)(((int)(((int)chr_id >> 0x1f & 3U) + chr_id) >> 2) * 100);
            local_a4 = 1 * 100;
            local_a0.floats0[3] = (float)(int)local_a4 / local_b8;
            local_a0.ints0[0] = param_5;
            local_a0.ints0[1] = param_6;
            local_a0.ints0[2] = param_7;
            local_a0.ints0[3] = param_8;
            local_a0.floats1[0] = (float)(local_a0.floats0[0] + 63.0);
            local_a0.floats1[1] = (float)(param_4 + 0x62);
            local_a0.floats1[2] = (float)((int)local_b0 + 100) / local_b4;
            local_ac = (float)((int)local_a4 + 100);
            local_a0.ints1[0] = param_5;
            local_a0.floats1[3] = local_ac / local_b8;
            local_a0.ints1[1] = param_6;
            local_a0.ints1[2] = param_7;
            local_a0.ints1[3] = param_8;
            graphicDrawUIElement.fnptr!(&local_a0, texture_name, 1, 0, 0);
            return param_1;
        } else {
            return FUN_008efd90.chain_from(h_FUN_008efd90).fnptr!(param_1, chr_id, param_3, param_4, param_5, param_6, param_7, param_8, param_9);
        }
    }

    bool h_FUN_00a5d120(byte sphere_type, int node_idx, SphereGridNodeType* param_3, int chr_id) {
        byte bVar1;
        int  iVar3;
        bool bVar4;

        switch (sphere_type) {
            case 1:
                bVar4 = param_3->icon_id == 0x12;
                goto LAB_00a5d141;
            case 2:
                if (param_3->icon_id == 0x11) {
                    return true;
                }
                break;
            case 3:
                if (param_3->icon_id == 0) {
                    return true;
                }
                break;
            case 4:
                if (param_3->icon_id == 0x10) {
                    return true;
                }
                break;
            case 5:
            case 6:
            case 7:
            case 0x10:
            case 0x11:
            case 0x12:
            case 0x13:
            case 0x14:
            case 0x15:
            case 0x16:
                if (param_3->icon_id == 0x01) {
                    return true;
                }
                break;
            case 8:
                iVar3 = FUN_006457d0.fnptr!(chr_id, node_idx);
                if (iVar3 != 0) {
                    return false;
                }
                bVar4 = param_3->icon_id == 0x0f;
                goto LAB_00a5d1cc;
            case 9:
                iVar3 = FUN_006457d0.fnptr!(chr_id, node_idx);
                if (iVar3 != 0) {
                    return false;
                }
                bVar4 = param_3->icon_id == 0x0e;
                goto LAB_00a5d1cc;
            case 10:
                iVar3 = FUN_006457d0.fnptr!(chr_id, node_idx);
                if (iVar3 != 0) {
                    return false;
                }
                bVar4 = param_3->icon_id == 0x0c;
                goto LAB_00a5d1cc;
            case 0xb:
                iVar3 = FUN_006457d0.fnptr!(chr_id, node_idx);
                if (iVar3 != 0) {
                    return false;
                }
                bVar4 = param_3->icon_id == 0x0d;
            LAB_00a5d1cc:
                if (bVar4) {
                LAB_00a5d1d4:
                    iVar3 = FUN_00645800.fnptr!(chr_id, node_idx) ? 1 : 0;
                LAB_00a5d1d9:
                    if (iVar3 != 0) {
                        return true;
                    }
                }
                break;
            case 0xc:
                iVar3 = FUN_00645870.fnptr!(chr_id);
                if (iVar3 == node_idx) {
                    return false;
                }
                iVar3 = FUN_006457d0.fnptr!(chr_id, node_idx);
                //goto LAB_00a5d1d9;
                if (iVar3 != 0) {
                    return true;
                }
                break;
            case 0xd:
                iVar3 = FUN_00645870.fnptr!(chr_id);
                if (iVar3 == node_idx) {
                    return false;
                }
                //goto LAB_00a5d1d4;
                iVar3 = FUN_00645800.fnptr!(chr_id, node_idx) ? 1 : 0;
                if (iVar3 != 0) {
                    return true;
                }
                break;
            case 0xe:
                iVar3 = FUN_00645870.fnptr!(chr_id);
                if (iVar3 == node_idx) {
                    return false;
                }
                iVar3 = 0;

                for (byte i = 0; i < num_characters; i++) {
                    if (chr_id != i && FhXCall.MsGetSavePlyJoined.fnptr!(i) && FUN_00645870.fnptr!(i) == node_idx) {
                        return true;
                    }
                }
                return false;
            case 0xf:
                iVar3 = FUN_00645870.fnptr!(chr_id);
                if (iVar3 == node_idx) {
                    return false;
                }
                bVar4 = ((short)param_3->sphere_effect & 0x8000U) == 0;
            LAB_00a5d141:
                if (bVar4) {
                    return true;
                }
                break;
            case 0x17:
                bVar1 = (byte)param_3->icon_id;
                if ((1 < bVar1) && (bVar1 < 0xc)) {
                    return true;
                }
                break;
            case 0x18:
                /* Attribute Sphere */
                iVar3 = FUN_006457d0.fnptr!(chr_id, node_idx);
                bVar1 = (byte)param_3->icon_id;
                if ((((iVar3 == 0) && (1 < bVar1)) && (bVar1 < 0xc)) &&
                   (FUN_00645800.fnptr!(chr_id, node_idx))) {
                    return true;
                }
                break;
        }
        return false;
    }

    bool h_FUN_00a45800(int chr_id, int nodes_idx) {
        byte activated_by = lpamng->nodes[nodes_idx].activated_by;

        for (byte i = 0; i < num_characters; i++) {
            if (i != chr_id && FhXCall.MsGetSavePlyJoined.fnptr!(i) && (activated_by & (1 << i)) != 0) {
                return true;
            }
        }
        return false;
    }

    // TODO: Hook abmap_para_get_special to clear node activation for custom character as well
}
