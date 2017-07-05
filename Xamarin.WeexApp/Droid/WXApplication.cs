using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Taobao.Weex;
using Com.Taobao.Weex.Adapter;
using Com.Taobao.Weex.Common;
using Com.Taobao.Weex.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin.WeexApp.Droid
{
    //[Application(Debuggable = true,
    //Label = "insert label here", 
    //ManageSpaceActivity  = typeof(MainActivity))]
    [Application(Debuggable = true)]
    public class WXApplication : Application
    {

        public WXApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {

        }


        public override void OnCreate()
        {
            base.OnCreate();
            InitConfig config = new InitConfig.Builder().SetImgAdapter(new ImageAdapter()).Build();
            WXSDKEngine.Initialize(this, config);
        }

    }

    public class ImageAdapter : Java.Lang.Object, IWXImgLoaderAdapter
    {
        public void SetImage(string url, ImageView view, WXImageQuality quality, WXImageStrategy strategy)
        {

            Square.Picasso.Picasso.With(view.Context).Load(url).Into(view);
            //if (!TextUtils.isEmpty(url))
            //{
            //    if (url.startsWith("drawable://"))
            //    {
            //        getImageBydrawableName(view, url);//获取drawable图片
            //        return;
            //    }
            //}
            //Picasso.with(view.getContext()).load(url).into(view);//获取网络图片
        }
    }
}