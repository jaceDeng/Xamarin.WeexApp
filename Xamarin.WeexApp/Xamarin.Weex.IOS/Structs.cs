using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using WeexSDK;

namespace WeexSDK
{



    public enum wx_css_direction_t : uint
    {
        Inherit = 0,
        Ltr,
        Rtl
    }

    public enum wx_css_flex_direction_t : uint
    {
        Column = 0,
        ColumnReverse,
        Row,
        RowReverse
    }

    public enum wx_css_justify_t : uint
    {
        FlexStart = 0,
        Center,
        FlexEnd,
        SpaceBetween,
        SpaceAround
    }

    public enum wx_css_align_t : uint
    {
        Auto = 0,
        FlexStart,
        Center,
        FlexEnd,
        Stretch
    }

    public enum wx_css_position_type_t : uint
    {
        Relative = 0,
        Absolute
    }

    public enum wx_css_wrap_type_t : uint
    {
        Nowrap = 0,
        Wrap
    }

    public enum wx_css_position_t : uint
    {
        Left = 0,
        Top,
        Right,
        Bottom,
        Start,
        End,
        PositionCount
    }

    public enum css_measure_mode_t : uint
    {
        Undefined = 0,
        Exactly,
        AtMost
    }

    public enum wx_css_dimension_t : uint
    {
        Width = 0,
        Height
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct wx_css_layout_t
    {
        public float[] position;

        public float[] dimensions;

        public wx_css_direction_t direction;

        public bool should_update;

        public float[] last_requested_dimensions;

        public float last_parent_max_width;

        public float last_parent_max_height;

        public float[] last_dimensions;

        public float[] last_position;

        public wx_css_direction_t last_direction;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct wx_css_dim_t
    {
        public float[] dimensions;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct wx_css_style_t
    {
        public wx_css_direction_t direction;

        public wx_css_flex_direction_t flex_direction;

        public wx_css_justify_t justify_content;

        public wx_css_align_t align_content;

        public wx_css_align_t align_items;

        public wx_css_align_t align_self;

        public wx_css_position_type_t position_type;

        public wx_css_wrap_type_t flex_wrap;

        public float flex;

        public float[] margin;

        public float[] position;

        public float[] padding;

        public float[] border;

        public float[] dimensions;

        public float[] minDimensions;

        public float[] maxDimensions;
    }

      [StructLayout (LayoutKind.Sequential)]
    public struct wx_css_node_t{


    }

    [StructLayout (LayoutKind.Sequential)]
    public struct wx_css_node
    {
        public wx_css_style_t style;

        public wx_css_layout_t layout;

        public int children_count;

        public int line_index;

        public unsafe wx_css_node_t next_absolute_child;

        public unsafe wx_css_node_t next_flex_child;

        public unsafe Func<Action, float, css_measure_mode_t, float, css_measure_mode_t, wx_css_dim_t> measure;

        public unsafe Action<Action> print;

        public unsafe Func<Action, int, WeexSDK.wx_css_node> get_child;

        public unsafe Func<Action, bool> is_dirty;

        public unsafe void* context;
    }

    static class CFunctions
    {
        // extern wx_css_node_t * wx_new_css_node ();
        [DllImport ("__Internal")]
      //  [Verify (PlatformInvoke)]
        static extern unsafe wx_css_node_t wx_new_css_node ();

        // extern void wx_init_css_node (wx_css_node_t *node);
        [DllImport ("__Internal")]
      //  [Verify (PlatformInvoke)]
        static extern unsafe void wx_init_css_node (wx_css_node_t node);

        // extern void wx_free_css_node (wx_css_node_t *node);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern unsafe void wx_free_css_node (wx_css_node_t node);

        // extern void wx_print_css_node (wx_css_node_t *node, wx_css_print_options_t options);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern unsafe void wx_print_css_node (wx_css_node_t node, wx_css_print_options_t options);

        // extern _Bool wx_isUndefined (float value);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern bool wx_isUndefined (float value);

        // extern void wx_layoutNode (wx_css_node_t *node, float maxWidth, float maxHeight, wx_css_direction_t parentDirection);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern unsafe void wx_layoutNode (wx_css_node_t node, float maxWidth, float maxHeight, wx_css_direction_t parentDirection);

        // extern void wx_resetNodeLayout (wx_css_node_t *node);
        [DllImport ("__Internal")]
      //  [Verify (PlatformInvoke)]
        static extern unsafe void wx_resetNodeLayout (wx_css_node_t node);

        // extern void _WXLogObjectsImpl (NSString *severity, NSArray *arguments);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke), Verify (StronglyTypedNSArray)]
        static extern void _WXLogObjectsImpl (NSString severity, NSObject[] arguments);

        // extern void WXPerformBlockOnMainThread (void (^ _Nonnull)() block);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern void WXPerformBlockOnMainThread (Action block);

        // extern void WXPerformBlockSyncOnMainThread (void (^ _Nonnull)() block);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern void WXPerformBlockSyncOnMainThread (Action block);

        // extern void WXPerformBlockOnThread (void (^ _Nonnull)() block, NSThread * _Nonnull thread);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern void WXPerformBlockOnThread (Action block, NSThread thread);

        // extern void WXSwizzleInstanceMethod (Class _Nonnull className, SEL _Nonnull original, SEL _Nonnull replaced);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern void WXSwizzleInstanceMethod (Class className, Selector original, Selector replaced);

        // extern void WXSwizzleInstanceMethodWithBlock (Class _Nonnull className, SEL _Nonnull original, id _Nonnull block, SEL _Nonnull replaced);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern void WXSwizzleInstanceMethodWithBlock (Class className, Selector original, NSObject block, Selector replaced);

        // extern SEL _Nonnull WXSwizzledSelectorForSelector (SEL _Nonnull selector);
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        static extern Selector WXSwizzledSelectorForSelector (Selector selector);

        // extern CGFloat WXScreenScale ();
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern nfloat WXScreenScale ();

        // extern CGFloat WXRoundPixelValue (CGFloat value);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern nfloat WXRoundPixelValue (nfloat value);

        // extern CGFloat WXFloorPixelValue (CGFloat value);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern nfloat WXFloorPixelValue (nfloat value);

        // extern CGFloat WXCeilPixelValue (CGFloat value);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern nfloat WXCeilPixelValue (nfloat value);

        // extern CGFloat WXPixelScale (CGFloat value, CGFloat scaleFactor);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern nfloat WXPixelScale (nfloat value, nfloat scaleFactor);

        // extern CGFloat WXScreenResizeRadio () __attribute__((deprecated("Use [WXUtility defaultPixelScaleFactor] instead")));
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern nfloat WXScreenResizeRadio ();

        // extern CGFloat WXPixelResize (CGFloat value) __attribute__((deprecated("Use WXPixelScale Instead")));
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern nfloat WXPixelResize (nfloat value);

        // extern CGRect WXPixelFrameResize (CGRect value) __attribute__((deprecated("Use WXPixelScale Instead")));
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern CGRect WXPixelFrameResize (CGRect value);

        // extern CGPoint WXPixelPointResize (CGPoint value) __attribute__((deprecated("Use WXPixelScale Instead")));
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern CGPoint WXPixelPointResize (CGPoint value);

        // extern BOOL WXFloatEqual (CGFloat a, CGFloat b);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern bool WXFloatEqual (nfloat a, nfloat b);

        // extern BOOL WXFloatEqualWithPrecision (CGFloat a, CGFloat b, double precision);
        [DllImport ("__Internal")]
//[Verify (PlatformInvoke)]
        static extern bool WXFloatEqualWithPrecision (nfloat a, nfloat b, double precision);

        // extern BOOL WXFloatLessThan (CGFloat a, CGFloat b);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern bool WXFloatLessThan (nfloat a, nfloat b);

        // extern BOOL WXFloatLessThanWithPrecision (CGFloat a, CGFloat b, double precision);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern bool WXFloatLessThanWithPrecision (nfloat a, nfloat b, double precision);

        // extern BOOL WXFloatGreaterThan (CGFloat a, CGFloat b);
        [DllImport ("__Internal")]
      //  [Verify (PlatformInvoke)]
        static extern bool WXFloatGreaterThan (nfloat a, nfloat b);

        // extern BOOL WXFloatGreaterThanWithPrecision (CGFloat a, CGFloat b, double precision);
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern bool WXFloatGreaterThanWithPrecision (nfloat a, nfloat b, double precision);

        // extern void WXPerformBlockOnBridgeThread (void (^block)());
        [DllImport ("__Internal")]
      //  [Verify (PlatformInvoke)]
        static extern void WXPerformBlockOnBridgeThread (Action block);

        // extern void WXPerformBlockOnComponentThread (void (^block)());
        [DllImport ("__Internal")]
       // [Verify (PlatformInvoke)]
        static extern void WXPerformBlockOnComponentThread (Action block);
    }

    public enum wx_css_print_options_t : uint
    {
        Layout = 1,
        Style = 2,
        Children = 4
    }

    [Native]
    public enum WXComponentType : long
    {
        Common = 0,
        Virtual
    }

    [Native]
    public enum WXScrollDirection : long
    {
        Vertical,
        Horizontal,
        None
    }

    [Native]
    public enum WXTextStyle : long
    {
        Normal = 0,
        Italic
    }

    [Native]
    public enum WXTextDecoration : long
    {
        None = 0,
        Underline,
        LineThrough
    }

    [Native]
    public enum WXImageQuality : long
    {
        Original = -1,
        Low = 0,
        Normal,
        High,
        None
    }

    [Native]
    public enum WXImageSharp : long
    {
        None = 0,
        WXImageSharpening
    }

    [Native]
    public enum WXVisibility : long
    {
        Show = 0,
        Hidden
    }

    [Native]
    public enum WXBorderStyle : long
    {
        None = 0,
        Dotted,
        Dashed,
        Solid
    }

    [Native]
    public enum WXPositionType : long
    {
        Relative = 0,
        Absolute,
        Sticky,
        Fixed
    }

    [Native]
    public enum WXGradientType : long
    {
        Top = 0,
        Bottom,
        Left,
        Right,
        Topleft,
        Bottomright
    }

    [Native]
    public enum WXResourceType : long
    {
        MainBundle,
        ServiceBundle,
        Image,
        Font,
        Video,
        Link,
        Others
    }

    [Native]
    public enum WXState : long
    {
        Appear = 100,
        Disappear,
        Foreground,
        Background,
        MemoryWarning,
        BindChanged,
        Destroy
    }

    [Native]
    public enum WXErrorType : long
    {
        TemplateErrorType = 1
    }

    [Native]
    public enum WXErrorCode : long
    {
        PlatformErrorCode = 1000,
        OSVersionErrorCode,
        AppVersionErrorCode,
        WeexSDKVersionErrorCode,
        DeviceModelErrorCode,
        FrameworkVersionErrorCode
    }

    [Native]
    public enum WXLogFlag : long
    {
        Error = 1 << 0,
        Warning = 1 << 1,
        Info = 1 << 2,
        Log = 1 << 3,
        Debug = 1 << 4
    }

    [Native]
    public enum WXLogLevel : long
    {
        Off = 0,
        Error = WXLogFlag.Error,
        Warning = Error | WXLogFlag.Warning,
        Info = Warning | WXLogFlag.Info,
        Log = WXLogFlag.Log | Info,
        Debug = Log | WXLogFlag.Debug,
        All = int.MaxValue  //(9223372036854775807L * 2 + 1)
    }

    public enum WXSDKErrCode
    {
        JsframeworkStart = -1001,
        JsframeworkLoad = -1002,
        JsframeworkExecute = -1003,
        JsframeworkEnd = -1099,
        JsbridgeStart = -2001,
        JsfuncParam = -2009,
        InvokeNative = -2012,
        JsExecute = -2013,
        JsbridgeEnd = -2099,
        RenderStart = -2100,
        RenderCreatebody = -2100,
        RenderUpdattr = -2101,
        RenderUpdstyle = -2102,
        RenderAddelement = -2103,
        RenderRemoveelement = -2104,
        RenderMoveelement = -2105,
        RenderAddevent = -2106,
        RenderRemoveevent = -2107,
        RenderScrolltoelement = -2110,
        RenderEnd = -2199,
        DownloadStart = -2201,
        JsbundleDownload = -2202,
        JsbundleStringConvert = -2203,
        NotConnectedToInternet = -2205,
        Cancel = -2204,
        DownloadEnd = -2299
    }

    [Native]
    public enum WXNavigationItemPosition : long
    {
        Center = 0,
        Right,
        Left,
        More
    }

    [Native]
    public enum WXPerformanceTag : long
    {
        Initalize = 0,
        InitalizeSync,
        FrameworkExecute,
        JSDownload,
        JSCreateInstance,
        FirstScreenRender,
        AllRender,
        BundleSize,
        End
    }

    [Native]
    public enum WXMonitorTag : long
    {
        JSFramework,
        JSDownload,
        JSBridge,
        NativeRender,
        JSService
    }

    public enum WXPointIndicatorAlignStyle : uint
    {
        Center,
        Left,
        Right
    }
}
