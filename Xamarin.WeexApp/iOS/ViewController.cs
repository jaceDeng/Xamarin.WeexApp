using System;

using UIKit;
using WeexSDK;

namespace Mingx.WeexApp.iOS
{
    public partial class ViewController : UIViewController
    {
      //  int count = 1;
        WXSDKInstance instance;
        // public ViewController(IntPtr handle) : base(handle)
        // {
        // }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            instance = new WXSDKInstance();
            instance.Init();
            instance.ViewController = this;
            instance.Frame = this.View.Frame;
            instance.OnCreate += new Action<UIView>((UIView obj) =>
            {
                this.RemoveFromParentViewController();
                this.View = obj;
                this.View.AddSubview(this.View);
            });
            instance.OnFailed += new Action<Foundation.NSError>((Foundation.NSError er) =>
            {


            });
            string source = System.IO.File.ReadAllText(System.Environment.SpecialFolder.Resources + "/index.weex.js");
            instance.RenderView(source, null, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
