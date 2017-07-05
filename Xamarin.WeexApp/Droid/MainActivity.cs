using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Pili.Pldroid.Player.Widget;
using Com.Taobao.Weex;
using Com.Taobao.Weex.Common;
using Com.Taobao.Weex.Utils;
using System;
using System.IO;

namespace Xamarin.WeexApp.Droid
{
     [Activity(Label = "Mingx.WeexApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, IWXRenderListener
    {
        //    int count = 1;
        // PLVideoView mVideoView;
        WXSDKInstance mWXSDKInstance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mWXSDKInstance = new WXSDKInstance(this);
            mWXSDKInstance.RegisterRenderListener(this);
            //  mVideoView = (PLVideoView)FindViewById<PLVideoView>(Resource.Id.PLVideo);
            //  mVideoView.SetVideoPath("rtmp://live.hkstv.hk.lxdns.com/live/hks");
            //string template;
            //using (StreamReader sr = new StreamReader(Assets.Open("tech_list.js")))
            //{
            //    template = sr.ReadToEnd();
            //}
            mWXSDKInstance.Render(WXFileUtils.LoadAsset("index.weex.js", this), -1, -1);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            // mVideoView.StopPlayback();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (mWXSDKInstance != null)
            {
                mWXSDKInstance.OnActivityResume();
            }
            // mVideoView.Start();
        }

        protected override void OnPause()
        {
            base.OnPause();
            // mVideoView.Pause();
            if (mWXSDKInstance != null)
            {
                mWXSDKInstance.OnActivityPause();
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (mWXSDKInstance != null)
            {
                mWXSDKInstance.OnActivityStop();
            }
        }


        protected void onDestroy()
        {
            base.OnDestroy();
            if (mWXSDKInstance != null)
            {
                mWXSDKInstance.OnActivityDestroy();
            }
        }

        public void OnException(WXSDKInstance instance, string errCode, string msg)
        {

        }

        public void OnRefreshSuccess(WXSDKInstance instance, int width, int height)
        {

        }

        public void OnRenderSuccess(WXSDKInstance instance, int width, int height)
        {

        }

        public void OnViewCreated(WXSDKInstance instance, View view)
        {
            SetContentView(view);
        }
    }
}

