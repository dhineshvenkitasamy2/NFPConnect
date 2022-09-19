package crc6401504a013aecfd6e;


public class InstallationAdapterErrorListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.microsoft.windowsazure.messaging.notificationhubs.InstallationAdapter.ErrorListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInstallationSaveError:(Ljava/lang/Exception;)V:GetOnInstallationSaveError_Ljava_lang_Exception_Handler:WindowsAzure.Messaging.NotificationHubs.IInstallationAdapterErrorListenerInvoker, Xamarin.Azure.NotificationHubs.Android\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Azure.NotificationHubs.Client.InstallationAdapterErrorListener, Microsoft.Azure.NotificationHubs.Client", InstallationAdapterErrorListener.class, __md_methods);
	}


	public InstallationAdapterErrorListener ()
	{
		super ();
		if (getClass () == InstallationAdapterErrorListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Azure.NotificationHubs.Client.InstallationAdapterErrorListener, Microsoft.Azure.NotificationHubs.Client", "", this, new java.lang.Object[] {  });
		}
	}


	public void onInstallationSaveError (java.lang.Exception p0)
	{
		n_onInstallationSaveError (p0);
	}

	private native void n_onInstallationSaveError (java.lang.Exception p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
