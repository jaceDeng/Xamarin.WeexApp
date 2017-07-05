using System;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using JavaScriptCore;
using ObjCRuntime;
using UIKit;
using WeexSDK;

namespace WeexSDK
{
    // typedef void (^WXCallback)(id _Nonnull);
    delegate void WXCallback(NSObject arg0);

    // typedef void (^WXKeepAliveCallback)(id _Nonnull, BOOL);
    delegate void WXKeepAliveCallback(NSObject arg0, bool arg1);

    // @interface WXComponent : NSObject
    [BaseType(typeof(NSObject))]
    interface WXComponent
    {
        // -(instancetype _Nonnull)initWithRef:(NSString * _Nonnull)ref type:(NSString * _Nonnull)type styles:(NSDictionary * _Nullable)styles attributes:(NSDictionary * _Nullable)attributes events:(NSArray * _Nullable)events weexInstance:(WXSDKInstance * _Nonnull)weexInstance;
        [Export("initWithRef:type:styles:attributes:events:weexInstance:")]
        //[Verify(StronglyTypedNSArray)]
        IntPtr Constructor(string @ref, string type, [NullAllowed] NSDictionary styles, [NullAllowed] NSDictionary attributes, [NullAllowed] NSObject[] events, WXSDKInstance weexInstance);

        // @property (readonly, nonatomic, strong) NSString * _Nonnull ref;
        [Export("ref", ArgumentSemantic.Strong)]
        string Ref { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (assign, nonatomic) WXComponentType componentType;
        [Export("componentType", ArgumentSemantic.Assign)]
        WXComponentType ComponentType { get; set; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nonnull styles;
        [Export("styles", ArgumentSemantic.Strong)]
        NSDictionary Styles { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nonnull pseudoClassStyles;
        [Export("pseudoClassStyles", ArgumentSemantic.Strong)]
        NSDictionary PseudoClassStyles { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nonnull attributes;
        [Export("attributes", ArgumentSemantic.Strong)]
        NSDictionary Attributes { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull events;
        [Export("events", ArgumentSemantic.Strong)]
        //	[Verify(StronglyTypedNSArray)]
        NSObject[] Events { get; }

        // @property (readonly, nonatomic, weak) WXSDKInstance * _Nullable weexInstance;
        [NullAllowed, Export("weexInstance", ArgumentSemantic.Weak)]
        WXSDKInstance WeexInstance { get; }

        // @property (readonly, nonatomic, strong) NSArray<WXComponent *> * _Nullable subcomponents;
        [NullAllowed, Export("subcomponents", ArgumentSemantic.Strong)]
        WXComponent[] Subcomponents { get; }

        // @property (readonly, nonatomic, weak) WXComponent * _Nullable supercomponent;
        [NullAllowed, Export("supercomponent", ArgumentSemantic.Weak)]
        WXComponent Supercomponent { get; }

        // @property (readonly, assign, nonatomic) CGRect calculatedFrame;
        [Export("calculatedFrame", ArgumentSemantic.Assign)]
        CGRect CalculatedFrame { get; }

        // @property (assign, nonatomic) BOOL isViewFrameSyncWithCalculated;
        [Export("isViewFrameSyncWithCalculated")]
        bool IsViewFrameSyncWithCalculated { get; set; }

        // @property (readonly, assign, nonatomic) wx_css_node_t * _Nonnull cssNode;
        [Export("cssNode", ArgumentSemantic.Assign)]
        unsafe wx_css_node_t CssNode { get; }

        // -(void)setNeedsLayout;
        [Export("setNeedsLayout")]
        void SetNeedsLayout();

        // -(BOOL)needsLayout;
        [Export("needsLayout")]
        //[Verify(MethodToProperty)]
        bool NeedsLayout { get; }

        // -(CGSize (^ _Nullable)(CGSize))measureBlock;
        [NullAllowed, Export("measureBlock")]
        //	[Verify(MethodToProperty)]
        Func<CGSize, CGSize> MeasureBlock { get; }

        // -(void)layoutDidFinish;
        [Export("layoutDidFinish")]
        void LayoutDidFinish();

        // @property (readonly, nonatomic, strong) UIView * _Nonnull view;
        [Export("view", ArgumentSemantic.Strong)]
        UIView View { get; }

        // @property (readonly, nonatomic, strong) CALayer * _Nonnull layer;
        [Export("layer", ArgumentSemantic.Strong)]
        CALayer Layer { get; }

        // -(UIView * _Nonnull)loadView;
        [Export("loadView")]
        //[Verify(MethodToProperty)]
        UIView LoadView { get; }

        // -(BOOL)isViewLoaded;
        [Export("isViewLoaded")]
        //	[Verify(MethodToProperty)]
        bool IsViewLoaded { get; }

        // -(void)viewWillLoad;
        [Export("viewWillLoad")]
        void ViewWillLoad();

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        void ViewDidLoad();

        // -(void)viewWillUnload;
        [Export("viewWillUnload")]
        void ViewWillUnload();

        // -(void)viewDidUnload;
        [Export("viewDidUnload")]
        void ViewDidUnload();

        // -(void)insertSubview:(WXComponent * _Nonnull)subcomponent atIndex:(NSInteger)index;
        [Export("insertSubview:atIndex:")]
        void InsertSubview(WXComponent subcomponent, nint index);

        // -(void)willRemoveSubview:(WXComponent * _Nonnull)component;
        [Export("willRemoveSubview:")]
        void WillRemoveSubview(WXComponent component);

        // -(void)removeFromSuperview;
        [Export("removeFromSuperview")]
        void RemoveFromSuperview();

        // -(void)moveToSuperview:(WXComponent * _Nonnull)newSupercomponent atIndex:(NSUInteger)index;
        [Export("moveToSuperview:atIndex:")]
        void MoveToSuperview(WXComponent newSupercomponent, nuint index);

        // -(void)fireEvent:(NSString * _Nonnull)eventName params:(NSDictionary * _Nullable)params;
        [Export("fireEvent:params:")]
        void FireEvent(string eventName, [NullAllowed] NSDictionary @params);

        // -(void)fireEvent:(NSString * _Nonnull)eventName params:(NSDictionary * _Nullable)params domChanges:(NSDictionary * _Nullable)domChanges;
        [Export("fireEvent:params:domChanges:")]
        void FireEvent(string eventName, [NullAllowed] NSDictionary @params, [NullAllowed] NSDictionary domChanges);

        // -(void)updateStyles:(NSDictionary * _Nonnull)styles;
        [Export("updateStyles:")]
        void UpdateStyles(NSDictionary styles);

        // -(void)resetStyles:(NSArray * _Nonnull)styles;
        [Export("resetStyles:")]
        //[Verify(StronglyTypedNSArray)]
        void ResetStyles(NSObject[] styles);

        // -(void)updateAttributes:(NSDictionary * _Nonnull)attributes;
        [Export("updateAttributes:")]
        void UpdateAttributes(NSDictionary attributes);

        // -(void)addEvent:(NSString * _Nonnull)eventName;
        [Export("addEvent:")]
        void AddEvent(string eventName);

        // -(void)removeEvent:(NSString * _Nonnull)eventName;
        [Export("removeEvent:")]
        void RemoveEvent(string eventName);

        // -(void)setNeedsDisplay;
        [Export("setNeedsDisplay")]
        void SetNeedsDisplay();

        // -(BOOL)needsDrawRect;
        [Export("needsDrawRect")]
        //	[Verify(MethodToProperty)]
        bool NeedsDrawRect { get; }

        // -(UIImage * _Nonnull)drawRect:(CGRect)rect;
        [Export("drawRect:")]
        UIImage DrawRect(CGRect rect);

        // -(void)didFinishDrawingLayer:(BOOL)success;
        [Export("didFinishDrawingLayer:")]
        void DidFinishDrawingLayer(bool success);

        // -(void)readyToRender;
        [Export("readyToRender")]
        void ReadyToRender();

        // -(void)triggerDisplay;
        [Export("triggerDisplay")]
        void TriggerDisplay();

        // -(CGContextRef _Nonnull)beginDrawContext:(CGRect)bounds;
        [Export("beginDrawContext:")]
        unsafe CGContext BeginDrawContext(CGRect bounds);

        // -(UIImage * _Nonnull)endDrawContext:(CGContextRef _Nonnull)context;
        [Export("endDrawContext:")]
        unsafe UIImage EndDrawContext(CGContext context);
    }

    // typedef UIImage * _Nonnull (^WXDisplayBlock)(CGRect, BOOL (^ _Nonnull)(void));
    delegate UIImage WXDisplayBlock(CGRect arg0, Func<bool> arg1);

    // typedef void (^WXDisplayCompletionBlock)(CALayer * _Nonnull, BOOL);
    delegate void WXDisplayCompletionBlock(CALayer arg0, bool arg1);

    // @interface WXComponent (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_WXComponent
    {
        // @property (nonatomic, weak) WXComponent * _Nullable wx_component;
        [NullAllowed,Static ,Export("wx_component", ArgumentSemantic.Weak)]
        WXComponent Wx_component { get; set; }

        // @property (nonatomic, weak) NSString * _Nullable wx_ref;
        [NullAllowed,Static, Export("wx_ref", ArgumentSemantic.Weak)]
        string Wx_ref { get; set; }
    }

    // @interface WXComponent (CALayer)
    [Category]
    [BaseType(typeof(CALayer))]
    interface CALayer_WXComponent
    {
        // @property (nonatomic, weak) WXComponent * _Nullable wx_component;
        [NullAllowed, Static, Export("wx_component", ArgumentSemantic.Weak)]
        WXComponent Wx_component { get; set; }
    }

    // @interface WXJSExceptionInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface WXJSExceptionInfo
    {
        // @property (nonatomic, strong) NSString * instanceId;
        [Export("instanceId", ArgumentSemantic.Strong)]
        string InstanceId { get; set; }

        // @property (nonatomic, strong) NSString * bundleUrl;
        [Export("bundleUrl", ArgumentSemantic.Strong)]
        string BundleUrl { get; set; }

        // @property (nonatomic, strong) NSString * errorCode;
        [Export("errorCode", ArgumentSemantic.Strong)]
        string ErrorCode { get; set; }

        // @property (nonatomic, strong) NSString * functionName;
        [Export("functionName", ArgumentSemantic.Strong)]
        string FunctionName { get; set; }

        // @property (nonatomic, strong) NSString * exception;
        [Export("exception", ArgumentSemantic.Strong)]
        string Exception { get; set; }

        // @property (nonatomic, strong) NSMutableDictionary * userInfo;
        [Export("userInfo", ArgumentSemantic.Strong)]
        NSMutableDictionary UserInfo { get; set; }

        // @property (readonly, nonatomic, strong) NSString * sdkVersion;
        [Export("sdkVersion", ArgumentSemantic.Strong)]
        string SdkVersion { get; }

        // @property (readonly, nonatomic, strong) NSString * jsfmVersion;
        [Export("jsfmVersion", ArgumentSemantic.Strong)]
        string JsfmVersion { get; }

        // -(instancetype)initWithInstanceId:(NSString *)instanceId bundleUrl:(NSString *)bundleUrl errorCode:(NSString *)errorCode functionName:(NSString *)functionName exception:(NSString *)exception userInfo:(NSMutableDictionary *)userInfo;
        [Export("initWithInstanceId:bundleUrl:errorCode:functionName:exception:userInfo:")]
        IntPtr Constructor(string instanceId, string bundleUrl, string errorCode, string functionName, string exception, NSMutableDictionary userInfo);
    }

    // @interface WXResourceResponse : NSURLResponse
    [BaseType(typeof(NSUrlResponse))]
    interface WXResourceResponse
    {
    }

    // @interface WXResourceRequest : NSMutableURLRequest
    [BaseType(typeof(NSMutableUrlRequest))]
    interface WXResourceRequest
    {
        // @property (nonatomic, strong) id taskIdentifier;
        [Export("taskIdentifier", ArgumentSemantic.Strong)]
        NSObject TaskIdentifier { get; set; }

        // @property (assign, nonatomic) WXResourceType type;
        [Export("type", ArgumentSemantic.Assign)]
        WXResourceType Type { get; set; }

        // @property (nonatomic, strong) NSString * referrer;
        [Export("referrer", ArgumentSemantic.Strong)]
        string Referrer { get; set; }

        // @property (nonatomic, strong) NSString * userAgent;
        [Export("userAgent", ArgumentSemantic.Strong)]
        string UserAgent { get; set; }

        // +(instancetype)requestWithURL:(NSURL *)url resourceType:(WXResourceType)type referrer:(NSString *)referrer cachePolicy:(NSURLRequestCachePolicy)cachePolicy;
        [Static]
        [Export("requestWithURL:resourceType:referrer:cachePolicy:")]
        WXResourceRequest RequestWithURL(NSUrl url, WXResourceType type, string referrer, NSUrlRequestCachePolicy cachePolicy);
    }

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const bundleUrlOptionKey;
        [Field("bundleUrlOptionKey", "__Internal")]
        NSString bundleUrlOptionKey { get; }
    }

    [BaseType(typeof(NSObject))]
    interface WXBridgeMethod
    {

        [Export("instance", ArgumentSemantic.Weak)]
        WXSDKInstance Instance { get; set; }
    }


    // @interface WXSDKInstance : NSObject
    [BaseType(typeof(NSObject))]
    interface WXSDKInstance
    {
        // @property (nonatomic, weak) UIViewController * viewController;
        [Export("viewController", ArgumentSemantic.Weak)]
        UIViewController ViewController { get; set; }

        // @property (nonatomic, strong) UIView * rootView;
        [Export("rootView", ArgumentSemantic.Strong)]
        UIView RootView { get; set; }

        // @property (assign, nonatomic) BOOL isRootViewFrozen;
        [Export("isRootViewFrozen")]
        bool IsRootViewFrozen { get; set; }

        // @property (assign, nonatomic) BOOL needValidate;
        [Export("needValidate")]
        bool NeedValidate { get; set; }

        // @property (nonatomic, strong) NSURL * scriptURL;
        [Export("scriptURL", ArgumentSemantic.Strong)]
        NSUrl ScriptURL { get; set; }

        // @property (nonatomic, weak) WXSDKInstance * parentInstance;
        [Export("parentInstance", ArgumentSemantic.Weak)]
        WXSDKInstance ParentInstance { get; set; }

        // @property (nonatomic, weak) NSString * parentNodeRef;
        [Export("parentNodeRef", ArgumentSemantic.Weak)]
        string ParentNodeRef { get; set; }

        // @property (nonatomic, strong) NSString * instanceId;
        [Export("instanceId", ArgumentSemantic.Strong)]
        string InstanceId { get; set; }

        // @property (assign, nonatomic) BOOL needPrerender;
        [Export("needPrerender")]
        bool NeedPrerender { get; set; }

        // @property (assign, nonatomic) WXState state;
        [Export("state", ArgumentSemantic.Assign)]
        WXState State { get; set; }

        // @property (copy, nonatomic) void (^onCreate)(UIView *);
        [Export("onCreate", ArgumentSemantic.Copy)]
        Action<UIView> OnCreate { get; set; }

        // @property (copy, nonatomic) void (^onLayoutChange)(UIView *);
        [Export("onLayoutChange", ArgumentSemantic.Copy)]
        Action<UIView> OnLayoutChange { get; set; }

        // @property (copy, nonatomic) void (^renderFinish)(UIView *);
        [Export("renderFinish", ArgumentSemantic.Copy)]
        Action<UIView> RenderFinish { get; set; }

        // @property (copy, nonatomic) void (^refreshFinish)(UIView *);
        [Export("refreshFinish", ArgumentSemantic.Copy)]
        Action<UIView> RefreshFinish { get; set; }

        // @property (copy, nonatomic) void (^onFailed)(NSError *);
        [Export("onFailed", ArgumentSemantic.Copy)]
        Action<NSError> OnFailed { get; set; }

        // @property (copy, nonatomic) void (^onScroll)(CGPoint);
        [Export("onScroll", ArgumentSemantic.Copy)]
        Action<CGPoint> OnScroll { get; set; }

        // @property (copy, nonatomic) void (^onRenderProgress)(CGRect);
        [Export("onRenderProgress", ArgumentSemantic.Copy)]
        Action<CGRect> OnRenderProgress { get; set; }

        // @property (copy, nonatomic) void (^onJSDownloadedFinish)(WXResourceResponse *, WXResourceRequest *, NSData *, NSError *);
        [Export("onJSDownloadedFinish", ArgumentSemantic.Copy)]
        Action<WXResourceResponse, WXResourceRequest, NSData, NSError> OnJSDownloadedFinish { get; set; }

        // @property (assign, nonatomic) CGRect frame;
        [Export("frame", ArgumentSemantic.Assign)]
        CGRect Frame { get; set; }

        // @property (nonatomic, strong) NSMutableDictionary * userInfo;
        [Export("userInfo", ArgumentSemantic.Strong)]
        NSMutableDictionary UserInfo { get; set; }

        // @property (readonly, assign, nonatomic) CGFloat pixelScaleFactor;
        [Export("pixelScaleFactor")]
        nfloat PixelScaleFactor { get; }

        // @property (assign, nonatomic) BOOL trackComponent;
        [Export("trackComponent")]
        bool TrackComponent { get; set; }

        // -(void)renderWithURL:(NSURL *)url;
        [Export("renderWithURL:")]
        void RenderWithURL(NSUrl url);

        // -(void)renderWithURL:(NSURL *)url options:(NSDictionary *)options data:(id)data;
        [Export("renderWithURL:options:data:")]
        void RenderWithURL(NSUrl url, NSDictionary options, NSObject data);

        // -(void)renderView:(NSString *)source options:(NSDictionary *)options data:(id)data;
        [Export("renderView:options:data:")]
        void RenderView(string source, NSDictionary options, NSObject data);

        // -(void)reload:(BOOL)forcedReload;
        [Export("reload:")]
        void Reload(bool forcedReload);

        // -(void)refreshInstance:(id)data;
        [Export("refreshInstance:")]
        void RefreshInstance(NSObject data);

        // -(void)destroyInstance;
        [Export("destroyInstance")]
        void DestroyInstance();

        // -(void)forceGarbageCollection;
        [Export("forceGarbageCollection")]
        void ForceGarbageCollection();

        // -(id)moduleForClass:(Class)moduleClass;
        [Export("moduleForClass:")]
        NSObject ModuleForClass(Class moduleClass);

        // -(WXComponent *)componentForRef:(NSString *)ref;
        [Export("componentForRef:")]
        WXComponent ComponentForRef(string @ref);

        // -(NSUInteger)numberOfComponents;
        [Export("numberOfComponents")]
        //[Verify(MethodToProperty)]
        nuint NumberOfComponents { get; }

        // -(BOOL)checkModuleEventRegistered:(NSString *)event moduleClassName:(NSString *)moduleClassName;
        [Export("checkModuleEventRegistered:moduleClassName:")]
        bool CheckModuleEventRegistered(string @event, string moduleClassName);

        // -(void)fireModuleEvent:(Class)module eventName:(NSString *)eventName params:(NSDictionary *)params;
        [Export("fireModuleEvent:eventName:params:")]
        void FireModuleEvent(Class module, string eventName, NSDictionary @params);

        // -(void)fireGlobalEvent:(NSString *)eventName params:(NSDictionary *)params;
        [Export("fireGlobalEvent:params:")]
        void FireGlobalEvent(string eventName, NSDictionary @params);

        // -(NSURL *)completeURL:(NSString *)url;
        [Export("completeURL:")]
        NSUrl CompleteURL(string url);

        // @property (nonatomic, strong) NSString * bizType;
        [Export("bizType", ArgumentSemantic.Strong)]
        string BizType { get; set; }

        // @property (nonatomic, strong) NSString * pageName;
        [Export("pageName", ArgumentSemantic.Strong)]
        string PageName { get; set; }

        // @property (nonatomic, weak) id pageObject;
        [Export("pageObject", ArgumentSemantic.Weak)]
        NSObject PageObject { get; set; }

        // @property (nonatomic, strong) NSMutableDictionary * performanceDict;
        [Export("performanceDict", ArgumentSemantic.Strong)]
        NSMutableDictionary PerformanceDict { get; set; }

        // @property (nonatomic, strong) NSDictionary * properties __attribute__((deprecated("")));
        [Export("properties", ArgumentSemantic.Strong)]
        NSDictionary Properties { get; set; }

        // @property (assign, nonatomic) NSTimeInterval networkTime __attribute__((deprecated("")));
        [Export("networkTime")]
        double NetworkTime { get; set; }

        // @property (copy, nonatomic) void (^updateFinish)(UIView *);
        [Export("updateFinish", ArgumentSemantic.Copy)]
        Action<UIView> UpdateFinish { get; set; }
    }

    // @interface WXValidateResult : NSObject
    [BaseType(typeof(NSObject))]
    interface WXValidateResult
    {
        // @property (assign, nonatomic) BOOL isSuccess;
        [Export("isSuccess")]
        bool IsSuccess { get; set; }

        // @property (nonatomic, strong) NSError * error;
        [Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; set; }
    }

    // @interface WXModuleValidateResult : WXValidateResult
    [BaseType(typeof(WXValidateResult))]
    interface WXModuleValidateResult
    {
    }

    // @interface WXComponentValidateResult : WXValidateResult
    [BaseType(typeof(WXValidateResult))]
    interface WXComponentValidateResult
    {
        // @property (copy, nonatomic) NSString * replacedComponent;
        [Export("replacedComponent")]
        string ReplacedComponent { get; set; }
    }

    // @protocol WXValidateProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXValidateProtocol
    {
        // @required -(BOOL)needValidate:(NSURL *)bundleUrl;
        [Abstract]
        [Export("needValidate:")]
        bool NeedValidate(NSUrl bundleUrl);

        // @required -(WXModuleValidateResult *)validateWithWXSDKInstance:(WXSDKInstance *)wxsdkInstance module:(NSString *)moduel method:(NSString *)method args:(NSArray *)args;
        [Abstract]
        [Export("validateWithWXSDKInstance:module:method:args:")]
        //	[Verify(StronglyTypedNSArray)]
        WXModuleValidateResult ValidateWithWXSDKInstance(WXSDKInstance wxsdkInstance, string moduel, string method, NSObject[] args);

        // @required -(WXComponentValidateResult *)validateWithWXSDKInstance:(WXSDKInstance *)wxsdkInstance component:(NSString *)componentName;
        [Abstract]
        [Export("validateWithWXSDKInstance:component:")]
        WXComponentValidateResult ValidateWithWXSDKInstance(WXSDKInstance wxsdkInstance, string componentName);
    }

    // @protocol WXLogProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXLogProtocol
    {
        // @required -(WXLogLevel)logLevel;
        [Abstract]
        [Export("logLevel")]
        //[Verify(MethodToProperty)]
        WXLogLevel LogLevel { get; }

        // @required -(void)log:(WXLogFlag)flag message:(NSString *)message;
        [Abstract]
        [Export("log:message:")]
        void Message(WXLogFlag flag, string message);
    }

    // @interface WXLog : NSObject
    [BaseType(typeof(NSObject))]
    interface WXLog
    {
        // +(WXLogLevel)logLevel;
        // +(void)setLogLevel:(WXLogLevel)level;
        [Static]
        [Export("logLevel")]
        //[Verify(MethodToProperty)]
        WXLogLevel LogLevel { get; set; }

        // +(NSString *)logLevelString;
        [Static]
        [Export("logLevelString")]
        string LogLevelString();

        // +(void)setLogLevelString:(NSString *)levelString;
        [Static]
        [Export("setLogLevelString:")]
        void SetLogLevelString(string levelString);

        // +(void)log:(WXLogFlag)flag file:(const char *)fileName line:(NSUInteger)line message:(NSString *)message;
        [Static]
        [Export("log:file:line:message:")]
        unsafe void Log(WXLogFlag flag, string fileName, nuint line, string message);

        // +(void)devLog:(WXLogFlag)flag file:(const char *)fileName line:(NSUInteger)line format:(NSString *)format, ... __attribute__((format(NSString, 4, 5)));
        [Static, Internal]
        [Export("devLog:file:line:format:", IsVariadic = true)]
        unsafe void DevLog(WXLogFlag flag, string fileName, nuint line, string format, IntPtr varArgs);

        // +(void)registerExternalLog:(id<WXLogProtocol>)externalLog;
        [Static]
        [Export("registerExternalLog:")]
        void RegisterExternalLog(WXLogProtocol externalLog);
    }

    // @interface WXUtility : NSObject
    [BaseType(typeof(NSObject))]
    interface WXUtility
    {
        // +(void)performBlock:(void (^ _Nonnull)())block onThread:(NSThread * _Nonnull)thread;
        [Static]
        [Export("performBlock:onThread:")]
        void PerformBlock(Action block, NSThread thread);

        // +(BOOL)notStat;
        // +(void)setNotStat:(BOOL)notStat;
        [Static]
        [Export("notStat")]
        //[Verify(MethodToProperty)]
        bool NotStat { get; set; }

        // +(NSDictionary * _Nonnull)getEnvironment;
        [Static]
        [Export("getEnvironment")]
        //[Verify(MethodToProperty)]
        NSDictionary Environment { get; }

        // +(NSDictionary * _Nonnull)getDebugEnvironment;
        [Static]
        [Export("getDebugEnvironment")]
        //[Verify(MethodToProperty)]
        NSDictionary DebugEnvironment { get; }

        // +(NSString * _Nonnull)userAgent;
        [Static]
        [Export("userAgent")]
        //[Verify(MethodToProperty)]
        string UserAgent { get; }

        // +(id _Nullable)objectFromJSON:(NSString * _Nonnull)json;
        [Static]
        [Export("objectFromJSON:")]
        [return: NullAllowed]
        NSObject ObjectFromJSON(string json);

        // +(NSString * _Nullable)JSONString:(id _Nonnull)object;
        [Static]
        [Export("JSONString:")]
        [return: NullAllowed]
        string JSONString(NSObject @object);

        // +(id _Nullable)JSONObject:(NSData * _Nonnull)data error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("JSONObject:error:")]
        [return: NullAllowed]
        NSObject JSONObject(NSData data, [NullAllowed] out NSError error);

        // +(id _Nullable)copyJSONObject:(id _Nonnull)object;
        [Static]
        [Export("copyJSONObject:")]
        [return: NullAllowed]
        NSObject CopyJSONObject(NSObject @object);

        // +(BOOL)isBlankString:(NSString * _Nullable)string;
        [Static]
        [Export("isBlankString:")]
        bool IsBlankString([NullAllowed] string @string);

        // +(NSError * _Nonnull)errorWithCode:(NSInteger)code message:(NSString * _Nullable)message;
        [Static]
        [Export("errorWithCode:message:")]
        NSError ErrorWithCode(nint code, [NullAllowed] string message);

        // +(UIFont * _Nonnull)fontWithSize:(CGFloat)size textWeight:(CGFloat)textWeight textStyle:(WXTextStyle)textStyle fontFamily:(NSString * _Nullable)fontFamily scaleFactor:(CGFloat)scaleFactor;
        [Static]
        [Export("fontWithSize:textWeight:textStyle:fontFamily:scaleFactor:")]
        UIFont FontWithSize(nfloat size, nfloat textWeight, WXTextStyle textStyle, [NullAllowed] string fontFamily, nfloat scaleFactor);

        // +(UIFont * _Nonnull)fontWithSize:(CGFloat)size textWeight:(CGFloat)textWeight textStyle:(WXTextStyle)textStyle fontFamily:(NSString * _Nullable)fontFamily scaleFactor:(CGFloat)scaleFactor useCoreText:(BOOL)useCoreText;
        [Static]
        [Export("fontWithSize:textWeight:textStyle:fontFamily:scaleFactor:useCoreText:")]
        UIFont FontWithSize(nfloat size, nfloat textWeight, WXTextStyle textStyle, [NullAllowed] string fontFamily, nfloat scaleFactor, bool useCoreText);

        // +(void)getIconfont:(NSURL * _Nonnull)fontURL completion:(void (^ _Nullable)(NSURL * _Nonnull, NSError * _Nullable))completionBlock;
        [Static]
        [Export("getIconfont:completion:")]
        void GetIconfont(NSUrl fontURL, [NullAllowed] Action<NSUrl, NSError> completionBlock);

        // +(CGSize)portraitScreenSize;
        [Static]
        [Export("portraitScreenSize")]
        //[Verify(MethodToProperty)]
        CGSize PortraitScreenSize { get; }

        // +(CGFloat)defaultPixelScaleFactor;
        [Static]
        [Export("defaultPixelScaleFactor")]
        //[Verify(MethodToProperty)]
        nfloat DefaultPixelScaleFactor { get; }

        // +(BOOL)isFileExist:(NSString * _Nonnull)filePath;
        [Static]
        [Export("isFileExist:")]
        bool IsFileExist(string filePath);

        // +(NSString * _Nonnull)documentDirectory;
        [Static]
        [Export("documentDirectory")]
        //[Verify(MethodToProperty)]
        string DocumentDirectory { get; }

        // +(NSString * _Nonnull)cacheDirectory;
        [Static]
        [Export("cacheDirectory")]
        //[Verify(MethodToProperty)]
        string CacheDirectory { get; }

        // +(NSString * _Nonnull)libraryDirectory;
        [Static]
        [Export("libraryDirectory")]
        //[Verify(MethodToProperty)]
        string LibraryDirectory { get; }

        // +(NSCache * _Nonnull)globalCache;
        [Static]
        [Export("globalCache")]
        //[Verify(MethodToProperty)]
        NSCache GlobalCache { get; }

        // +(NSURL * _Nonnull)urlByDeletingParameters:(NSURL * _Nonnull)url;
        [Static]
        [Export("urlByDeletingParameters:")]
        NSUrl UrlByDeletingParameters(NSUrl url);

        // +(NSString * _Nullable)stringWithContentsOfFile:(NSString * _Nonnull)filePath;
        [Static]
        [Export("stringWithContentsOfFile:")]
        [return: NullAllowed]
        string StringWithContentsOfFile(string filePath);

        // +(NSString * _Nullable)md5:(NSString * _Nullable)string;
        [Static]
        [Export("md5:")]
        [return: NullAllowed]
        string Md5([NullAllowed] string @string);

        // +(NSString * _Nullable)uuidString;
        [Static]
        [NullAllowed, Export("uuidString")]
        //[Verify(MethodToProperty)]
        string UuidString { get; }

        // +(NSDate * _Nullable)dateStringToDate:(NSString * _Nullable)dateString;
        [Static]
        [Export("dateStringToDate:")]
        [return: NullAllowed]
        NSDate DateStringToDate([NullAllowed] string dateString);

        // +(NSDate * _Nullable)timeStringToDate:(NSString * _Nullable)timeString;
        [Static]
        [Export("timeStringToDate:")]
        [return: NullAllowed]
        NSDate TimeStringToDate([NullAllowed] string timeString);

        // +(NSString * _Nullable)dateToString:(NSDate * _Nullable)date;
        [Static]
        [Export("dateToString:")]
        [return: NullAllowed]
        string DateToString([NullAllowed] NSDate date);

        // +(NSString * _Nullable)timeToString:(NSDate * _Nullable)date;
        [Static]
        [Export("timeToString:")]
        [return: NullAllowed]
        string TimeToString([NullAllowed] NSDate date);

        // +(NSUInteger)getSubStringNumber:(NSString * _Nullable)string subString:(NSString * _Nullable)subString;
        [Static]
        [Export("getSubStringNumber:subString:")]
        nuint GetSubStringNumber([NullAllowed] string @string, [NullAllowed] string subString);

        // +(UIFont * _Nullable)fontWithSize:(CGFloat)size textWeight:(CGFloat)textWeight textStyle:(WXTextStyle)textStyle fontFamily:(NSString * _Nullable)fontFamily __attribute__((deprecated("Use +[WXUtility fontWithSize:textWeight:textStyle:fontFamily:scaleFactor:]")));
        [Static]
        [Export("fontWithSize:textWeight:textStyle:fontFamily:")]
        [return: NullAllowed]
        UIFont FontWithSize(nfloat size, nfloat textWeight, WXTextStyle textStyle, [NullAllowed] string fontFamily);

        // +(CAGradientLayer * _Nullable)gradientLayerFromColors:(NSArray * _Nullable)colors locations:(NSArray * _Nullable)locations frame:(CGRect)frame gradientType:(WXGradientType)gradientType;
        [Static]
        [Export("gradientLayerFromColors:locations:frame:gradientType:")]
        //[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        [return: NullAllowed]
        CAGradientLayer GradientLayerFromColors([NullAllowed] NSObject[] colors, [NullAllowed] NSObject[] locations, CGRect frame, WXGradientType gradientType);

        // +(NSDictionary * _Nullable)linearGradientWithBackgroundImage:(NSString * _Nullable)backgroundImage;
        [Static]
        [Export("linearGradientWithBackgroundImage:")]
        [return: NullAllowed]
        NSDictionary LinearGradientWithBackgroundImage([NullAllowed] string backgroundImage);

        // +(NSString * _Nullable)returnKeyType:(UIReturnKeyType)type;
        [Static]
        [Export("returnKeyType:")]
        [return: NullAllowed]
        string ReturnKeyType(UIReturnKeyType type);

        // +(void)customMonitorInfo:(WXSDKInstance * _Nullable)instance key:(NSString * _Nonnull)key value:(id _Nonnull)value;
        [Static]
        [Export("customMonitorInfo:key:value:")]
        void CustomMonitorInfo([NullAllowed] WXSDKInstance instance, string key, NSObject value);
    }

    // @protocol WXURLRewriteProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXURLRewriteProtocol
    {
        // @required -(NSURL *)rewriteURL:(NSString *)url withResourceType:(WXResourceType)resourceType withInstance:(WXSDKInstance *)instance;
        [Abstract]
        [Export("rewriteURL:withResourceType:withInstance:")]
        NSUrl WithResourceType(string url, WXResourceType resourceType, WXSDKInstance instance);
    }

    // @protocol WXScrollerProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXScrollerProtocol
    {
        // @required -(void)addStickyComponent:(WXComponent *)sticky;
        [Abstract]
        [Export("addStickyComponent:")]
        void AddStickyComponent(WXComponent sticky);

        // @required -(void)removeStickyComponent:(WXComponent *)sticky;
        [Abstract]
        [Export("removeStickyComponent:")]
        void RemoveStickyComponent(WXComponent sticky);

        // @required -(void)adjustSticky;
        [Abstract]
        [Export("adjustSticky")]
        void AdjustSticky();

        // @required -(void)addScrollToListener:(WXComponent *)target;
        [Abstract]
        [Export("addScrollToListener:")]
        void AddScrollToListener(WXComponent target);

        // @required -(void)removeScrollToListener:(WXComponent *)target;
        [Abstract]
        [Export("removeScrollToListener:")]
        void RemoveScrollToListener(WXComponent target);

        // @required -(void)scrollToComponent:(WXComponent *)component withOffset:(CGFloat)offset animated:(BOOL)animated;
        [Abstract]
        [Export("scrollToComponent:withOffset:animated:")]
        void ScrollToComponent(WXComponent component, nfloat offset, bool animated);

        // @required -(BOOL)isNeedLoadMore;
        [Abstract]
        [Export("isNeedLoadMore")]
        //[Verify(MethodToProperty)]
        bool IsNeedLoadMore { get; }

        // @required -(void)loadMore;
        [Abstract]
        [Export("loadMore")]
        void LoadMore();

        // @required -(CGPoint)contentOffset;
        [Abstract]
        [Export("contentOffset")]
        //[Verify(MethodToProperty)]
        CGPoint ContentOffset { get; }

        // @required -(void)setContentOffset:(CGPoint)contentOffset animated:(BOOL)animated;
        [Abstract]
        [Export("setContentOffset:animated:")]
        void SetContentOffset(CGPoint contentOffset, bool animated);

        // @required -(CGSize)contentSize;
        // @required -(void)setContentSize:(CGSize)size;
        [Abstract]
        [Export("contentSize")]
        //[Verify(MethodToProperty)]
        CGSize ContentSize { get; set; }

        // @required -(UIEdgeInsets)contentInset;
        [Abstract]
        [Export("contentInset")]
        UIEdgeInsets ContentInset();

        // @required -(void)setContentInset:(UIEdgeInsets)contentInset;
        [Abstract]
        [Export("setContentInset:")]
        void SetContentInset(UIEdgeInsets contentInset);

        // @required -(void)resetLoadmore;
        [Abstract]
        [Export("resetLoadmore")]
        void ResetLoadmore();

        // @required -(void)addScrollDelegate:(id<UIScrollViewDelegate>)delegate;
        [Abstract]
        [Export("addScrollDelegate:")]
        void AddScrollDelegate(UIScrollViewDelegate @delegate);

        // @required -(void)removeScrollDelegate:(id<UIScrollViewDelegate>)delegate;
        [Abstract]
        [Export("removeScrollDelegate:")]
        void RemoveScrollDelegate(UIScrollViewDelegate @delegate);

        // @required -(WXScrollDirection)scrollDirection;
        [Abstract]
        [Export("scrollDirection")]
        WXScrollDirection ScrollDirection();
    }

    // @interface WXScrollerComponent : WXComponent <WXScrollerProtocol, UIScrollViewDelegate>
    [BaseType(typeof(WXComponent))]
    interface WXScrollerComponent : WXScrollerProtocol, IUIScrollViewDelegate
    {
        // @property (copy, nonatomic) void (^onScroll)(UIScrollView *);
        [Export("onScroll", ArgumentSemantic.Copy)]
        Action<UIScrollView> OnScroll { get; set; }

        // @property (assign, nonatomic) NSUInteger loadmoreretry;
        [Export("loadmoreretry")]
        nuint Loadmoreretry { get; set; }

        // @property (assign, nonatomic) CGSize contentSize;
        [Export("contentSize", ArgumentSemantic.Assign)]
        CGSize ContentSize { get; set; }

        // @property (readonly, assign, nonatomic) wx_css_node_t * scrollerCSSNode;
        [Export("scrollerCSSNode", ArgumentSemantic.Assign)]
        unsafe wx_css_node_t ScrollerCSSNode { get; }

        // -(NSUInteger)childrenCountForScrollerLayout;
        [Export("childrenCountForScrollerLayout")]
        //	[Verify(MethodToProperty)]
        nuint ChildrenCountForScrollerLayout { get; }

        // -(void)handleAppear;
        [Export("handleAppear")]
        void HandleAppear();
    }

    // @interface WXBridgeManager : NSObject
    [BaseType(typeof(NSObject))]
    interface WXBridgeManager
    {
        // @property (readonly, nonatomic, weak) WXSDKInstance * topInstance;
        [Export("topInstance", ArgumentSemantic.Weak)]
        WXSDKInstance TopInstance { get; }

        // -(void)createInstance:(NSString *)instance template:(NSString *)temp options:(NSDictionary *)options data:(id)data;
        [Export("createInstance:template:options:data:")]
        void CreateInstance(string instance, string temp, NSDictionary options, NSObject data);

        // -(NSArray *)getInstanceIdStack;
        [Export("getInstanceIdStack")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] InstanceIdStack { get; }

        // -(void)destroyInstance:(NSString *)instance;
        [Export("destroyInstance:")]
        void DestroyInstance(string instance);

        // -(void)forceGarbageCollection;
        [Export("forceGarbageCollection")]
        void ForceGarbageCollection();

        // -(void)refreshInstance:(NSString *)instance data:(id)data;
        [Export("refreshInstance:data:")]
        void RefreshInstance(string instance, NSObject data);

        // -(void)unload;
        [Export("unload")]
        void Unload();

        // -(void)updateState:(NSString *)instance data:(id)data;
        [Export("updateState:data:")]
        void UpdateState(string instance, NSObject data);

        // -(void)executeJsFramework:(NSString *)script;
        [Export("executeJsFramework:")]
        void ExecuteJsFramework(string script);

        // -(void)registerService:(NSString *)name withService:(NSString *)serviceScript withOptions:(NSDictionary *)options;
        [Export("registerService:withService:withOptions:")]
        void RegisterService(string name, string serviceScript, NSDictionary options);

        // -(void)registerService:(NSString *)name withServiceUrl:(NSURL *)serviceScriptUrl withOptions:(NSDictionary *)options;
        [Export("registerService:withServiceUrl:withOptions:")]
        void RegisterService(string name, NSUrl serviceScriptUrl, NSDictionary options);

        // -(void)unregisterService:(NSString *)name;
        [Export("unregisterService:")]
        void UnregisterService(string name);

        // -(void)registerModules:(NSDictionary *)modules;
        [Export("registerModules:")]
        void RegisterModules(NSDictionary modules);

        // -(void)registerComponents:(NSArray *)components;
        [Export("registerComponents:")]
        //[Verify(StronglyTypedNSArray)]
        void RegisterComponents(NSObject[] components);

        // -(void)fireEvent:(NSString *)instanceId ref:(NSString *)ref type:(NSString *)type params:(NSDictionary *)params domChanges:(NSDictionary *)domChanges;
        [Export("fireEvent:ref:type:params:domChanges:")]
        void FireEvent(string instanceId, string @ref, string type, NSDictionary @params, NSDictionary domChanges);

        // -(void)callBack:(NSString *)instanceId funcId:(NSString *)funcId params:(id)params keepAlive:(BOOL)keepAlive;
        [Export("callBack:funcId:params:keepAlive:")]
        void CallBack(string instanceId, string funcId, NSObject @params, bool keepAlive);

        // -(void)connectToDevToolWithUrl:(NSURL *)url;
        [Export("connectToDevToolWithUrl:")]
        void ConnectToDevToolWithUrl(NSUrl url);

        // -(void)callBack:(NSString *)instanceId funcId:(NSString *)funcId params:(id)params;
        [Export("callBack:funcId:params:")]
        void CallBack(string instanceId, string funcId, NSObject @params);

        // -(void)connectToWebSocket:(NSURL *)url;
        [Export("connectToWebSocket:")]
        void ConnectToWebSocket(NSUrl url);

        // -(void)logToWebSocket:(NSString *)flag message:(NSString *)message;
        [Export("logToWebSocket:message:")]
        void LogToWebSocket(string flag, string message);

        // -(void)resetEnvironment;
        [Export("resetEnvironment")]
        void ResetEnvironment();

        // -(void)fireEvent:(NSString *)instanceId ref:(NSString *)ref type:(NSString *)type params:(NSDictionary *)params __attribute__((deprecated("Use fireEvent:ref:type:params:domChanges: method instead.")));
        [Export("fireEvent:ref:type:params:")]
        void FireEvent(string instanceId, string @ref, string type, NSDictionary @params);

        // -(void)executeJsMethod:(WXBridgeMethod *)method __attribute__((deprecated("")));
        [Export("executeJsMethod:")]
        void ExecuteJsMethod(WXBridgeMethod method);
    }

    // @interface WXSDKManager : NSObject
    [BaseType(typeof(NSObject))]
    interface WXSDKManager
    {
        // +(WXBridgeManager *)bridgeMgr;
        [Static]
        [Export("bridgeMgr")]
        //	[Verify(MethodToProperty)]
        WXBridgeManager BridgeMgr { get; }

        // +(WXSDKInstance *)instanceForID:(NSString *)identifier;
        [Static]
        [Export("instanceForID:")]
        WXSDKInstance InstanceForID(string identifier);

        // +(void)storeInstance:(WXSDKInstance *)instance forID:(NSString *)identifier;
        [Static]
        [Export("storeInstance:forID:")]
        void StoreInstance(WXSDKInstance instance, string identifier);

        // +(void)removeInstanceforID:(NSString *)identifier;
        [Static]
        [Export("removeInstanceforID:")]
        void RemoveInstanceforID(string identifier);

        // +(void)unload;
        [Static]
        [Export("unload")]
        void Unload();

        // +(WXModuleManager *)moduleMgr __attribute__((deprecated("")));
        //[Static]
        //	[Export("moduleMgr")]
        //[Verify(MethodToProperty)]
        //  WXModuleManager ModuleMgr { get; }
    }

    // @interface WXSDKEngine : NSObject
    [BaseType(typeof(NSObject))]
    interface WXSDKEngine
    {
        // +(void)registerDefaults;
        [Static]
        [Export("registerDefaults")]
        void RegisterDefaults();

        // +(void)registerModule:(NSString *)name withClass:(Class)clazz;
        [Static]
        [Export("registerModule:withClass:")]
        void RegisterModule(string name, Class clazz);

        // +(void)registerComponent:(NSString *)name withClass:(Class)clazz;
        [Static]
        [Export("registerComponent:withClass:")]
        void RegisterComponent(string name, Class clazz);

        // +(void)registerComponent:(NSString *)name withClass:(Class)clazz withProperties:(NSDictionary *)properties;
        [Static]
        [Export("registerComponent:withClass:withProperties:")]
        void RegisterComponent(string name, Class clazz, NSDictionary properties);

        // +(void)registerService:(NSString *)name withScript:(NSString *)serviceScript withOptions:(NSDictionary *)options;
        [Static]
        [Export("registerService:withScript:withOptions:")]
        void RegisterService(string name, string serviceScript, NSDictionary options);

        // +(void)registerService:(NSString *)name withScriptUrl:(NSURL *)serviceScriptUrl WithOptions:(NSDictionary *)options;
        [Static]
        [Export("registerService:withScriptUrl:WithOptions:")]
        void RegisterService(string name, NSUrl serviceScriptUrl, NSDictionary options);

        // +(void)unregisterService:(NSString *)name;
        [Static]
        [Export("unregisterService:")]
        void UnregisterService(string name);

        // +(void)registerHandler:(id)handler withProtocol:(Protocol *)protocol;
        [Static]
        [Export("registerHandler:withProtocol:")]
        void RegisterHandler(NSObject handler, Protocol protocol);

        // +(id)handlerForProtocol:(Protocol *)protocol;
        [Static]
        [Export("handlerForProtocol:")]
        NSObject HandlerForProtocol(Protocol protocol);

        // +(void)initSDKEnvironment;
        [Static]
        [Export("initSDKEnvironment")]
        void InitSDKEnvironment();

        // +(void)initSDKEnvironment:(NSString *)script;
        [Static]
        [Export("initSDKEnvironment:")]
        void InitSDKEnvironment(string script);

        // +(void)unload;
        [Static]
        [Export("unload")]
        void Unload();

        // +(void)restart;
        [Static]
        [Export("restart")]
        void Restart();

        // +(void)restartWithScript:(NSString *)script;
        [Static]
        [Export("restartWithScript:")]
        void RestartWithScript(string script);

        // +(NSString *)SDKEngineVersion;
        [Static]
        [Export("SDKEngineVersion")]
        //[Verify(MethodToProperty)]
        string SDKEngineVersion { get; }

        // +(WXSDKInstance *)topInstance;
        [Static]
        [Export("topInstance")]
        //[Verify(MethodToProperty)]
        WXSDKInstance TopInstance { get; }

        // +(NSDictionary *)customEnvironment;
        // +(void)setCustomEnvironment:(NSDictionary *)environment;
        [Static]
        [Export("customEnvironment")]
        //[Verify(MethodToProperty)]
        NSDictionary CustomEnvironment { get; set; }

        // +(void)connectDebugServer:(NSString *)URL;
        [Static]
        [Export("connectDebugServer:")]
        void ConnectDebugServer(string URL);

        // +(void)connectDevToolServer:(NSString *)URL;
        [Static]
        [Export("connectDevToolServer:")]
        void ConnectDevToolServer(string URL);
    }

    // @interface WXRootViewController : UINavigationController
    [BaseType(typeof(UINavigationController))]
    interface WXRootViewController
    {
        // -(id)initWithSourceURL:(NSURL *)sourceURL;
        [Export("initWithSourceURL:")]
        IntPtr Constructor(NSUrl sourceURL);
    }

    // @protocol WXResourceRequestDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXResourceRequestDelegate
    {
        // @required -(void)request:(WXResourceRequest *)request didSendData:(unsigned long long)bytesSent totalBytesToBeSent:(unsigned long long)totalBytesToBeSent;
        [Abstract]
        [Export("request:didSendData:totalBytesToBeSent:")]
        void Request(WXResourceRequest request, ulong bytesSent, ulong totalBytesToBeSent);

        // @required -(void)request:(WXResourceRequest *)request didReceiveResponse:(WXResourceResponse *)response;
        [Abstract]
        [Export("request:didReceiveResponse:")]
        void Request(WXResourceRequest request, WXResourceResponse response);

        // @required -(void)request:(WXResourceRequest *)request didReceiveData:(NSData *)data;
        [Abstract]
        [Export("request:didReceiveData:")]
        void Request(WXResourceRequest request, NSData data);

        // @required -(void)requestDidFinishLoading:(WXResourceRequest *)request;
        [Abstract]
        [Export("requestDidFinishLoading:")]
        void RequestDidFinishLoading(WXResourceRequest request);

        // @required -(void)request:(WXResourceRequest *)request didFailWithError:(NSError *)error;
        [Abstract]
        [Export("request:didFailWithError:")]
        void Request(WXResourceRequest request, NSError error);

        // @required -(void)request:(WXResourceRequest *)request didFinishCollectingMetrics:(NSURLSessionTaskMetrics *)metrics __attribute__((availability(tvos, introduced=10.0))) __attribute__((availability(watchos, introduced=3.0))) __attribute__((availability(ios, introduced=10.0))) __attribute__((availability(macos, introduced=10.12)));
        //[Watch(3, 0), TV(10, 0), Mac(10, 12), iOS(10, 0)]
        [Abstract]
        [Export("request:didFinishCollectingMetrics:")]
        void Request(WXResourceRequest request, NSUrlSessionTaskMetrics metrics);
    }

    // @protocol WXResourceRequestHandler <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXResourceRequestHandler
    {
        // @required -(void)sendRequest:(WXResourceRequest *)request withDelegate:(id<WXResourceRequestDelegate>)delegate;
        [Abstract]
        [Export("sendRequest:withDelegate:")]
        void SendRequest(WXResourceRequest request, WXResourceRequestDelegate @delegate);

        // @optional -(void)cancelRequest:(WXResourceRequest *)request;
        [Export("cancelRequest:")]
        void CancelRequest(WXResourceRequest request);
    }

    // @protocol WXModuleProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXModuleProtocol
    {
        // @optional -(dispatch_queue_t)targetExecuteQueue;
        [Export("targetExecuteQueue")]
        //[Verify(MethodToProperty)]
        DispatchQueue TargetExecuteQueue { get; }

        // @optional -(NSThread *)targetExecuteThread;
        [Export("targetExecuteThread")]
        //[Verify(MethodToProperty)]
        NSThread TargetExecuteThread { get; }

        // @optional @property (nonatomic, weak) WXSDKInstance * weexInstance;
        [Export("weexInstance", ArgumentSemantic.Weak)]
        WXSDKInstance WeexInstance { get; set; }
    }

    // typedef void (^WXModuleCallback)(id);
    delegate void WXModuleCallback(NSObject arg0);

    // typedef void (^WXModuleKeepAliveCallback)(id, BOOL);
    delegate void WXModuleKeepAliveCallback(NSObject arg0, bool arg1);

    // @interface WXPrerenderManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface WXPrerenderManager
    {
        // +(void)addTask:(NSString *)url instanceId:(NSString *)instanceId callback:(WXModuleCallback)callback;
        [Static]
        [Export("addTask:instanceId:callback:")]
        void AddTask(string url, string instanceId, WXModuleCallback callback);

        // +(BOOL)isTaskExist:(NSString *)url;
        [Static]
        [Export("isTaskExist:")]
        bool IsTaskExist(string url);

        // +(NSError *)errorFromUrl:(NSString *)url;
        [Static]
        [Export("errorFromUrl:")]
        NSError ErrorFromUrl(string url);

        // +(void)renderFromCache:(NSString *)url;
        [Static]
        [Export("renderFromCache:")]
        void RenderFromCache(string url);

        // +(UIView *)viewFromUrl:(NSString *)url;
        [Static]
        [Export("viewFromUrl:")]
        UIView ViewFromUrl(string url);

        // +(id)instanceFromUrl:(NSString *)url;
        [Static]
        [Export("instanceFromUrl:")]
        NSObject InstanceFromUrl(string url);

        // +(void)removePrerenderTaskforUrl:(NSString *)url;
        [Static]
        [Export("removePrerenderTaskforUrl:")]
        void RemovePrerenderTaskforUrl(string url);

        // +(void)storePrerenderModuleTasks:(WXModuleMethod *)prerenderModuleTask forUrl:(NSString *)url;
        //	[Static]
        //[Export("storePrerenderModuleTasks:forUrl:")]
        //void StorePrerenderModuleTasks(WXModuleMethod prerenderModuleTask, string url);

        // +(void)destroyTask:(NSString *)parentInstanceId;
        [Static]
        [Export("destroyTask:")]
        void DestroyTask(string parentInstanceId);
    }

    // @protocol WXNetworkProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXNetworkProtocol
    {
        // @required -(id)sendRequest:(NSURLRequest *)request withSendingData:(void (^)(int64_t, int64_t))sendDataCallback withResponse:(void (^)(NSURLResponse *))responseCallback withReceiveData:(void (^)(NSData *))receiveDataCallback withCompeletion:(void (^)(NSData *, NSError *))completionCallback;
        [Abstract]
        [Export("sendRequest:withSendingData:withResponse:withReceiveData:withCompeletion:")]
        NSObject WithSendingData(NSUrlRequest request, Action<long, long> sendDataCallback, Action<NSUrlResponse> responseCallback, Action<NSData> receiveDataCallback, Action<NSData, NSError> completionCallback);
    }

    // typedef void (^WXNavigationResultBlock)(NSString *, NSDictionary *);
    delegate void WXNavigationResultBlock(string arg0, NSDictionary arg1);

    // @protocol WXNavigationProtocol <WXModuleProtocol>
    [Protocol, Model]
    interface WXNavigationProtocol : WXModuleProtocol
    {
        // @required -(id)navigationControllerOfContainer:(UIViewController *)container;
        [Abstract]
        [Export("navigationControllerOfContainer:")]
        NSObject NavigationControllerOfContainer(UIViewController container);

        // @required -(void)setNavigationBarHidden:(BOOL)hidden animated:(BOOL)animated withContainer:(UIViewController *)container;
        [Abstract]
        [Export("setNavigationBarHidden:animated:withContainer:")]
        void SetNavigationBarHidden(bool hidden, bool animated, UIViewController container);

        // @required -(void)setNavigationBackgroundColor:(UIColor *)backgroundColor withContainer:(UIViewController *)container;
        [Abstract]
        [Export("setNavigationBackgroundColor:withContainer:")]
        void SetNavigationBackgroundColor(UIColor backgroundColor, UIViewController container);

        // @required -(void)setNavigationItemWithParam:(NSDictionary *)param position:(WXNavigationItemPosition)position completion:(WXNavigationResultBlock)block withContainer:(UIViewController *)container;
        [Abstract]
        [Export("setNavigationItemWithParam:position:completion:withContainer:")]
        void SetNavigationItemWithParam(NSDictionary param, WXNavigationItemPosition position, WXNavigationResultBlock block, UIViewController container);

        // @required -(void)clearNavigationItemWithParam:(NSDictionary *)param position:(WXNavigationItemPosition)position completion:(WXNavigationResultBlock)block withContainer:(UIViewController *)container;
        [Abstract]
        [Export("clearNavigationItemWithParam:position:completion:withContainer:")]
        void ClearNavigationItemWithParam(NSDictionary param, WXNavigationItemPosition position, WXNavigationResultBlock block, UIViewController container);

        // @required -(void)pushViewControllerWithParam:(NSDictionary *)param completion:(WXNavigationResultBlock)block withContainer:(UIViewController *)container;
        [Abstract]
        [Export("pushViewControllerWithParam:completion:withContainer:")]
        void PushViewControllerWithParam(NSDictionary param, WXNavigationResultBlock block, UIViewController container);

        // @required -(void)popViewControllerWithParam:(NSDictionary *)param completion:(WXNavigationResultBlock)block withContainer:(UIViewController *)container;
        [Abstract]
        [Export("popViewControllerWithParam:completion:withContainer:")]
        void PopViewControllerWithParam(NSDictionary param, WXNavigationResultBlock block, UIViewController container);

        // @optional -(void)open:(NSDictionary *)param success:(WXModuleCallback)success failure:(WXModuleCallback)failure withContainer:(UIViewController *)container;
        [Export("open:success:failure:withContainer:")]
        void Open(NSDictionary param, WXModuleCallback success, WXModuleCallback failure, UIViewController container);

        // @optional -(void)close:(NSDictionary *)param success:(WXModuleCallback)success failure:(WXModuleCallback)failure withContainer:(UIViewController *)container;
        [Export("close:success:failure:withContainer:")]
        void Close(NSDictionary param, WXModuleCallback success, WXModuleCallback failure, UIViewController container);
    }

    //// @interface WXMonitor : NSObject
    //[BaseType(typeof(NSObject))]
    //interface WXMonitor
    //{
    //	// +(void)performancePoint:(WXPerformanceTag)tag willStartWithInstance:(WXSDKInstance *)instance;
    //	[Static]
    //	[Export("performancePoint:willStartWithInstance:")]
    //	void PerformancePoint(WXPerformanceTag tag, WXSDKInstance instance);

    //	// +(void)performancePoint:(WXPerformanceTag)tag didEndWithInstance:(WXSDKInstance *)instance;
    //	[Static]
    //	[Export("performancePoint:didEndWithInstance:")]
    //	void PerformancePoint(WXPerformanceTag tag, WXSDKInstance instance);

    //	// +(void)performancePoint:(WXPerformanceTag)tag didSetValue:(double)value withInstance:(WXSDKInstance *)instance;
    //	[Static]
    //	[Export("performancePoint:didSetValue:withInstance:")]
    //	void PerformancePoint(WXPerformanceTag tag, double value, WXSDKInstance instance);

    //	// +(BOOL)performancePoint:(WXPerformanceTag)tag isRecordedWithInstance:(WXSDKInstance *)instance;
    //	[Static]
    //	[Export("performancePoint:isRecordedWithInstance:")]
    //	bool PerformancePoint(WXPerformanceTag tag, WXSDKInstance instance);

    //	// +(void)monitoringPointDidSuccess:(WXMonitorTag)tag onPage:(NSString *)pageName;
    //	[Static]
    //	[Export("monitoringPointDidSuccess:onPage:")]
    //	void MonitoringPointDidSuccess(WXMonitorTag tag, string pageName);

    //	// +(void)monitoringPoint:(WXMonitorTag)tag didFailWithError:(NSError *)error onPage:(NSString *)pageName;
    //	[Static]
    //	[Export("monitoringPoint:didFailWithError:onPage:")]
    //	void MonitoringPoint(WXMonitorTag tag, NSError error, string pageName);
    //}

    // @interface WXModalUIModule : NSObject <WXModuleProtocol>
    [BaseType(typeof(NSObject))]
    interface WXModalUIModule : WXModuleProtocol
    {
    }

    // @interface WXListComponent : WXScrollerComponent
    [BaseType(typeof(WXScrollerComponent))]
    interface WXListComponent
    {
    }

    // @protocol WXJSExceptionProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXJSExceptionProtocol
    {
        // @required -(void)onJSException:(WXJSExceptionInfo *)exception;
        [Abstract]
        [Export("onJSException:")]
        void OnJSException(WXJSExceptionInfo exception);
    }

    // @interface WXIndicatorView : UIView
    [BaseType(typeof(UIView))]
    interface WXIndicatorView
    {
        // @property (assign, nonatomic) NSInteger pointCount;
        [Export("pointCount")]
        nint PointCount { get; set; }

        // @property (assign, nonatomic) NSInteger currentPoint;
        [Export("currentPoint")]
        nint CurrentPoint { get; set; }

        // @property (nonatomic, strong) UIColor * pointColor;
        [Export("pointColor", ArgumentSemantic.Strong)]
        UIColor PointColor { get; set; }

        // @property (nonatomic, strong) UIColor * lightColor;
        [Export("lightColor", ArgumentSemantic.Strong)]
        UIColor LightColor { get; set; }

        // @property (assign, nonatomic) WXPointIndicatorAlignStyle alignStyle;
        [Export("alignStyle", ArgumentSemantic.Assign)]
        WXPointIndicatorAlignStyle AlignStyle { get; set; }

        // @property (assign, nonatomic) CGFloat pointSize;
        [Export("pointSize")]
        nfloat PointSize { get; set; }

        // @property (assign, nonatomic) CGFloat pointSpace;
        [Export("pointSpace")]
        nfloat PointSpace { get; set; }
    }

    // @protocol WXIndicatorComponentDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXIndicatorComponentDelegate
    {
        // @required -(void)setIndicatorView:(WXIndicatorView *)indicatorView;
        [Abstract]
        [Export("setIndicatorView:")]
        void SetIndicatorView(WXIndicatorView indicatorView);
    }

    // @interface WXIndicatorComponent : WXComponent
    [BaseType(typeof(WXComponent))]
    interface WXIndicatorComponent
    {
        [Wrap("WeakDelegate")]
        WXIndicatorComponentDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<WXIndicatorComponentDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol WXImageOperationProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXImageOperationProtocol
    {
        // @required -(void)cancel;
        [Abstract]
        [Export("cancel")]
        void Cancel();
    }

    // @protocol WXImgLoaderProtocol <WXModuleProtocol>
    [Protocol, Model]
    interface WXImgLoaderProtocol : WXModuleProtocol
    {
        // @required -(id<WXImageOperationProtocol>)downloadImageWithURL:(NSString *)url imageFrame:(CGRect)imageFrame userInfo:(NSDictionary *)options completed:(void (^)(UIImage *, NSError *, BOOL))completedBlock;
        [Abstract]
        [Export("downloadImageWithURL:imageFrame:userInfo:completed:")]
        WXImageOperationProtocol ImageFrame(string url, CGRect imageFrame, NSDictionary options, Action<UIImage, NSError, bool> completedBlock);
    }

    // @protocol WXEventModuleProtocol <WXModuleProtocol>
    [Protocol, Model]
    interface WXEventModuleProtocol : WXModuleProtocol
    {
        // @required -(void)openURL:(NSString *)url;
        [Abstract]
        [Export("openURL:")]
        void OpenURL(string url);
    }

    // @protocol WXErrorViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXErrorViewDelegate
    {
        // @required -(void)onclickErrorView;
        [Abstract]
        [Export("onclickErrorView")]
        void OnclickErrorView();
    }

    // @interface WXErrorView : UIView
    [BaseType(typeof(UIView))]
    interface WXErrorView
    {
        [Wrap("WeakDelegate")]
        WXErrorViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<WXErrorViewDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @interface WXDebugTool : NSObject <WXModuleProtocol>
    [BaseType(typeof(NSObject))]
    interface WXDebugTool : WXModuleProtocol
    {
        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        WXDebugTool SharedInstance();

        // +(void)setDebug:(BOOL)isDebug;
        [Static]
        [Export("setDebug:")]
        void SetDebug(bool isDebug);

        // +(BOOL)isDebug;
        [Static]
        [Export("isDebug")]
        //	[Verify(MethodToProperty)]
        bool IsDebug { get; }

        // +(void)setDevToolDebug:(BOOL)isDevToolDebug;
        [Static]
        [Export("setDevToolDebug:")]
        void SetDevToolDebug(bool isDevToolDebug);

        // +(BOOL)isDevToolDebug;
        [Static]
        [Export("isDevToolDebug")]
        //[Verify(MethodToProperty)]
        bool IsDevToolDebug { get; }

        // +(void)setReplacedBundleJS:(NSURL *)url;
        [Static]
        [Export("setReplacedBundleJS:")]
        void SetReplacedBundleJS(NSUrl url);

        // +(NSString *)getReplacedBundleJS;
        [Static]
        [Export("getReplacedBundleJS")]
        //[Verify(MethodToProperty)]
        string ReplacedBundleJS { get; }

        // +(void)setReplacedJSFramework:(NSURL *)url;
        [Static]
        [Export("setReplacedJSFramework:")]
        void SetReplacedJSFramework(NSUrl url);

        // +(NSString *)getReplacedJSFramework;
        [Static]
        [Export("getReplacedJSFramework")]
        //[Verify(MethodToProperty)]
        string ReplacedJSFramework { get; }

        // +(BOOL)cacheJsService:(NSString *)name withScript:(NSString *)script withOptions:(NSDictionary *)options;
        [Static]
        [Export("cacheJsService:withScript:withOptions:")]
        bool CacheJsService(string name, string script, NSDictionary options);

        // +(BOOL)removeCacheJsService:(NSString *)name;
        [Static]
        [Export("removeCacheJsService:")]
        bool RemoveCacheJsService(string name);

        // +(NSDictionary *)jsServiceCache;
        [Static]
        [Export("jsServiceCache")]
        //	[Verify(MethodToProperty)]
        NSDictionary JsServiceCache { get; }
    }

    //// @interface WXConvert : NSObject
    //[BaseType(typeof(NSObject))]
    //interface WXConvert
    //{
    //	// +(BOOL)BOOL:(id)value;
    //	[Static]
    //	[Export("BOOL:")]
    //	bool BOOL(NSObject value);

    //	// +(CGFloat)CGFloat:(id)value;
    //	[Static]
    //	[Export("CGFloat:")]
    //	nfloat CGFloat(NSObject value);

    //	// +(NSUInteger)NSUInteger:(id)value;
    //	[Static]
    //	[Export("NSUInteger:")]
    //	nuint NSUInteger(NSObject value);

    //	// +(NSInteger)NSInteger:(id)value;
    //	[Static]
    //	[Export("NSInteger:")]
    //	nint NSInteger(NSObject value);

    //	// +(NSString *)NSString:(id)value;
    //	[Static]
    //	[Export("NSString:")]
    //	string NSString(NSObject value);

    //	// +(WXPixelType)WXPixelType:(id)value scaleFactor:(CGFloat)scaleFactor;
    //	[Static]
    //	[Export("WXPixelType:scaleFactor:")]
    //	double WXPixelType(NSObject value, nfloat scaleFactor);

    //	// +(wx_css_flex_direction_t)wx_css_flex_direction_t:(id)value;
    //	[Static]
    //	[Export("wx_css_flex_direction_t:")]
    //	wx_css_flex_direction_t Wx_css_flex_direction_t(NSObject value);

    //	// +(wx_css_align_t)wx_css_align_t:(id)value;
    //	[Static]
    //	[Export("wx_css_align_t:")]
    //	wx_css_align_t Wx_css_align_t(NSObject value);

    //	// +(wx_css_wrap_type_t)wx_css_wrap_type_t:(id)value;
    //	[Static]
    //	[Export("wx_css_wrap_type_t:")]
    //	wx_css_wrap_type_t Wx_css_wrap_type_t(NSObject value);

    //	// +(wx_css_justify_t)wx_css_justify_t:(id)value;
    //	[Static]
    //	[Export("wx_css_justify_t:")]
    //	wx_css_justify_t Wx_css_justify_t(NSObject value);

    //	// +(wx_css_position_type_t)wx_css_position_type_t:(id)value;
    //	[Static]
    //	[Export("wx_css_position_type_t:")]
    //	wx_css_position_type_t Wx_css_position_type_t(NSObject value);

    //	// +(UIViewContentMode)UIViewContentMode:(id)value;
    //	[Static]
    //	[Export("UIViewContentMode:")]
    //	UIViewContentMode UIViewContentMode(NSObject value);

    //	// +(WXImageQuality)WXImageQuality:(id)value;
    //	[Static]
    //	[Export("WXImageQuality:")]
    //	WXImageQuality WXImageQuality(NSObject value);

    //	// +(WXImageSharp)WXImageSharp:(id)value;
    //	[Static]
    //	[Export("WXImageSharp:")]
    //	WXImageSharp WXImageSharp(NSObject value);

    //	// +(UIAccessibilityTraits)WXUIAccessibilityTraits:(id)value;
    //	[Static]
    //	[Export("WXUIAccessibilityTraits:")]
    //	ulong WXUIAccessibilityTraits(NSObject value);

    //	// +(UIColor *)UIColor:(id)value;
    //	[Static]
    //	[Export("UIColor:")]
    //	UIColor UIColor(NSObject value);

    //	// +(CGColorRef)CGColor:(id)value;
    //	[Static]
    //	[Export("CGColor:")]
    //	unsafe CGColor CGColor(NSObject value);

    //	// +(WXBorderStyle)WXBorderStyle:(id)value;
    //	[Static]
    //	[Export("WXBorderStyle:")]
    //	WXBorderStyle WXBorderStyle(NSObject value);

    //	// +(WXClipType)WXClipType:(id)value;
    //	[Static]
    //	[Export("WXClipType:")]
    //	bool WXClipType(NSObject value);

    //	// +(WXPositionType)WXPositionType:(id)value;
    //	[Static]
    //	[Export("WXPositionType:")]
    //	WXPositionType WXPositionType(NSObject value);

    //	// +(WXTextStyle)WXTextStyle:(id)value;
    //	[Static]
    //	[Export("WXTextStyle:")]
    //	WXTextStyle WXTextStyle(NSObject value);

    //	// +(CGFloat)WXTextWeight:(id)value;
    //	[Static]
    //	[Export("WXTextWeight:")]
    //	nfloat WXTextWeight(NSObject value);

    //	// +(WXTextDecoration)WXTextDecoration:(id)value;
    //	[Static]
    //	[Export("WXTextDecoration:")]
    //	WXTextDecoration WXTextDecoration(NSObject value);

    //	// +(NSTextAlignment)NSTextAlignment:(id)value;
    //	[Static]
    //	[Export("NSTextAlignment:")]
    //	UITextAlignment NSTextAlignment(NSObject value);

    //	// +(UIReturnKeyType)UIReturnKeyType:(id)value;
    //	[Static]
    //	[Export("UIReturnKeyType:")]
    //	UIReturnKeyType UIReturnKeyType(NSObject value);

    //	// +(WXScrollDirection)WXScrollDirection:(id)value;
    //	[Static]
    //	[Export("WXScrollDirection:")]
    //	WXScrollDirection WXScrollDirection(NSObject value);

    //	// +(UITableViewRowAnimation)UITableViewRowAnimation:(id)value;
    //	[Static]
    //	[Export("UITableViewRowAnimation:")]
    //	UITableViewRowAnimation UITableViewRowAnimation(NSObject value);

    //	// +(UIViewAnimationOptions)UIViewAnimationTimingFunction:(id)value;
    //	[Static]
    //	[Export("UIViewAnimationTimingFunction:")]
    //	UIViewAnimationOptions UIViewAnimationTimingFunction(NSObject value);

    //	// +(CAMediaTimingFunction *)CAMediaTimingFunction:(id)value;
    //	[Static]
    //	[Export("CAMediaTimingFunction:")]
    //	CAMediaTimingFunction CAMediaTimingFunction(NSObject value);

    //	// +(WXVisibility)WXVisibility:(id)value;
    //	[Static]
    //	[Export("WXVisibility:")]
    //	WXVisibility WXVisibility(NSObject value);

    //	// +(WXGradientType)gradientType:(id)value;
    //	[Static]
    //	[Export("gradientType:")]
    //	WXGradientType GradientType(NSObject value);

    //	// +(WXLength *)WXLength:(id)value isFloat:(BOOL)isFloat scaleFactor:(CGFloat)scaleFactor;
    //	[Static]
    //	[Export("WXLength:isFloat:scaleFactor:")]
    //	WXLength WXLength(NSObject value, bool isFloat, nfloat scaleFactor);

    //	// +(WXBoxShadow *)WXBoxShadow:(id)value scaleFactor:(CGFloat)scaleFactor;
    //	[Static]
    //	[Export("WXBoxShadow:scaleFactor:")]
    //	WXBoxShadow WXBoxShadow(NSObject value, nfloat scaleFactor);
    //}

    // @protocol WXConfigCenterProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXConfigCenterProtocol
    {
        // @required -(id)configForKey:(NSString *)key defaultValue:(id)defaultValue isDefault:(BOOL *)isDefault;
        [Abstract]
        [Export("configForKey:defaultValue:isDefault:")]
        unsafe NSObject DefaultValue(string key, NSObject defaultValue, bool isDefault);
    }

    // @interface WXComponentManager : NSObject
    [BaseType(typeof(NSObject))]
    interface WXComponentManager
    {
        // @property (readonly, nonatomic, weak) WXSDKInstance * weexInstance;
        [Export("weexInstance", ArgumentSemantic.Weak)]
        WXSDKInstance WeexInstance { get; }

        // @property (readonly, assign, nonatomic) BOOL isValid;
        [Export("isValid")]
        bool IsValid { get; }

        // -(instancetype)initWithWeexInstance:(WXSDKInstance *)weexInstance;
        [Export("initWithWeexInstance:")]
        IntPtr Constructor(WXSDKInstance weexInstance);

        // +(NSThread *)componentThread;
        [Static]
        [Export("componentThread")]
        //[Verify(MethodToProperty)]
        NSThread ComponentThread { get; }

        // -(void)startComponentTasks;
        [Export("startComponentTasks")]
        void StartComponentTasks();

        // -(void)rootViewFrameDidChange:(CGRect)frame;
        [Export("rootViewFrameDidChange:")]
        void RootViewFrameDidChange(CGRect frame);

        // -(void)createRoot:(NSDictionary *)data;
        [Export("createRoot:")]
        void CreateRoot(NSDictionary data);

        // -(void)addComponent:(NSDictionary *)componentData toSupercomponent:(NSString *)superRef atIndex:(NSInteger)index appendingInTree:(BOOL)appendingInTree;
        [Export("addComponent:toSupercomponent:atIndex:appendingInTree:")]
        void AddComponent(NSDictionary componentData, string superRef, nint index, bool appendingInTree);

        // -(void)removeComponent:(NSString *)ref;
        [Export("removeComponent:")]
        void RemoveComponent(string @ref);

        // -(void)moveComponent:(NSString *)ref toSuper:(NSString *)superRef atIndex:(NSInteger)index;
        [Export("moveComponent:toSuper:atIndex:")]
        void MoveComponent(string @ref, string superRef, nint index);

        // -(WXComponent *)componentForRef:(NSString *)ref;
        [Export("componentForRef:")]
        WXComponent ComponentForRef(string @ref);

        // -(WXComponent *)componentForRoot;
        [Export("componentForRoot")]
        //[Verify(MethodToProperty)]
        WXComponent ComponentForRoot { get; }

        // -(NSUInteger)numberOfComponents;
        [Export("numberOfComponents")]
        //[Verify(MethodToProperty)]
        nuint NumberOfComponents { get; }

        // -(void)updateStyles:(NSDictionary *)styles forComponent:(NSString *)ref;
        [Export("updateStyles:forComponent:")]
        void UpdateStyles(NSDictionary styles, string @ref);

        // -(void)updatePseudoClassStyles:(NSDictionary *)styles forComponent:(NSString *)ref;
        [Export("updatePseudoClassStyles:forComponent:")]
        void UpdatePseudoClassStyles(NSDictionary styles, string @ref);

        // -(void)updateAttributes:(NSDictionary *)attributes forComponent:(NSString *)ref;
        [Export("updateAttributes:forComponent:")]
        void UpdateAttributes(NSDictionary attributes, string @ref);

        // -(void)addEvent:(NSString *)event toComponent:(NSString *)ref;
        [Export("addEvent:toComponent:")]
        void AddEvent(string @event, string @ref);

        // -(void)removeEvent:(NSString *)event fromComponent:(NSString *)ref;
        [Export("removeEvent:fromComponent:")]
        void RemoveEvent(string @event, string @ref);

        // -(void)scrollToComponent:(NSString *)ref options:(NSDictionary *)options;
        [Export("scrollToComponent:options:")]
        void ScrollToComponent(string @ref, NSDictionary options);

        // -(void)createFinish;
        [Export("createFinish")]
        void CreateFinish();

        // -(void)refreshFinish;
        [Export("refreshFinish")]
        void RefreshFinish();

        // -(void)updateFinish;
        [Export("updateFinish")]
        void UpdateFinish();

        // -(void)unload;
        [Export("unload")]
        void Unload();

        // -(void)invalidate;
        [Export("invalidate")]
        void Invalidate();

        // -(void)addFixedComponent:(WXComponent *)fixComponent;
        [Export("addFixedComponent:")]
        void AddFixedComponent(WXComponent fixComponent);

        // -(void)removeFixedComponent:(WXComponent *)fixComponent;
        [Export("removeFixedComponent:")]
        void RemoveFixedComponent(WXComponent fixComponent);

        // -(void)_addUITask:(void (^)())block;
        [Export("_addUITask:")]
        void _addUITask(Action block);

        // -(void)excutePrerenderUITask:(NSString *)url;
        [Export("excutePrerenderUITask:")]
        void ExcutePrerenderUITask(string url);
    }

    // typedef NSInteger (^WXJSCallNative)(NSString *, NSArray *, NSString *);
    delegate nint WXJSCallNative(string arg0, NSObject[] arg1, string arg2);

    // typedef NSInteger (^WXJSCallAddElement)(NSString *, NSString *, NSDictionary *, NSInteger);
    delegate nint WXJSCallAddElement(string arg0, string arg1, NSDictionary arg2, nint arg3);

    // typedef NSInvocation * (^WXJSCallNativeModule)(NSString *, NSString *, NSString *, NSArray *, NSDictionary *);
    delegate NSInvocation WXJSCallNativeModule(string arg0, string arg1, string arg2, NSObject[] arg3, NSDictionary arg4);

    // typedef void (^WXJSCallNativeComponent)(NSString *, NSString *, NSString *, NSArray *, NSDictionary *);
    delegate void WXJSCallNativeComponent(string arg0, string arg1, string arg2, NSObject[] arg3, NSDictionary arg4);

    // @protocol WXBridgeProtocol <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXBridgeProtocol
    {
        // @required @property (readonly, nonatomic) JSValue * exception;
        [Abstract]
        [Export("exception")]
        JSValue Exception { get; }

        // @required -(void)executeJSFramework:(NSString *)frameworkScript;
        [Abstract]
        [Export("executeJSFramework:")]
        void ExecuteJSFramework(string frameworkScript);

        // @required -(void)executeJavascript:(NSString *)script;
        [Abstract]
        [Export("executeJavascript:")]
        void ExecuteJavascript(string script);

        // @required -(JSValue *)callJSMethod:(NSString *)method args:(NSArray *)args;
        [Abstract]
        [Export("callJSMethod:args:")]
        //[Verify(StronglyTypedNSArray)]
        JSValue CallJSMethod(string method, NSObject[] args);

        // @required -(void)registerCallNative:(WXJSCallNative)callNative;
        [Abstract]
        [Export("registerCallNative:")]
        void RegisterCallNative(WXJSCallNative callNative);

        // @required -(void)resetEnvironment;
        [Abstract]
        [Export("resetEnvironment")]
        void ResetEnvironment();

        // @optional -(void)removeTimers:(NSString *)instance;
        [Export("removeTimers:")]
        void RemoveTimers(string instance);

        // @optional -(void)garbageCollect;
        [Export("garbageCollect")]
        void GarbageCollect();

        // @optional -(void)registerCallAddElement:(WXJSCallAddElement)callAddElement;
        [Export("registerCallAddElement:")]
        void RegisterCallAddElement(WXJSCallAddElement callAddElement);

        // @optional -(void)registerCallNativeModule:(WXJSCallNativeModule)callNativeModuleBlock;
        [Export("registerCallNativeModule:")]
        void RegisterCallNativeModule(WXJSCallNativeModule callNativeModuleBlock);

        // @optional -(void)registerCallNativeComponent:(WXJSCallNativeComponent)callNativeComponentBlock;
        [Export("registerCallNativeComponent:")]
        void RegisterCallNativeComponent(WXJSCallNativeComponent callNativeComponentBlock);
    }

    // @interface WXBaseViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface WXBaseViewController
    {
        // -(instancetype)initWithSourceURL:(NSURL *)sourceURL;
        [Export("initWithSourceURL:")]
        IntPtr Constructor(NSUrl sourceURL);

        // -(void)refreshWeex;
        [Export("refreshWeex")]
        void RefreshWeex();
    }

    // @protocol WXAppMonitorProtocol <WXModuleProtocol>
    [Protocol, Model]
    interface WXAppMonitorProtocol : WXModuleProtocol
    {
        // @required -(void)commitAppMonitorArgs:(NSDictionary *)args;
        [Abstract]
        [Export("commitAppMonitorArgs:")]
        void CommitAppMonitorArgs(NSDictionary args);

        // @required -(void)commitAppMonitorAlarm:(NSString *)pageName monitorPoint:(NSString *)monitorPoint success:(BOOL)success errorCode:(NSString *)errorCode errorMsg:(NSString *)errorMsg arg:(NSString *)arg;
        [Abstract]
        [Export("commitAppMonitorAlarm:monitorPoint:success:errorCode:errorMsg:arg:")]
        void CommitAppMonitorAlarm(string pageName, string monitorPoint, bool success, string errorCode, string errorMsg, string arg);
    }

    // @interface WXAppConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface WXAppConfiguration
    {
        // +(NSString *)appGroup;
        // +(void)setAppGroup:(NSString *)appGroup;
        [Static]
        [Export("appGroup")]
        //[Verify(MethodToProperty)]
        string AppGroup { get; set; }

        // +(NSString *)appName;
        [Static]
        [Export("appName")]
        string AppName();

        // +(void)setAppName:(NSString *)appName;
        [Static]
        [Export("setAppName:")]
        void SetAppName(string appName);

        // +(NSString *)appVersion;
        [Static]
        [Export("appVersion")]
        string AppVersion();

        // +(void)setAppVersion:(NSString *)appVersion;
        [Static]
        [Export("setAppVersion:")]
        void SetAppVersion(string appVersion);

        // +(NSString *)externalUserAgent;
        [Static]
        [Export("externalUserAgent")]
        string ExternalUserAgent();

        // +(void)setExternalUserAgent:(NSString *)userAgent;
        [Static]
        [Export("setExternalUserAgent:")]
        void SetExternalUserAgent(string userAgent);

        // +(NSString *)JSFrameworkVersion;
        [Static]
        [Export("JSFrameworkVersion")]
        string JSFrameworkVersion();

        // +(void)setJSFrameworkVersion:(NSString *)JSFrameworkVersion;
        [Static]
        [Export("setJSFrameworkVersion:")]
        void SetJSFrameworkVersion(string JSFrameworkVersion);

        // +(NSArray *)customizeProtocolClasses;
        [Static]
        [Export("customizeProtocolClasses")]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] CustomizeProtocolClasses();

        // +(void)setCustomizeProtocolClasses:(NSArray *)customizeProtocolClasses;
        [Static]
        [Export("setCustomizeProtocolClasses:")]
        //[Verify(StronglyTypedNSArray)]
        void SetCustomizeProtocolClasses(NSObject[] customizeProtocolClasses);
    }

    // @interface WXAComponent : WXComponent <UIGestureRecognizerDelegate>
    [BaseType(typeof(WXComponent))]
    interface WXAComponent : IUIGestureRecognizerDelegate
    {
    }

    // @interface WXSwizzle (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_WXSwizzle
    {
        // +(BOOL)weex_swizzle:(Class)originalClass Method:(SEL)originalSelector withMethod:(SEL)swizzledSelector;
        [Static]
        [Export("weex_swizzle:Method:withMethod:")]
        bool Weex_swizzle(Class originalClass, Selector originalSelector, Selector swizzledSelector);
    }
}
